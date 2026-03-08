using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Core.Domain.Shipping;
using Nop.Plugin.Shipping.USPS.Domain;
using Nop.Services.Directory;
using Nop.Services.Logging;
using Nop.Services.Shipping;

namespace Nop.Plugin.Shipping.USPS.Services
{
    public class USPSService
    {
        #region Fields

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;
        private readonly IMeasureService _measureService;
        private readonly IShippingService _shippingService;
        private readonly USPSSettings _uspsSettings;

        // Simple in-process token cache (avoids IMemoryCache/IChangeToken dependency)
        private static string _cachedToken;
        private static DateTime _tokenExpiry = DateTime.MinValue;
        private static readonly object _tokenLock = new object();

        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        #endregion

        #region Ctor

        public USPSService(
            IHttpClientFactory httpClientFactory,
            ILogger logger,
            IMeasureService measureService,
            IShippingService shippingService,
            USPSSettings uspsSettings)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _measureService = measureService;
            _shippingService = shippingService;
            _uspsSettings = uspsSettings;
        }

        #endregion

        #region Utilities

        private string BaseUrl => _uspsSettings.UseSandbox
            ? USPSShippingDefaults.SANDBOX_BASE_URL
            : USPSShippingDefaults.PRODUCTION_BASE_URL;

        /// <summary>
        /// Gets a cached OAuth2 access token, refreshing if expired.
        /// </summary>
        private async Task<string> GetAccessTokenAsync()
        {
            lock (_tokenLock)
            {
                if (_cachedToken != null && DateTime.UtcNow < _tokenExpiry)
                    return _cachedToken;
            }

            var client = _httpClientFactory.CreateClient();
            var tokenUrl = $"{BaseUrl}{USPSShippingDefaults.TOKEN_PATH}";

            var form = new Dictionary<string, string>
            {
                ["grant_type"]    = "client_credentials",
                ["client_id"]     = _uspsSettings.ClientId ?? string.Empty,
                ["client_secret"] = _uspsSettings.ClientSecret ?? string.Empty,
                ["scope"]         = $"{USPSShippingDefaults.PRICES_SCOPE} {USPSShippingDefaults.INTERNATIONAL_PRICES_SCOPE}"
            };

            var response = await client.PostAsync(tokenUrl, new FormUrlEncodedContent(form));
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(json);

            if (tokenResponse?.AccessToken == null)
                throw new NopException("USPS OAuth2: empty access token received.");

            var expiresIn = tokenResponse.ExpiresIn > 0 ? tokenResponse.ExpiresIn : 3600;

            lock (_tokenLock)
            {
                _cachedToken = tokenResponse.AccessToken;
                _tokenExpiry = DateTime.UtcNow.AddSeconds(expiresIn - USPSShippingDefaults.TOKEN_CACHE_SECONDS_BUFFER);
            }

            return tokenResponse.AccessToken;
        }

        private bool IsDomesticRequest(GetShippingOptionRequest request)
        {
            if (request?.ShippingAddress?.Country == null)
                return true;

            switch (request.ShippingAddress.Country.ThreeLetterIsoCode)
            {
                case "USA":
                case "PRI":
                case "UMI":
                case "ASM":
                case "GUM":
                case "MHL":
                case "FSM":
                case "MNP":
                case "PLW":
                case "VIR":
                    return true;
                default:
                    return false;
            }
        }

        private (decimal weightLbs, decimal length, decimal width, decimal height) GetPackageMeasurements(
            GetShippingOptionRequest request)
        {
            var measureWeight = _measureService.GetMeasureWeightBySystemKeyword(USPSShippingDefaults.MEASURE_WEIGHT_SYSTEM_KEYWORD)
                ?? throw new NopException($"USPS: Could not load measure weight '{USPSShippingDefaults.MEASURE_WEIGHT_SYSTEM_KEYWORD}'");

            var measureDimension = _measureService.GetMeasureDimensionBySystemKeyword(USPSShippingDefaults.MEASURE_DIMENSION_SYSTEM_KEYWORD)
                ?? throw new NopException($"USPS: Could not load measure dimension '{USPSShippingDefaults.MEASURE_DIMENSION_SYSTEM_KEYWORD}'");

            var rawWeight = _shippingService.GetTotalWeight(request, ignoreFreeShippedItems: true);
            var weightLbs = Math.Max(
                _measureService.ConvertFromPrimaryMeasureWeight(rawWeight, measureWeight),
                0.1M);

            _shippingService.GetDimensions(request.Items, out var w, out var l, out var h, true);

            decimal convertDim(decimal d)
            {
                d = _measureService.ConvertFromPrimaryMeasureDimension(d, measureDimension);
                return Math.Max(Math.Ceiling(d), 1M);
            }

            return (weightLbs, convertDim(l), convertDim(w), convertDim(h));
        }

        private string GetMailingDate() => DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

        #endregion

        #region Domestic rates

        public async Task<IList<ShippingOption>> GetDomesticRatesAsync(GetShippingOptionRequest request)
        {
            // Let token exceptions propagate — caller (GetRatesAsync) will surface the real error
            var token = await GetAccessTokenAsync();

            var result = new List<ShippingOption>();
            var (weightLbs, length, width, height) = GetPackageMeasurements(request);
            var originZip = (request.ZipPostalCodeFrom ?? string.Empty).Replace("-", "").PadRight(5).Substring(0, 5).Trim();
            var destZip   = (request.ShippingAddress?.ZipPostalCode ?? string.Empty).Replace("-", "").PadRight(5).Substring(0, 5).Trim();

            var offeredServices = _uspsSettings.CarrierServicesOfferedDomestic ?? string.Empty;

            foreach (var mailClass in USPSShippingDefaults.DomesticMailClasses)
            {
                if (!string.IsNullOrEmpty(offeredServices) && !offeredServices.Contains($"[{mailClass}]"))
                    continue;

                var rateRequest = new DomesticRateRequest
                {
                    OriginZIPCode               = originZip,
                    DestinationZIPCode          = destZip,
                    Weight                      = weightLbs,
                    Length                      = length,
                    Width                       = width,
                    Height                      = height,
                    MailClass                   = mailClass,
                    ProcessingCategory          = "MACHINABLE",
                    DestinationEntryFacilityType = "NONE",
                    RateIndicator               = "SP",
                    PriceType                   = "RETAIL",
                    MailingDate                 = GetMailingDate()
                };

                try
                {
                    var rate = await PostRateRequestAsync<DomesticRateRequest, DomesticRateResponse>(
                        USPSShippingDefaults.DOMESTIC_RATES_PATH, rateRequest, token);

                    if (rate?.TotalBasePrice > 0)
                    {
                        result.Add(new ShippingOption
                        {
                            Name = USPSShippingDefaults.GetDomesticDisplayName(mailClass),
                            Rate = rate.TotalBasePrice + _uspsSettings.AdditionalHandlingCharge
                        });
                    }
                }
                catch (Exception ex)
                {
                    _logger.Warning($"USPS domestic rate error for {mailClass}: {ex.Message}");
                }
            }

            return result;
        }

        #endregion

        #region International rates

        public async Task<IList<ShippingOption>> GetInternationalRatesAsync(GetShippingOptionRequest request)
        {
            // Let token exceptions propagate — caller (GetRatesAsync) will surface the real error
            var token = await GetAccessTokenAsync();

            var result = new List<ShippingOption>();
            var (weightLbs, length, width, height) = GetPackageMeasurements(request);
            var originZip = (request.ZipPostalCodeFrom ?? string.Empty).Replace("-", "").PadRight(5).Substring(0, 5).Trim();
            var countryCode = request.ShippingAddress?.Country?.TwoLetterIsoCode ?? "US";

            var offeredServices = _uspsSettings.CarrierServicesOfferedInternational ?? string.Empty;

            foreach (var mailClass in USPSShippingDefaults.InternationalMailClasses)
            {
                if (!string.IsNullOrEmpty(offeredServices) && !offeredServices.Contains($"[{mailClass}]"))
                    continue;

                var rateRequest = new InternationalRateRequest
                {
                    OriginZIPCode               = originZip,
                    DestinationCountryCode      = countryCode,
                    Weight                      = weightLbs,
                    Length                      = length,
                    Width                       = width,
                    Height                      = height,
                    MailClass                   = mailClass,
                    ProcessingCategory          = "MACHINABLE",
                    DestinationEntryFacilityType = "NONE",
                    RateIndicator               = "SP",
                    PriceType                   = "RETAIL",
                    MailingDate                 = GetMailingDate()
                };

                try
                {
                    var rate = await PostRateRequestAsync<InternationalRateRequest, InternationalRateResponse>(
                        USPSShippingDefaults.INTERNATIONAL_RATES_PATH, rateRequest, token);

                    if (rate?.TotalBasePrice > 0)
                    {
                        result.Add(new ShippingOption
                        {
                            Name = USPSShippingDefaults.GetInternationalDisplayName(mailClass),
                            Rate = rate.TotalBasePrice + _uspsSettings.AdditionalHandlingCharge
                        });
                    }
                }
                catch (Exception ex)
                {
                    _logger.Warning($"USPS international rate error for {mailClass}: {ex.Message}");
                }
            }

            return result;
        }

        #endregion

        #region HTTP helpers

        private async Task<TResponse> PostRateRequestAsync<TRequest, TResponse>(
            string path, TRequest requestBody, string accessToken)
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"{BaseUrl}{path}";

            var json = JsonConvert.SerializeObject(requestBody, _jsonSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, url))
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                httpRequest.Content = content;

                var response = await client.SendAsync(httpRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    throw new Exception($"HTTP {(int)response.StatusCode}: {errorBody}");
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseJson);
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Gets available shipping rates (synchronous wrapper for NopCommerce 4.20).
        /// </summary>
        public GetShippingOptionResponse GetRates(GetShippingOptionRequest request)
        {
            return GetRatesAsync(request).GetAwaiter().GetResult();
        }

        private async Task<GetShippingOptionResponse> GetRatesAsync(GetShippingOptionRequest request)
        {
            var response = new GetShippingOptionResponse();

            // Validate credentials before making any API calls
            if (string.IsNullOrWhiteSpace(_uspsSettings.ClientId) || string.IsNullOrWhiteSpace(_uspsSettings.ClientSecret))
            {
                response.Errors.Add("USPS plugin is not configured: Client ID and Client Secret are required. Please go to Admin > Configuration > Shipping > Providers > USPS to configure.");
                return response;
            }

            try
            {
                IList<ShippingOption> options;

                if (IsDomesticRequest(request))
                    options = await GetDomesticRatesAsync(request);
                else
                    options = await GetInternationalRatesAsync(request);

                if (!options.Any())
                {
                    response.Errors.Add("No USPS shipping options are available for this destination. Check the NopCommerce activity log for rate request details.");
                    return response;
                }

                foreach (var option in options)
                    response.ShippingOptions.Add(option);
            }
            catch (Exception ex)
            {
                var message = $"USPS error: {ex.Message}";
                _logger.Error(message, ex);
                response.Errors.Add(message);
            }

            return response;
        }

        #endregion
    }
}
