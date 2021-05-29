using System.Net;
using System.Net.Http.Headers;

namespace Qontak.Crm.Infrastructure
{
    public class QontakResponse
    {
        public QontakResponse(HttpStatusCode httpStatusCode, HttpHeaders headers, string content)
        {
            HttpStatusCode = httpStatusCode;
            Headers = headers;
            Content = content;
        }

        public HttpStatusCode HttpStatusCode { get; }
        public HttpHeaders Headers { get; }
        public string Content { get; }
    }
}
