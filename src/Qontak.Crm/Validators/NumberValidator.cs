namespace Qontak.Crm
{
    public class NumberValidator : IPropertyFieldValidator
    {
        public ValidationResult Validate(object value)
        {
            var result = new ValidationResult();

            if (!value.IsNumber())
            {
                result.IsValid = false;
                result.ErrorMessage = "Value must be number";
            }

            return result;
        }
    }
}
