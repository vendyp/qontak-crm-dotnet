using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Qontak.Crm
{
    public interface IQontakCrmClient
    {
        Task<BaseResponse<T>> RequestAsync<T>(
         HttpMethod method,
         string path,
         CancellationToken cancellationToken = default)
         where T : IQontakCrmEntity;
    }
}
