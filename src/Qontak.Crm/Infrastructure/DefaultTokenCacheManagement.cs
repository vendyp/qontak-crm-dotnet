namespace Qontak.Crm
{
    public class DefaultCacheManagement : ITokenCacheManagement
    {
        private RequestToken _requestToken;

        public RequestToken Get()
        {
            return _requestToken;
        }

        public void Set(RequestToken token)
        {
            _requestToken = token;
        }
    }
}
