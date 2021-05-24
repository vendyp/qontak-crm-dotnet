using System;
using System.Text.Json.Serialization;
using VP.Qontak.Crm.Common;

namespace VP.Qontak.Crm.Models
{
    public class RequestToken
    {
        public bool IsExpired => DateTime.UtcNow > DateTimeHelper.UnixTimeStampToDateTimeUtc(CreatedAt + ExpiresIn);

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }
    }
}