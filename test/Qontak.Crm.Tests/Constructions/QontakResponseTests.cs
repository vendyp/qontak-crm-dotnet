using System.Net;
using System.Net.Http;
using Qontak.Crm.Infrastructure;
using Qontak.Crm.Utils;
using Xunit;

namespace Qontak.Crm.Tests.Constructions
{
    public class QontakResponseTests
    {
        [Fact]
        public void QontakResponse_Init_ShouldMatch()
        {
            var statusCode = HttpStatusCode.OK;
            var content = "string";
            var headerKey = "test";
            var headerValue = "test123";
            var message = new HttpResponseMessage();
            message.Headers.Add(headerKey, headerValue);

            var ctr = new QontakResponse(statusCode, message.Headers, content);

            Assert.Equal(expected: statusCode, actual: ctr.HttpStatusCode);
            Assert.Equal(expected: content, actual: ctr.Content);
            Assert.Equal(expected: headerValue, actual: ctr.Headers.GetHeaderFirstByKey(headerKey));
        }
    }
}
