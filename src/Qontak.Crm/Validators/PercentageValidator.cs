namespace Qontak.Crm
{
    public class PercentageValidator : IPropertyFieldValidator
    {
        public ValidationResult Validate(object value)
        {
            var result = new ValidationResult();

            if (!value.IsNumber())
            {
                result.IsValid = false;
                result.ErrorMessage = "Value is not a number";
            }

            return result;
        }
    }
}
