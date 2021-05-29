using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Qontak.Crm.Exceptions;
using Qontak.Crm.Infrastructure;

namespace Qontak.Crm
{
    public class QontakCrmClient : IQontakCrmClient
    {
        private readonly QontakCrmOptions _options;
        private readonly ITokenCacheManagement _cacheManagement;
        private readonly IHttpClient _httpClient;

        public QontakCrmClient(
            QontakCrmOptions options,
            ITokenCacheManagement tokenCacheManagement = null,
            IHttpClient httpClient = null)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _options = options;
            _cacheManagement = tokenCacheManagement ?? BuildDefaultCacheManagement();
            _httpClient = httpClient ?? BuildDefaultHttpClient();
        }

        private IHttpClient BuildDefaultHttpClient()
        {
            return new DefaultHttpClient();
        }

        private ITokenCacheManagement BuildDefaultCacheManagement()
        {
            return new DefaultCacheManagement();
        }

        public async Task<BaseResponse<T>> RequestAsync<T>(
            HttpMethod method,
            string path,
            CancellationToken cancellationToken = default) where T : IQontakCrmEntity
        {
            var token = _cacheManagement.Get();
            if (token == null || IsTokenExpired(token)) token = await BuildTokenAsync(cancellationToken);

            var request = new QontakRequest();

            bool retryOneTime = true;

            while (true)
            {
                var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

                if (response.HttpStatusCode == HttpStatusCode.Unauthorized)
                {
                    if (retryOneTime)
                    {
                        retryOneTime = false;
                        await BuildTokenAsync(cancellationToken);

                        continue;
                    }
                    else
                    {
                        throw new QontakCrmException(message: "Error invalid credentials");
                    }
                }
                else
                {
                    if (response.HttpStatusCode != HttpStatusCode.OK)
                        throw new QontakCrmException(message: "Server is busy, please try again later");

                    return ProcessResponse<T>(response);
                }
            }
        }

        private bool IsTokenExpired(RequestToken token)
        {
            return false;
        }

        private async Task<RequestToken> BuildTokenAsync(CancellationToken cancellationToken)
        {
            switch (_options.AuthenticationType)
            {
                case QontakCrmAuthenticationType.Basic:
                    return await BuildTokenBasicAuthenticationAsync(cancellationToken);
                case QontakCrmAuthenticationType.OAuth:
                    throw new NotImplementedException();
                default:
                    return await BuildTokenBasicAuthenticationAsync(cancellationToken);
            }
        }

        private async Task<RequestToken> BuildTokenBasicAuthenticationAsync(CancellationToken cancellationToken)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"grant_type","password"},
                {"Content-Type", "application/x-www-form-urlencoded"},
                {"username", _options.CrmUsername},
                {"password", _options.CrmPassword}
            };

            var httpContent = new FormUrlEncodedContent(dict);

            var request = new QontakRequest(
                new Uri(Path.Combine(CrmConstant.BaseUrl, "oauth/token")),
                HttpMethod.Post,
                httpContent,
                null);

            var response = await _httpClient.SendAsync(request, cancellationToken)
                .ConfigureAwait(false);

            if (response.HttpStatusCode == HttpStatusCode.Unauthorized)
            {
                throw new QontakCrmException(message: "Failed to request token with current username/password. This may occurs because of invalid username and password");
            }

            if (response.HttpStatusCode != HttpStatusCode.OK)
            {
                throw new QontakCrmException(message: "Server is busy, please try again later");
            }

            var requestToken = JsonUtils.DeserializeObject<RequestToken>(response.Content);

            _cacheManagement.Set(requestToken);

            return requestToken;
        }

        private BaseResponse<T> ProcessResponse<T>(QontakResponse response) where T : IQontakCrmEntity
        {
            if (response.HttpStatusCode != HttpStatusCode.OK)
            {
                throw new QontakCrmException($"Request Failed. Code {response.HttpStatusCode}");
            }

            try
            {
                return JsonUtils.DeserializeObject<BaseResponse<T>>(response.Content);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                throw new QontakCrmException($"Invalid object response from Qontak");
            }
        }
    }
}
