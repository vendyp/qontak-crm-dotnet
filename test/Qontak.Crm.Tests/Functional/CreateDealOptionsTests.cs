using Xunit;

namespace Qontak.Crm.Tests.Functional
{
    public class CreateDealOptionsTests
    {
        [Fact]
        public void CreateDealOptions_Init_Currency_Default_IDR()
        {
            var ctr = CreateDealOptionsConstruction.Create();

            Assert.Equal(expected: "IDR", actual: ctr.Currency);
        }

        [Fact]
        public void CreateDealOptions_Init_AdditionalFields_Not_Null()
        {
            var ctr = CreateDealOptionsConstruction.Create();

            Assert.NotNull(ctr.AdditionalFields);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2382, 217231)]
        public void CreateDealOptions_Init_PipelineId_MustExact(int pipelineId, int stageId)
        {
            var ctr = CreateDealOptionsConstruction.Create(pipelineId, stageId);

            Assert.Equal(expected: pipelineId, actual: ctr.PipelineId);
            Assert.Equal(expected: stageId, actual: ctr.StageId);
        }
    }
}
