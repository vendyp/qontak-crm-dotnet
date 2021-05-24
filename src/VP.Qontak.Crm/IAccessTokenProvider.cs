using System.Threading.Tasks;
using VP.Qontak.Crm.Models;

namespace VP.Qontak.Crm
{
    public interface IAccessTokenProvider
    {
        Task<RequestToken> GetRequestToken();
    }
}