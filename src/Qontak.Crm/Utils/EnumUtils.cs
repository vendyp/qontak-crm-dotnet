using System;

namespace Qontak.Crm
{
    public static class EnumUtils
    {
        public static string ToValueString<T>(this T val) where T : Enum
        {
            var attributes = (EnumValueAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(EnumValueAttribute), false);

            return attributes.Length > 0 ? attributes[0].Value : val.ToString();
        }
    }
}
