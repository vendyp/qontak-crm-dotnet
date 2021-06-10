using Xunit;

namespace Qontak.Crm.Tests.Constructions
{
    public class TemplateNameAttributeTests
    {
        [Theory]
        [InlineData(TemplateConstant.Currency)]
        [InlineData(TemplateConstant.Name)]
        public void TemplateNameAttribute_Init_With_Name_Should_Exact(TemplateConstant constant)
        {
            var ctr = new TemplateNameAttribute(constant);

            Assert.Equal(expected: constant.ToValueString(), actual: ctr.Name);
        }
    }
}
