namespace Qontak.Crm.Services._base
{
    public abstract class BaseService
    {
        public abstract bool NeedAuthentication { get; }
        public abstract string BasePath { get; }
    }
}
