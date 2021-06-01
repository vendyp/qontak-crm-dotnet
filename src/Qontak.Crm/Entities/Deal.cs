using System;
using Newtonsoft.Json;

namespace Qontak.Crm
{
    public class Deal : IQontakCrmEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("size")]
        public decimal? Size { get; set; }

        [JsonProperty("closed_date")]
        public DateTime? ClosedDate { get; set; }

        [JsonProperty("creator_id")]
        public int CreatorId { get; set; }

        [JsonProperty("creator_name")]
        public string CreatorName { get; set; }

        [JsonProperty("crm_source_id")]
        public int CrmSourceId { get; set; }

        [JsonProperty("crm_source_name")]
        public string CrmSourceName { get; set; }

        [JsonProperty("crm_lost_reason_id")]
        public int? CrmLostReasonId { get; set; }

        [JsonProperty("crm_lost_reason_name")]
        public string CrmLostReasonName { get; set; }

        [JsonProperty("crm_pipeline_id")]
        public int CrmPipelineId { get; set; }

        [JsonProperty("crm_pipeline_name")]
        public string CrmPipelineName { get; set; }

        [JsonProperty("crm_stage_id")]
        public int CrmStageId { get; set; }

        [JsonProperty("crm_stage_name")]
        public string CrmStageName { get; set; }

        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("expired_date")]
        public DateTime? ExpiredDate { get; set; }

        [JsonProperty("crm_priority_id")]
        public int? CrmPriorityId { get; set; }

        [JsonProperty("crm_priority_name")]
        public string CrmPriorityName { get; set; }

        [JsonProperty("crm_company_id")]
        public int? CrmCompanyId { get; set; }

        [JsonProperty("crm_company_name")]
        public string CrmCompanyName { get; set; }
    }
}
