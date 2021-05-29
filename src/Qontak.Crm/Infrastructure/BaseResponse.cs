using Newtonsoft.Json;

namespace Qontak.Crm
{
    public class BaseResponse<T>
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("response")]
        public T Data { get; set; }
    }
}
