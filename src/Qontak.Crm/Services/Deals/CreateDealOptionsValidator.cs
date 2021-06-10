using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Qontak.Crm
{
    public class CreateDealOptionsValidator
    {
        private readonly CreateDealOptions _options;
        private readonly IEnumerable<Info> _infoes;

        public CreateDealOptionsValidator(CreateDealOptions options, IEnumerable<Info> infoes)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (infoes is null || infoes.Count() < 1)
            {
                throw new ArgumentNullException(nameof(infoes));
            }
            _options = options;
            _infoes = infoes;
        }

        public bool IsValid => IsValidated();

        private string ErrorMessages { get; set; }

        public string GetErrorMessage()
        {
            if (!IsValid)
                return ErrorMessages;

            return null;
        }

        /// <summary>
        /// Default return true
        /// </summary>
        /// <returns></returns>
        private bool IsValidated()
        {
            var type = _options.GetType();
            var properties = type.GetProperties();

            bool result = true;

            foreach (var propertyInfo in properties)
            {
                var templateNameAttr = propertyInfo.GetCustomAttribute<TemplateNameAttribute>();
                if (templateNameAttr == null)
                    continue;

                var propertyValue = propertyInfo.GetValue(_options);

                bool dropdownByName = propertyInfo.GetCustomAttribute<DropdownByNameAttribute>() != null;

                var info = _infoes.Where(x => x.Name == templateNameAttr.Name).FirstOrDefault();
                if (info == null)
                    continue;

                bool requiredInStageId = info.RequiredStageIds.Any(x => x == _options.StageId);
                bool requiredInPipelineId = info.RequiredPipelineIds.Any(x => x == _options.PipelineId);

                string errMsgTemplate = "";
                if (requiredInPipelineId && requiredInStageId)
                    errMsgTemplate = "current stage and pipeline";

                if (requiredInPipelineId)
                    errMsgTemplate = "current pipeline";

                if (requiredInStageId)
                    errMsgTemplate = "current stage";

                if (requiredInPipelineId || requiredInStageId)
                {
                    if (info.Type == PropertyFieldTypeConstant.DropdownSelect)
                    {
                        if (info.Dropdown == null || !info.Dropdown.Any())
                            throw new ArgumentException($"Info template name {info.Name}`s dropdown can not be null or empty");

                        #region  Dropdown select
                        if (dropdownByName)
                        {
                            if (string.IsNullOrWhiteSpace(propertyValue.ToString()))
                                ErrorMessages += $"Property {propertyInfo.Name} is required in {errMsgTemplate};";

                            if (!info.Dropdown.Any(x => x.Name == propertyValue.ToString()))
                            {
                                result = false;
                                ErrorMessages += $"{propertyInfo.Name} value \"{propertyValue.ToString()}\" not found within template info;";
                            }
                        }
                        else
                        {
                            if (propertyValue is int)
                            {
                                if (!info.Dropdown.Any(x => x.Id == (int)propertyValue))
                                {
                                    result = false;
                                    ErrorMessages += $"Property {propertyInfo.Name} is required in {errMsgTemplate};";
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Property value must int or number");
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(propertyValue?.ToString()))
                        {
                            result = false;
                            ErrorMessages += $"Property {propertyInfo.Name} is required in {errMsgTemplate};";
                        }
                    }
                }
                else
                {
                    continue;
                }
            }

            if (!string.IsNullOrWhiteSpace(ErrorMessages))
                ErrorMessages = ErrorMessages.Remove(ErrorMessages.Length - 1);

            return result;
        }
    }
}
