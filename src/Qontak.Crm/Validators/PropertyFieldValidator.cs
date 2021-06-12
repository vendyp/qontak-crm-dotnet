namespace Qontak.Crm
{
    public class PropertyFieldValidator
    {
        private readonly PropertyValidatorManager _manager;

        private PropertyFieldValidator()
        {
            _manager = new PropertyValidatorManager();
        }

        public ValidationResult Validate(object value, string type)
        {
            var validator = _manager.GetPropertyFieldValidator(type);
            if (validator == null)
                throw new QontakCrmException($"Type \"{type}\" is not supported property");

            return validator.Validate(value);
        }
        private static PropertyFieldValidator instance = null;
        public static PropertyFieldValidator GetInstance()
        {
            if (instance == null)
                instance = new PropertyFieldValidator();

            return instance;
        }
    }
}
