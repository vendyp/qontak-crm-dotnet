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
        public bool? Required { get; set; }

        [JsonProperty("additional_field")]
        public bool AdditionalField { get; set; }

        /// <summary>
        /// Info type. List of this is from PropertyFieldTypeConstant.cs
        /// </summary>
        /// <value></value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Dropdown may not null when Type equal to Dropdown
        /// </summary>
        /// <value></value>
        [JsonProperty("dropdown")]
        public List<Dropdown> Dropdown { get; set; }

        /// <summary>
        /// This field only be use in Deal
        /// </summary>
        /// <value></value>
        [JsonProperty("required_pipeline_ids")]
        public int[] RequiredPipelineIds { get; set; }

        /// <summary>
        /// This field only be use in Deal
        /// </summary>
        /// <value></value>
        [JsonProperty("required_stage_ids")]
        public int[] RequiredStageIds { get; set; }
    }
}
