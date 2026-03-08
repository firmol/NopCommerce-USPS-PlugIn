using System;
using System.Linq;
using Nop.Core;
using Nop.Plugin.Shipping.USPS.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Shipping;
using Nop.Services.Shipping.Tracking;

namespace Nop.Plugin.Shipping.USPS
{
    public class USPSComputationMethod : BasePlugin, IShippingRateComputationMethod
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly USPSService _uspsService;

        #endregion

        #region Ctor

        public USPSComputationMethod(
            ILocalizationService localizationService,
            ISettingService settingService,
            IWebHelper webHelper,
            USPSService uspsService)
        {
            _localizationService = localizationService;
            _settingService = settingService;
            _webHelper = webHelper;
            _uspsService = uspsService;
        }

        #endregion

        #region Methods

        public GetShippingOptionResponse GetShippingOptions(GetShippingOptionRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            if (!request.Items?.Any() ?? true)
                return new GetShippingOptionResponse { Errors = new[] { "No shipment items" } };

            if (request.ShippingAddress?.Country is null)
                return new GetShippingOptionResponse { Errors = new[] { "Shipping address is not set" } };

            return _uspsService.GetRates(request);
        }

        public decimal? GetFixedRate(GetShippingOptionRequest request)
        {
            return null;
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/ShippingUSPS/Configure";
        }

        public override void Install()
        {
            var settings = new USPSSettings
            {
                ClientId                            = string.Empty,
                ClientSecret                        = string.Empty,
                UseSandbox                          = true,
                AdditionalHandlingCharge            = 0,
                CarrierServicesOfferedDomestic      = "[PRIORITY_MAIL]:[USPS_GROUND_ADVANTAGE]:[PRIORITY_MAIL_EXPRESS]:",
                CarrierServicesOfferedInternational = "[PRIORITY_MAIL_INTERNATIONAL]:[PRIORITY_MAIL_EXPRESS_INTERNATIONAL]:"
            };
            _settingService.SaveSetting(settings);

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.ClientId", "Consumer Key");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.ClientId.Hint", "The Consumer Key from the USPS Developer Portal (used as OAuth2 Client ID).");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.ClientSecret", "Consumer Secret");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.ClientSecret.Hint", "The Consumer Secret from the USPS Developer Portal. Leave blank to keep the current saved value.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.UseSandbox", "Use Sandbox");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.UseSandbox.Hint", "Check to use the USPS testing/sandbox environment.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.AdditionalHandlingCharge", "Additional handling charge");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.AdditionalHandlingCharge.Hint", "Extra fee added to every shipping rate.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesDomestic", "Domestic Services");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesDomestic.Hint", "Select domestic services to offer at checkout.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesInternational", "International Services");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesInternational.Hint", "Select international services to offer at checkout.");

            base.Install();
        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<USPSSettings>();

            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.ClientId");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.ClientId.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.ClientSecret");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.ClientSecret.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.UseSandbox");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.UseSandbox.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.AdditionalHandlingCharge");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.AdditionalHandlingCharge.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesDomestic");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesDomestic.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesInternational");
            _localizationService.DeletePluginLocaleResource("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesInternational.Hint");

            base.Uninstall();
        }

        #endregion

        #region Properties

        public ShippingRateComputationMethodType ShippingRateComputationMethodType =>
            ShippingRateComputationMethodType.Realtime;

        public IShipmentTracker ShipmentTracker => null;

        #endregion
    }
}
