using Newtonsoft.Json;

namespace Qontak.Crm
{
    public class Dropdown
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
