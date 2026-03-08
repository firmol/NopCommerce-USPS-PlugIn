using Newtonsoft.Json;

namespace Nop.Plugin.Shipping.USPS.Domain
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("issued_at")]
        public string IssuedAt { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}
