using System.Collections.Generic;

namespace Qontak.Crm
{
    public abstract class BaseService
    {
        public string BaseVersion => "v3.1";

        public abstract string BasePath { get; }
    }
}
