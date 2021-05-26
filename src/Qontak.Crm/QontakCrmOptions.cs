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
        public string CrmUsername { get; set; }
        public string CrmPassword { get; set; }
    }
}
