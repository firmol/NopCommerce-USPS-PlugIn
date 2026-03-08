using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nop.Plugin.Shipping.USPS.Domain
{
    /// <summary>
    /// Response from POST /prices/v3/base-rates/search
    /// </summary>
    public class DomesticRateResponse
    {
        [JsonProperty("totalBasePrice")]
        public decimal TotalBasePrice { get; set; }

        [JsonProperty("rates")]
        public List<DomesticRate> Rates { get; set; } = new List<DomesticRate>();

        [JsonProperty("commitment")]
        public RateCommitment Commitment { get; set; }
    }

    public class DomesticRate
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

    public class RateCommitment
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("scheduleDeliveryDate")]
        public string ScheduleDeliveryDate { get; set; }
    }
}
