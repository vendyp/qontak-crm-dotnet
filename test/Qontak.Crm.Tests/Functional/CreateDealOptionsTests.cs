using Xunit;

namespace Qontak.Crm.Tests.Functional
{
    public class CreateDealOptionsTests
    {
        [Fact]
        public void CreateDealOptions_Init_Currency_Default_IDR()
        {
            var ctr = new CreateDealOptions();

            Assert.Equal(expected: "IDR", actual: ctr.Currency);
        }

        [Fact]
        public void CreateDealOptions_Init_AdditionalFields_Not_Null()
        {
            var ctr = new CreateDealOptions();

            Assert.NotNull(ctr.AdditionalFields);
        }
    }
}
