using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Qontak.Crm.Infrastructure
{
    public class QontakRequest
    {
        public QontakRequest()
        {

        }

        public QontakRequest(Uri uri, HttpMethod method, HttpContent content, Dictionary<string, string> headers)
        {
            Uri = uri;
            Method = method;
            Content = content;
            Headers = headers;
        }

        public string BaseUrl => CrmConstant.BaseUrl;

        public Uri Uri { get; set; }
        public HttpMethod Method { get; set; }
        public HttpContent Content { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
