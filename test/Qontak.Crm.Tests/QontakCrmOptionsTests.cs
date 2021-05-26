using Xunit;

namespace Qontak.Crm.Tests
{
    public class QontakCrmOptionsTests
    {
        public QontakCrmOptionsTests()
        {
            Options = new QontakCrmOptions();
        }

        public QontakCrmOptions Options { get; set; }

        [Fact]
        public void QontakCrmOptionsTest_IsRunning()
        {
            Assert.True(true, userMessage: "QontakCrmOptionsTests running good");
        }

        [Fact]
        public void QontakCrmOption_Construct_DefaultValueAuthenticationTypeMustBeBasic()
        {
            Assert.Equal(expected: QontakCrmAuthenticationType.Basic, Options.AuthenticationType);
        }
    }
}
