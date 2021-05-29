namespace Qontak.Crm
{
    public interface ITokenCacheManagement
    {
        RequestToken Get();

        void Set(RequestToken token);
    }
}
