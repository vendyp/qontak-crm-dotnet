using System;

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
    }
}
