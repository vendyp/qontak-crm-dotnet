using System;

namespace Qontak.Crm
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        public string Value { get; }
    }
}
