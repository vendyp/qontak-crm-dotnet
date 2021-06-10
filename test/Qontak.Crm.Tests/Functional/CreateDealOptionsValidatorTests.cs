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

        private const int StageId = 12;
        private const int PipelineId = 132;

        private static List<Info> DataTest = new List<Info>
        {
            new Info
            {
                Id = 1,
                Name = TemplateConstant.Name.ToValueString(),
                NameAlias = "Deal Name",
                AdditionalField = false,
                Type = PropertyFieldTypeConstant.SingleLineText,
                RequiredPipelineIds = new int[] {PipelineId},
                RequiredStageIds = new int[]{}
            },
            new Info
            {
                Id = 2,
                Name = TemplateConstant.Currency.ToValueString(),
                NameAlias = "Currency",
                AdditionalField = false,
                Type = PropertyFieldTypeConstant.DropdownSelect,
                Dropdown = new List<Dropdown>
                {
                    new Dropdown
                    {
                        Id = null,
                        Name = "USD"
                    },
                    new Dropdown
                    {
                        Id = null,
                        Name = "IDR"
                    },
                    new Dropdown
                    {
                        Id = null,
                        Name = "SGD"
                    },
                },
                RequiredPipelineIds = new int[] {},
                RequiredStageIds = new int[]{StageId}
            },
        };

        [Fact]
        public void CreateDealOptionsValidator_IsValid_Must_False()
        {
            //Given
            // this should be false, because EUR for this example test, not in Dropdown list
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);
            ctr.Currency = "EUR";

            var validator = new CreateDealOptionsValidator(ctr, DataTest);

            Assert.False(validator.IsValid);
        }

        [Fact]
        public void CreateDealOptionsValidator_GetErrorMessage_Must_Not_Empty_Or_Null()
        {
            //Given
            // this should be false, because EUR for this example test, not in Dropdown list
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);
            ctr.Currency = "EUR";

            var validator = new CreateDealOptionsValidator(ctr, DataTest);

            var errMsg = validator.GetErrorMessage();

            Assert.NotEmpty(errMsg);
        }

        [Fact]
        public void CreateDealOptionsValidator_IsValid_Must_True()
        {
            //Given
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);

            var validator = new CreateDealOptionsValidator(ctr, DataTest);

            Assert.True(validator.IsValid);
        }

        [Fact]
        public void CreateDealOptionsValidator_IsValid_Must_False_Case_Deal_Size_Required_In_Current_Stage()
        {
            //Given
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);

            DataTest.Add(new Info
            {
                Id = 99999,
                Name = TemplateConstant.Size.ToValueString(),
                NameAlias = "Deal Size",
                AdditionalField = false,
                Type = PropertyFieldTypeConstant.Number,
                RequiredPipelineIds = new int[] { },
                RequiredStageIds = new int[] { StageId }
            });

            var validator = new CreateDealOptionsValidator(ctr, DataTest);

            Assert.False(validator.IsValid);
        }
    }
}
