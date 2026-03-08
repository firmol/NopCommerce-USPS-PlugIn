namespace Nop.Plugin.Shipping.USPS
{
    public static class USPSShippingDefaults
    {
        // API base URLs
        public const string PRODUCTION_BASE_URL = "https://apis.usps.com";
        public const string SANDBOX_BASE_URL = "https://apis-tem.usps.com";

        // OAuth2 endpoints
        public const string TOKEN_PATH = "/oauth2/v3/token";

        // Pricing endpoints
        public const string DOMESTIC_RATES_PATH = "/prices/v3/base-rates/search";
        public const string INTERNATIONAL_RATES_PATH = "/international-prices/v3/base-rates/search";

        // OAuth scopes
        public const string PRICES_SCOPE = "prices";
        public const string INTERNATIONAL_PRICES_SCOPE = "international-prices";

        // Token cache key
        public const string TOKEN_CACHE_KEY = "usps.oauth2.token";
        public const int TOKEN_CACHE_SECONDS_BUFFER = 60; // refresh 60s before expiry

        // Package limits
        public const decimal MAX_PACKAGE_WEIGHT_LBS = 70M;
        public const string MEASURE_WEIGHT_SYSTEM_KEYWORD = "lb";
        public const string MEASURE_DIMENSION_SYSTEM_KEYWORD = "inches";

        // Domestic mail classes (USPS API v3 values)
        public static readonly string[] DomesticMailClasses = new[]
        {
            "PRIORITY_MAIL_EXPRESS",
            "PRIORITY_MAIL",
            "USPS_GROUND_ADVANTAGE",
            "FIRST-CLASS_PACKAGE_SERVICE",
            "MEDIA_MAIL",
            "LIBRARY_MAIL",
            "PARCEL_SELECT"
        };

        // International mail classes (USPS API v3 values)
        public static readonly string[] InternationalMailClasses = new[]
        {
            "PRIORITY_MAIL_EXPRESS_INTERNATIONAL",
            "PRIORITY_MAIL_INTERNATIONAL",
            "FIRST-CLASS_PACKAGE_INTERNATIONAL_SERVICE"
        };

        // Human-readable names for display
        public static string GetDomesticDisplayName(string mailClass)
        {
            switch (mailClass)
            {
                case "PRIORITY_MAIL_EXPRESS":       return "Priority Mail Express";
                case "PRIORITY_MAIL":               return "Priority Mail";
                case "USPS_GROUND_ADVANTAGE":       return "USPS Ground Advantage";
                case "FIRST-CLASS_PACKAGE_SERVICE": return "First-Class Package Service";
                case "MEDIA_MAIL":                  return "Media Mail";
                case "LIBRARY_MAIL":                return "Library Mail";
                case "PARCEL_SELECT":               return "Parcel Select";
                default:                            return mailClass;
            }
        }

        public static string GetInternationalDisplayName(string mailClass)
        {
            switch (mailClass)
            {
                case "PRIORITY_MAIL_EXPRESS_INTERNATIONAL":       return "Priority Mail Express International";
                case "PRIORITY_MAIL_INTERNATIONAL":               return "Priority Mail International";
                case "FIRST-CLASS_PACKAGE_INTERNATIONAL_SERVICE": return "First-Class Package International Service";
                default:                                          return mailClass;
            }
        }
    }
}
