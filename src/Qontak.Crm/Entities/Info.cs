using System.Collections.Generic;
using Newtonsoft.Json;

namespace Qontak.Crm
{
    public class Info : IQontakCrmEntity
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_alias")]
        public string NameAlias { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("additional_field")]
        public bool AdditionalField { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("dropdown")]
        public List<Dropdown> Dropdown { get; set; }
    }
}
