namespace Qontak.Crm
{
    public interface IPropertyFieldValidator
    {
        ValidationResult Validate(object value);
    }
}
