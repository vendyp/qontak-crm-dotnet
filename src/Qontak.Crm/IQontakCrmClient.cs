using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Qontak.Crm
{
    public interface IQontakCrmClient
    {
        Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            HttpContent content = null,
            CancellationToken cancellationToken = default)
            where T : IQontakCrmEntity;

        Task<List<T>> RequestListAsync<T>(
            HttpMethod method,
            string path,
            HttpContent content = null,
            CancellationToken cancellationToken = default)
            where T : IQontakCrmEntity;

        Task<PaginationResponse<T>> RequestPaginationListAsync<T>(
            HttpMethod method,
            string path,
            HttpContent content = null,
            CancellationToken cancellationToken = default)
            where T : IQontakCrmEntity;
    }
}
