namespace Qontak.Crm
{
    public class QontakCrmOptions
    {
        public QontakCrmOptions()
        {
            AuthenticationType = QontakCrmAuthenticationType.Basic;
        }

        /// <summary>
        /// Default is Basic.
        /// </summary>
        /// <value></value>
        public QontakCrmAuthenticationType AuthenticationType { get; set; }

        /// <summary>
        /// Crm username qontak
        /// </summary>
        /// <value></value>
        public string CrmUsername { get; set; }

        /// <summary>
        /// Crm password qontak
        /// </summary>
        /// <value></value>
        public string CrmPassword { get; set; }

        /// <summary>
        /// Pipeline name used for Deal
        /// </summary>
        /// <value></value>
        public string DealPipelineName { get; set; }

        /// <summary>
        /// Stage names within selected pipelines names
        /// </summary>
        /// <value></value>
        public string[] DealStageNames { get; set; }
    }
}
