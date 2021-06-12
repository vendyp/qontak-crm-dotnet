namespace Qontak.Crm
{
    public class DropdownSelectValidator : IPropertyFieldValidator
    {
        public ValidationResult Validate(object value)
        {
            var result = new ValidationResult();

            if (!(value is string || value.IsNumber()))
            {
                result.IsValid = false;
                result.ErrorMessage = "Value must be a string or number";
            }

            return result;
        }
    }
}
