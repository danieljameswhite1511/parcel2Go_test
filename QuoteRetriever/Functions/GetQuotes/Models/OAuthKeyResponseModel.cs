using Newtonsoft.Json;

namespace QuoteRetriever.Functions.GetQuotes.Models
{
    public class OAuthKeyResponseModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
