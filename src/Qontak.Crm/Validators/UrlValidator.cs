using System;

namespace Qontak.Crm
{
    public class UrlValidator : IPropertyFieldValidator
    {
        public ValidationResult Validate(object value)
        {
            var result = new ValidationResult();

            if (!(value is string))
            {
                result.IsValid = false;
                result.ErrorMessage = "Value must be a string";
            }
            else
            {
                var uriName = value.ToString();
                Uri uriResult;
                bool b = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (!b)
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Value must be a valid url";
                }
            }

            return result;
        }
    }
}
