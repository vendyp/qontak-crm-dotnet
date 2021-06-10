using System;
using System.Collections.Generic;
using Xunit;

namespace Qontak.Crm.Tests.Functional
{
    public class CreateDealOptionsValidatorTests
    {
        [Fact]
        public void CreateDealOptionsValidator_Init_Should_Throw()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CreateDealOptionsValidator(null, null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                new CreateDealOptionsValidator(
                    CreateDealOptionsConstruction.Create(), 
                    new List<Info>());
            });
        }
    }
}
