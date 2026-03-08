using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nop.Plugin.Shipping.USPS.Domain
{
    /// <summary>
    /// Response from POST /international-prices/v3/base-rates/search
    /// </summary>
    public class InternationalRateResponse
    {
        [JsonProperty("totalBasePrice")]
        public decimal TotalBasePrice { get; set; }

        [JsonProperty("rates")]
        public List<InternationalRate> Rates { get; set; } = new List<InternationalRate>();
    }

    public class InternationalRate
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("mailClass")]
        public string MailClass { get; set; }

        [JsonProperty("priceType")]
        public string PriceType { get; set; }
    }
}
