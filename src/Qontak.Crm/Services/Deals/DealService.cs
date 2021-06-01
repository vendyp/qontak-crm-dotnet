using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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
            if (Infoes == null) await GetInfoAsync(cancellationToken);

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
    }
}
