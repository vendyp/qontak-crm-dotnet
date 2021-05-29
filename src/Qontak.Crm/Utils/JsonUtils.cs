using System;
using System.IO;
using Newtonsoft.Json;

namespace Qontak.Crm
{
    public static class JsonUtils
    {
        public static T DeserializeObject<T>(
            string value,
            JsonSerializerSettings settings = null)
        {
            return (T)DeserializeObject(value, typeof(T), settings);
        }

        public static object DeserializeObject(
                    string value,
                    Type type,
                    JsonSerializerSettings settings = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            JsonSerializer jsonSerializer = JsonSerializer.Create(settings);

            using (JsonTextReader reader = new JsonTextReader(new StringReader(value)))
            {
                return jsonSerializer.Deserialize(reader, type);
            }
        }
    }
}
