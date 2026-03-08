using Newtonsoft.Json;

namespace Nop.Plugin.Shipping.USPS.Domain
{
    /// <summary>
    /// Request body for POST /prices/v3/base-rates/search
    /// </summary>
    public class DomesticRateRequest
    {
        [JsonProperty("originZIPCode")]
        public string OriginZIPCode { get; set; }

        [JsonProperty("destinationZIPCode")]
        public string DestinationZIPCode { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }

        [JsonProperty("length")]
        public decimal Length { get; set; }

        [JsonProperty("width")]
        public decimal Width { get; set; }

        [JsonProperty("height")]
        public decimal Height { get; set; }

        [JsonProperty("mailClass")]
        public string MailClass { get; set; }

        [JsonProperty("processingCategory")]
        public string ProcessingCategory { get; set; }

        [JsonProperty("destinationEntryFacilityType")]
        public string DestinationEntryFacilityType { get; set; }

        [JsonProperty("rateIndicator")]
        public string RateIndicator { get; set; }

        [JsonProperty("priceType")]
        public string PriceType { get; set; }

        [JsonProperty("mailingDate")]
        public string MailingDate { get; set; }
    }
}
