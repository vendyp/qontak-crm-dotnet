using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Qontak.Crm.Constants;

namespace Qontak.Crm
{
    public class DealService : BaseService
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

        public override List<Info> Infoes { get; set; }

        public async Task<Deal> CreateDealAsync(CreateDealOptions createDealOptions, Dictionary<string, string> additionalFields, CancellationToken cancellationToken = default)
        {
            if (Infoes == null)
                await GetInfoAsync(cancellationToken);

            DefaultValidationRequiredOptions(createDealOptions, Infoes);

            throw new NotImplementedException();
        }

        public async Task<List<Info>> GetInfoAsync(CancellationToken cancellationToken = default)
        {
            if (Infoes == null)
                Infoes = await _crmClient.RequestListAsync<Info>(
                    HttpMethod.Get,
                    $"{BasePath}/info",
                    null,
                    cancellationToken);

            return Infoes;
        }

        public void DefaultValidationRequiredOptions(CreateDealOptions createDealOptions, List<Info> infoes)
        {
            if (createDealOptions is null)
            {
                throw new ArgumentNullException(nameof(createDealOptions));
            }

            if (infoes is null || infoes.Count < 1)
            {
                throw new ArgumentNullException(nameof(infoes));
            }

            //default validate 
            if (string.IsNullOrWhiteSpace(createDealOptions.Name))
                throw new ArgumentNullException(nameof(createDealOptions.Name), "Options name can not null or empty");

            //default validate
            if (createDealOptions.CreatorId == null)
                throw new ArgumentNullException(nameof(createDealOptions.CreatorId), "Options creator id can not null");

            //default validate 
            var creator = infoes.First(x => x.Name == TemplateConstant.Creator);
            var creatorDropdown = creator.Dropdown;
            if (creatorDropdown == null)
                throw new ArgumentNullException(nameof(creatorDropdown), "Creator dropdown can not be null");

            if (!creatorDropdown.Any(x => x.Id == createDealOptions.CreatorId.Value))
                throw new ArgumentNullException(nameof(createDealOptions.CreatorId), $"Creator id {createDealOptions.CreatorId.Value} can not be found in template info");
        }
    }
}
