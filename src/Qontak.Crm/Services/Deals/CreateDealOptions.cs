using System;
using System.Collections.Generic;

namespace Qontak.Crm
{
    public class CreateDealOptions
    {
        public CreateDealOptions()
        {
            Currency = "IDR";
            AdditionalFields = new List<AdditionalField>();
        }

        /// <summary>
        /// Name of deal
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Currency of deal. Default is IDR
        /// </summary>
        /// <value></value>
        public string Currency { get; set; }

        /// <summary>
        /// Currency value, with conversion maximum 2 digts after coma, any number after that will be rounded.
        /// </summary>
        /// <value></value>
        public decimal? CurrencyValue { get; set; }

        /// <summary>
        /// Closed date of deal
        /// </summary>
        /// <value></value>
        public DateTime? ClosedDate { get; set; }

        /// <summary>
        /// Source of deal
        /// </summary>
        /// <value></value>
        public int? SourceId { get; set; }

        /// <summary>
        /// Lost reason of deal
        /// </summary>
        /// <value></value>
        public int? LostReasonId { get; set; }

        // this value will be default from CrmOptions
        //public int PipelineId {get;set;}

        /// <summary>
        /// Selected stage from pipeline
        /// </summary>
        /// <value></value>
        public int StageId { get; set; }

        /// <summary>
        /// Start date of deal
        /// </summary>
        /// <value></value>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Expired date of deal
        /// </summary>
        /// <value></value>
        public DateTime? ExpiredDate { get; set; }

        /// <summary>
        /// Selected priority of deal
        /// </summary>
        /// <value></value>
        public int? PriorityId { get; set; }

        /// <summary>
        /// Selected company of deal
        /// </summary>
        /// <value></value>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Selected lead ids. Default is null
        /// </summary>
        /// <value></value>
        public int[] LeadIds { get; set; }

        public List<AdditionalField> AdditionalFields { get; }
    }
}