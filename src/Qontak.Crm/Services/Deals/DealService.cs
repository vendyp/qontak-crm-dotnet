using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Qontak.Crm.Services.Deals;

namespace Qontak.Crm
{
    public class DealService : BaseService, IDealService
    {
        private readonly IQontakCrmClient _crmClient;

        public DealService(IQontakCrmClient crmClient)
        {
            if (crmClient is null)
            {
                throw new ArgumentNullException(nameof(crmClient));
            }

            _crmClient = crmClient;
        }

        public override string BasePath => "deals";

        public List<Info> Infoes { get; set; }

        public async Task<Deal> CreateDealAsync(
            CreateDealOptions createDealOptions,
            CancellationToken cancellationToken = default)
        {
            if (Infoes == null)
                await GetInfosAsync(cancellationToken);

            CreateDealOptionsValidator validator = new CreateDealOptionsValidator(createDealOptions, Infoes);

            if (!validator.IsValid)
            {
                throw new QontakCrmException(message: $"Invalid validation; {validator.GetErrorMessage()}");
            }

            if (createDealOptions.AdditionalFields.Any())
            {
                var additionalFieldValidator = new AdditionalFieldValidator(
                    currentPipelineId: createDealOptions.PipelineId,
                    currentStageId: createDealOptions.StageId,
                    additionalFields: createDealOptions.AdditionalFields,
                    infoes: Infoes);

                if (!additionalFieldValidator.IsValid)
                {
                    throw new QontakCrmException(message: $"Invalid validation on additional field(s); {additionalFieldValidator.GetErrorMessage()}");
                }
            }

            throw new NotImplementedException();
        }

        public async Task<List<Info>> GetInfosAsync(CancellationToken cancellationToken = default)
        {
            if (Infoes == null)
                Infoes = await _crmClient.RequestListAsync<Info>(
                    HttpMethod.Get,
                    $"{BasePath}/info",
                    null,
                    cancellationToken);

            return Infoes;
        }
    }
}
