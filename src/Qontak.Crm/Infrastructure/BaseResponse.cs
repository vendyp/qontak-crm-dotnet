using Newtonsoft.Json;

namespace Qontak.Crm
{
    public class BaseResponse<T>
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("response")]
        public T Data { get; set; }

        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("total_page")]
        public int? TotalPage { get; set; }

        [JsonProperty("current_data")]
        public int? CurrentData { get; set; }

        [JsonProperty("total_data")]
        public int? TotalData { get; set; }
    }
}
