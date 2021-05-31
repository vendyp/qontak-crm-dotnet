namespace Qontak.Crm
{
    public class AdditionalField
    {
        public AdditionalField(int id, object value)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; set; }

        public object Value { get; set; }
    }
}
