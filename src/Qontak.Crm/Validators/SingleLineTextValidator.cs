namespace Qontak.Crm
{
    public class SingleLineTextValidator : IPropertyFieldValidator
    {
        public ValidationResult Validate(object value)
        {
            var result = new ValidationResult();

            if (value != null)
                if (!(value is string))
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Value must a string";
                }

            return result;
        }
    }
}
