using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Qontak.Crm.Tests.Functional
{
    public class AdditionalFieldValidatorTests
    {
        public const int StageId = 72176;
        public const int PipelineId = 182321;

        #region Initialization
        [Fact]
        public void AdditionalFieldValidator_Init_Infoes_Count_Must_Exact()
        {
            //Given
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);
            var validator = new AdditionalFieldValidator(ctr.PipelineId, ctr.StageId, ctr.AdditionalFields, DataInfoTestForDeal);
            var validator2 = new AdditionalFieldValidator(ctr.PipelineId, ctr.StageId, ctr.AdditionalFields, DataInfoTestForNonDeal);

            Assert.Equal(expected: DataInfoTestForDeal.Where(x => x.AdditionalField).Count(), actual: validator.GetAdditionalInfos().Count());
            Assert.Equal(expected: DataInfoTestForNonDeal.Where(x => x.AdditionalField).Count(), actual: validator2.GetAdditionalInfos().Count());
        }

        [Fact]
        public void AdditionalFieldValidator_Init_Should_Throw_When_Pass_Invalid_Args_Infoes_Empty_Of_Constructor_Params_With_Pipeline_And_Stage()
        {
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var validator = new AdditionalFieldValidator(ctr.PipelineId, ctr.StageId, ctr.AdditionalFields, new List<Info>());
            });
        }

        [Fact]
        public void AdditionalFieldValidator_Init_Should_Throw_When_Pass_Invalid_Args_Infoes_Null_Of_Constructor_Params_With_Pipeline_And_Stage()
        {
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var validator = new AdditionalFieldValidator(ctr.PipelineId, ctr.StageId, ctr.AdditionalFields, null);
            });
        }

        [Fact]
        public void AdditionalFieldValidator_Init_Should_Throw_When_Pass_Invalid_Args_Infoes_Empty_Of_Constructor_Only_Additional_Fields()
        {
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var validator = new AdditionalFieldValidator(ctr.AdditionalFields, new List<Info>());
            });
        }

        [Fact]
        public void AdditionalFieldValidator_Init_Should_Throw_When_Pass_Invalid_Args_Infoes_Null_Of_Constructor_Only_Additional_Fields()
        {
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var validator = new AdditionalFieldValidator(ctr.AdditionalFields, null);
            });
        }

        /// <summary>
        /// This should throw an CrmException when given infos required properties is null.
        /// Especially RequiredStage or RequiredPipeline
        /// </summary>
        [Fact]
        public void AdditionalFieldValidator_Init_Should_Throw_CrmException_When_Info_OneOf_Property_RequiredStage_IsNull_ConstructionWithPipelineAndStageId()
        {
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);

            var dataTest = new List<Info>();
            dataTest.AddRange(DataInfoTestForDeal);
            dataTest.Add(new Info
            {
                Id = 2,
                Name = "test_name_only",
                NameAlias = "Test Only",
                AdditionalField = true,
                Type = PropertyFieldTypeConstant.SingleLineText,
                RequiredPipelineIds = new int[] { PipelineId },
                RequiredStageIds = null
            });

            var validator = new AdditionalFieldValidator(ctr.PipelineId, ctr.StageId, ctr.AdditionalFields, dataTest);

            Assert.Throws<QontakCrmException>(() =>
            {
                validator.ValidateInfos();
            });
        }

        [Fact]
        public void AdditionalFieldValidator_Init_Should_Throw_CrmException_When_Info_OneOf_Property_RequiredPipeline_IsNull_ConstructionWithPipelineAndStageId()
        {
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);

            var dataTest = new List<Info>();
            dataTest.AddRange(DataInfoTestForDeal);
            dataTest.Add(new Info
            {
                Id = 2,
                Name = "test_name_only",
                NameAlias = "Test Only",
                AdditionalField = true,
                Type = PropertyFieldTypeConstant.SingleLineText,
                RequiredPipelineIds = null,
                RequiredStageIds = new int[] { }
            });

            var validator = new AdditionalFieldValidator(ctr.PipelineId, ctr.StageId, ctr.AdditionalFields, dataTest);

            Assert.Throws<QontakCrmException>(() =>
            {
                validator.ValidateInfos();
            });
        }
        #endregion

        #region Deal test section
        private static List<Info> DataInfoTestForDeal = new List<Info>
        {
            new Info
            {
                Id = 1,
                Name = "test_url",
                NameAlias = "Url Name",
                AdditionalField = true,
                Type = PropertyFieldTypeConstant.URL,
                RequiredPipelineIds = new int[] {PipelineId},
                RequiredStageIds = new int[]{}
            },
            new Info
            {
                Id = 2,
                Name = "test_category_name",
                NameAlias = "Category name",
                AdditionalField = true,
                Type = PropertyFieldTypeConstant.SingleLineText,
                RequiredPipelineIds = new int[] {PipelineId},
                RequiredStageIds = new int[]{}
            },
        };

        /// <summary>
        /// This should be false, because given create deal options has no additional fields, 
        /// when one of data test is required on current pipeline id
        /// </summary>
        [Fact]
        public void AdditionalFieldValidator_Deal_Should_False__And_ErrMsg_NotEmptyWith_DataTest_Case_One()
        {
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);
            var validator = new AdditionalFieldValidator(ctr.PipelineId, ctr.StageId, ctr.AdditionalFields, DataInfoTestForDeal);

            var errMsg = validator.GetErrorMessage();

            Assert.False(validator.IsValid);
            Assert.NotEmpty(errMsg);
        }

        /// <summary>
        /// This should be false, because given create deal options has required additional info
        /// but the value is not match with the info`s type
        /// 
        /// in this case, name test_url is a URL type, but the input is plain string
        /// </summary>
        [Fact]
        public void AdditionalFieldValidator_Deal_Should_False_And_ErrMsg_NotEmpty_False_With_DataTest_Case_Two()
        {
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);
            ctr.AdditionalFields.Add(new AdditionalField("test_url", "stackoverflow dot com"));
            ctr.AdditionalFields.Add(new AdditionalField("test_category_name", "Lorep Ipsum"));

            var validator = new AdditionalFieldValidator(ctr.PipelineId, ctr.StageId, ctr.AdditionalFields, DataInfoTestForDeal);

            var errMsg = validator.GetErrorMessage();

            Assert.False(validator.IsValid);
            Assert.NotEmpty(errMsg);
        }

        [Fact]
        public void AdditionalFieldValidator_Deal_Should_True()
        {
            var ctr = CreateDealOptionsConstruction.CreateDealDummy(PipelineId, StageId);
            ctr.AdditionalFields.Add(new AdditionalField("test_url", "https://github.com/VendyP"));
            ctr.AdditionalFields.Add(new AdditionalField("test_category_name", "Lorep Ipsum"));

            var validator = new AdditionalFieldValidator(ctr.PipelineId, ctr.StageId, ctr.AdditionalFields, DataInfoTestForDeal);

            var result = validator.IsValid;
            var errMsg = validator.GetErrorMessage();

            Assert.True(result);
            Assert.Null(errMsg);
        }
        #endregion

        #region  Non deal test
        private static List<Info> DataInfoTestForNonDeal = new List<Info>
        {
            new Info
            {
                Id = 1,
                Name = TemplateConstant.Name.ToValueString(),
                NameAlias = "Deal Name",
                AdditionalField = false,
                Type = PropertyFieldTypeConstant.SingleLineText
            },
        };
        #endregion
    }
}
