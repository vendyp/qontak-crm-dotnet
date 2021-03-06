using Qontak.Crm.Infrastructure;
using Xunit;

namespace Qontak.Crm.Tests.Constructions
{
    public class QontakRequestTests
    {
        public QontakRequestTests()
        {
            QontakRequest = new QontakRequest();
        }

        public QontakRequest QontakRequest { get; }

        [Fact(Skip = "QontakRequest BaseUrl no longer use")]
        public void QontakRequest_Init_ShouldMatch()
        {
#pragma warning disable 0618
            Assert.Equal(expected: CrmConstant.BaseUrl, actual: QontakRequest.BaseUrl);
#pragma warning restore 0618
        }

        [Fact]
        public void QontakRequest_Init_Content_ShouldNull()
        {
            Assert.Null(QontakRequest.Content);
        }

        [Fact]
        public void QontakRequest_Init_HttpMethod_ShouldNull()
        {
            Assert.Null(QontakRequest.Method);
        }

        [Fact]
        public void QontakRequest_Init_Headers_ShouldNull()
        {
            Assert.Null(QontakRequest.Headers);
        }

        [Fact]
        public void QontakRequest_Init_Uri_ShouldNull()
        {
            Assert.Null(QontakRequest.Uri);
        }
    }
}
