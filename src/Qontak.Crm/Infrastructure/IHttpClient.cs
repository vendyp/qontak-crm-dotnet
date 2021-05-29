using System.Threading;
using System.Threading.Tasks;

namespace Qontak.Crm.Infrastructure
{
    public interface IHttpClient
    {
        Task<QontakResponse> SendAsync(QontakRequest request, CancellationToken cancellationToken);
    }
}
