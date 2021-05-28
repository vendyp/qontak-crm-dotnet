using Newtonsoft.Json;

namespace Qontak.Crm
{
    public class RequestToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }
}
