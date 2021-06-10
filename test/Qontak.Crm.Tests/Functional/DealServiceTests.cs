using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Qontak.Crm.Tests.Functional
{
    public class DealServiceTests
    {
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
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Info>());

            Assert.NotNull(ctr.BasePath);
            Assert.True(!string.IsNullOrWhiteSpace(ctr.BasePath));
        }

        [Fact]
        public void DealService_BasePath_MustCorrectValue()
        {
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Info>());

            Assert.Equal(expected: "deals", actual: ctr.BasePath);
        }

        [Fact]
        public void DealService_Infoes_MustNull_When_FirstTimeCreation()
        {
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Info>());

            Assert.Null(ctr.Infoes);
        }

        [Fact]
        public async Task DealService_GetInfoAsync_ShouldCall_RequestListAsync()
        {
            var moq = MockCrmClient.GetMockedObjectOfCrmClient<Info>();

            // init service
            var ctr = new DealService(moq);

            await ctr.GetInfosAsync(CancellationToken.None);

            Mock.Get(moq).Verify(x => x.RequestListAsync<Info>(
              HttpMethod.Get,
              "deals/info",
              null,
              CancellationToken.None),
              Times.Once);
        }

        [Fact]
        public async Task DealService_Infoes_MustNotNull_After_GetInfoAsync_Being_CalledAsync()
        {
            // init service
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Info>());

            await ctr.GetInfosAsync(CancellationToken.None);

            Assert.NotNull(ctr.Infoes);
        }

        [Fact]
        public void DealService_HasMethod_CreateAsync()
        {
            // init service
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Info>());
            var type = ctr.GetType();

            Assert.NotNull(type.GetMethod("CreateDealAsync"));
        }
    }
}
