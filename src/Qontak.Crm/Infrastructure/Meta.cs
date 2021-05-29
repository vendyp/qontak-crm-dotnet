using System;
using Newtonsoft.Json;

namespace Qontak.Crm
{
    public class Meta
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("error_code")]
        public object ErrorCode { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("developer_message")]
        public string DeveloperMessage { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("log_id")]
        public string LogId { get; set; }
    }
}
