using System;
using System.Collections.Generic;
using System.Linq;

namespace Qontak.Crm
{
    public class AdditionalFieldValidator
    {
        private readonly int? _currentPipelineId;
        private readonly int? _currentStageId;
        private readonly List<AdditionalField> _additionalFields;
        private readonly List<Info> _infoes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="additionalFields"></param>
        /// <param name="infoes"></param>
        public AdditionalFieldValidator(
            List<AdditionalField> additionalFields,
            List<Info> infoes)
        {
            if (additionalFields is null)
            {
                throw new ArgumentNullException(nameof(additionalFields));
            }

            if (infoes is null || !infoes.Any())
            {
                throw new ArgumentNullException(nameof(infoes));
            }

            _additionalFields = additionalFields;
            _infoes = infoes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPipelineId"></param>
        /// <param name="currentStageId"></param>
        /// <param name="additionalFields"></param>
        /// <param name="infoes"></param>
        /// <returns></returns>
        public AdditionalFieldValidator(
            int currentPipelineId,
            int currentStageId,
            List<AdditionalField> additionalFields,
            List<Info> infoes) : this(additionalFields, infoes)
        {
            _currentPipelineId = currentPipelineId;
            _currentStageId = currentStageId;
        }

        public bool IsValid => IsValidated();

        public List<Info> GetAdditionalInfos()
        {
            return _infoes.Where(x => x.AdditionalField).ToList();
        }

        private bool? _result;

        /// <summary>
        /// Default return true
        /// </summary>
        /// <returns></returns>
        private bool IsValidated()
        {
            //prevent always do the logic
            if (_result.HasValue)
                return _result.Value;

            bool result = true;

            if (!_infoes.Any(x => x.AdditionalField))
            {
                _result = result;
                return result;
            }

            ValidateInfos();

            foreach (var info in GetAdditionalInfos())
            {
                if (_currentPipelineId.HasValue && _currentStageId.HasValue)
                {
                    bool requiredInStageId = info.RequiredStageIds.Any(x => x == _currentStageId);
                    bool requiredInPipelineId = info.RequiredPipelineIds.Any(x => x == _currentPipelineId);
                    if (!requiredInPipelineId && !requiredInStageId)
                        continue;

                    string errMsgTemplate = "";
                    if (requiredInPipelineId && requiredInStageId)
                        errMsgTemplate = "current stage and pipeline";

                    if (requiredInPipelineId)
                        errMsgTemplate = "current pipeline";

                    if (requiredInStageId)
                        errMsgTemplate = "current stage";

                    if (!_additionalFields.Any(x => x.Name == info.Name && x.Value != null))
                    {
                        result = false;
                        ErrorMessages += $"Additional field \"{info.NameAlias}\" is required in {errMsgTemplate};";
                    }
                }
                else
                {

                }
            }
            
            if (!string.IsNullOrWhiteSpace(ErrorMessages))
                ErrorMessages = ErrorMessages.Remove(ErrorMessages.Length - 1);

            _result = result;

            return result;
        }

        private string ErrorMessages { get; set; }

        public string GetErrorMessage()
        {
            if (!IsValid)
                return ErrorMessages;

            return null;
        }

        /// <summary>
        /// Validate infos due to invalid passed args from remote
        /// </summary>
        public void ValidateInfos()
        {
            if (_currentStageId.HasValue && _currentPipelineId.HasValue)
            {
                foreach (var info in _infoes.Where(x => x.AdditionalField))
                {
                    if (info.RequiredStageIds == null || info.RequiredPipelineIds == null)
                    {
                        throw new QontakCrmException(message: $"RequiredStage or RequiredPipelineIds is null within template name \"{info.Name}\"");
                    }
                }
            }
            else
            {
                foreach (var info in _infoes.Where(x => x.AdditionalField))
                {
                    if (!info.Required.HasValue)
                    {
                        throw new QontakCrmException(message: $"Required property is null within template name \"{info.Name}\"");
                    }
                }
            }
        }
    }
}
