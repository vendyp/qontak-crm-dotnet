namespace Qontak.Crm
{
    public class TextAreaValidator : IPropertyFieldValidator
    {
        public ValidationResult Validate(object value)
        {
            var result = new ValidationResult();

            if (!(value is string))
            {
                result.IsValid = false;
                result.ErrorMessage = "Value type must be a string";
            }

            return result;
        }
    }
}
