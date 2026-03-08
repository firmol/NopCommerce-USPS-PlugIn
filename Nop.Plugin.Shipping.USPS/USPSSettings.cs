using Nop.Core.Configuration;

namespace Nop.Plugin.Shipping.USPS
{
    public class USPSSettings : ISettings
    {
        /// <summary>
        /// OAuth2 Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// OAuth2 Client Secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Use sandbox (testing) environment
        /// </summary>
        public bool UseSandbox { get; set; }

        /// <summary>
        /// Additional handling charge added to every rate
        /// </summary>
        public decimal AdditionalHandlingCharge { get; set; }

        /// <summary>
        /// Comma/bracket delimited list of domestic service mail class codes offered
        /// e.g. "[PRIORITY_MAIL]:[USPS_GROUND_ADVANTAGE]:"
        /// </summary>
        public string CarrierServicesOfferedDomestic { get; set; }

        /// <summary>
        /// Comma/bracket delimited list of international service mail class codes offered
        /// e.g. "[PRIORITY_MAIL_INTERNATIONAL]:[FIRST-CLASS_PACKAGE_INTERNATIONAL_SERVICE]:"
        /// </summary>
        public string CarrierServicesOfferedInternational { get; set; }
    }
}
