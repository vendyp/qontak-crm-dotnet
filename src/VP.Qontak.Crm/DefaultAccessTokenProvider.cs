using System.Threading.Tasks;
using VP.Qontak.Crm.Models;

namespace VP.Qontak.Crm
{
    public class DefaultAccessTokenProvider : IAccessTokenProvider
    {
        public DefaultAccessTokenProvider()
        {
            
        }

        public Task<RequestToken> GetRequestToken()
        {
            throw new System.NotImplementedException();
        }
    }
}