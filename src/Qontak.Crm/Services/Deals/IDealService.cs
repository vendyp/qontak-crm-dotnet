using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qontak.Crm.Services.Deals
{
    public interface IDealService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createDealOptions"></param>
        /// <param name="additionalFields"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Deal> CreateDealAsync(
            CreateDealOptions createDealOptions,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<Info>> GetInfosAsync(CancellationToken cancellationToken = default);
    }
}
