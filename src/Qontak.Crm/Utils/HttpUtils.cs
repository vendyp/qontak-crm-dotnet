using System.Linq;
using System.Net.Http.Headers;

namespace Qontak.Crm.Utils
{
    public static class HttpUtils
    {
        public static string GetHeaderFirstByKey(this HttpHeaders headers, string key)
        {
            if (headers == null || !(headers.Contains(key))) return null;

            return headers.GetValues(key).First();
        }
    }
}
