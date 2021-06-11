namespace Qontak.Crm
{
    public class AdditionalField
    {
        public AdditionalField(string name, object value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            Name = name;
            Value = value ?? throw new System.ArgumentNullException(nameof(value));
        }

        public string Name { get; set; }

        public object Value { get; set; }
    }
}
