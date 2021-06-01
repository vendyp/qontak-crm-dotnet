using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Qontak.Crm.Constants;
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

            await ctr.GetInfoAsync(CancellationToken.None);

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

            await ctr.GetInfoAsync(CancellationToken.None);

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

        [Fact]
        public void DealService_ValidateRequiredOptions_ThrowArgumentNullException_When_Only_Options_IsNull()
        {
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Deal>());

            Assert.Throws<ArgumentNullException>(() =>
            {
                ctr.DefaultValidationRequiredOptions(null, DealInfoConstruction.GetInfoesDummy());
            });
        }

        [Fact]
        public void DealService_ValidateRequiredOptions_ThrowArgumentNullException_When_Only_Infoes_IsNull()
        {
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Deal>());

            Assert.Throws<ArgumentNullException>(() =>
            {
                ctr.DefaultValidationRequiredOptions(CreateDealOptionsConstruction.Create(), null);
            });
        }

        [Fact]
        public void DealService_ValidateRequiredOptions_ThrowArgumentNullException_When_Infoes_IsEmpty()
        {
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Deal>());

            Assert.Throws<ArgumentNullException>(() =>
            {
                ctr.DefaultValidationRequiredOptions(CreateDealOptionsConstruction.Create(), new List<Info>());
            });
        }

        [Fact]
        public void DealService_ValidateRequiredOptions_ThrowArgumentNullException_When_CreatorInfo_Dropdown_IsNull()
        {
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Deal>());

            var options = CreateDealOptionsConstruction.Create();
            var list = new List<Info>();
            list.Add(new Info
            {
                Id = 1,
                Name = TemplateConstant.Name,
                Dropdown = null
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                ctr.DefaultValidationRequiredOptions(options, list);
            });
        }

        [Fact]
        public void DealService_ValidateRequiredOptions_ThrowArgumentNullException_When_CreatorInfo_Dropdown_Value_NotFound()
        {
            var ctr = new DealService(MockCrmClient.GetMockedObjectOfCrmClient<Deal>());

            var options = CreateDealOptionsConstruction.Create();
            var list = new List<Info>();
            list.Add(new Info
            {
                Id = 1,
                Name = TemplateConstant.Name,
                Dropdown = new List<Dropdown>
                {
                    new Dropdown
                    {
                        Id = 15,
                        Name = "Lorep"
                    }
                }
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                ctr.DefaultValidationRequiredOptions(options, list);
            });
        }
    }
}
