using System;

namespace VP.Qontak.Crm
{
    public class QontakCrm
    {
        private readonly IAccessTokenProvider _accessTokenProvider;

        public QontakCrm(IAccessTokenProvider accessTokenProvider)
        {
            _accessTokenProvider = accessTokenProvider ?? throw new ArgumentNullException(paramName: nameof(accessTokenProvider));
        }
    }
}