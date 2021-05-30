using System;
using Xunit;

namespace Qontak.Crm.Tests.Functional
{
    public class DealServiceTests
    {
        public DealServiceTests()
        {
            CrmOption = new QontakCrmOptions()
            {
                CrmUsername = "Lorep",
                CrmPassword = "Ipsum"
            };

            CrmClient = new QontakCrmClient(CrmOption);

            Services = new DealService(CrmClient);
        }

        public QontakCrmOptions CrmOption { get; }
        public QontakCrmClient CrmClient { get; }
        public DealService Services { get; }

        [Fact]
        public void DealService_Init_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new DealService(null);
            });
        }

        [Fact]
        public void DealService_Type_ShouldDerivedFromBaseService()
        {
            Assert.True(typeof(DealService).IsSubclassOf(typeof(BaseService)),
            userMessage: "DealService should be derived from BaseService");
        }

        [Fact]
        public void DealService_BasePath_MustNotNull()
        {
            Assert.NotNull(Services.BasePath);
            Assert.True(!string.IsNullOrWhiteSpace(Services.BasePath));
        }

        [Fact]
        public void DealService_BasePath_MustCorrectValue()
        {
            Assert.Equal(expected: "deals", actual: Services.BasePath);
        }
    }
}
