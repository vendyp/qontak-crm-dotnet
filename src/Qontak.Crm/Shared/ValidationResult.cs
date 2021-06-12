namespace Qontak.Crm
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            IsValid = true;
            ErrorMessage = null;
        }

        /// <summary>
        /// Default is true
        /// </summary>
        /// <value></value>
        public bool IsValid { get; set; }

        /// <summary>
        /// Default is null
        /// </summary>
        /// <value></value>
        public string ErrorMessage { get; set; }
    }
}
