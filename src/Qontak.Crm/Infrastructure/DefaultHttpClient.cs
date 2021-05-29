using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Qontak.Crm.Infrastructure
{
    public class DefaultHttpClient : IHttpClient
    {
        private static readonly Lazy<HttpClient> LazuDefaultHttpClient = new Lazy<HttpClient>(BuildHttpClient);
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Default timespan before the request times out.
        /// </summary>
        /// <returns></returns>
        public static TimeSpan DefaultHttpTimeout => TimeSpan.FromSeconds(90);

        public DefaultHttpClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? LazuDefaultHttpClient.Value;
        }

        public async Task<QontakResponse> SendAsync(QontakRequest request, CancellationToken cancellationToken)
        {
            TimeSpan duration;
            Exception reqException = null;
            HttpResponseMessage response = null;

            var httpRequest = BuildRequestMessage(request.Uri, request.Method, request.Headers, request.Content);

            var stopwatch = Stopwatch.StartNew();
            try
            {
                response = await _httpClient.SendAsync(httpRequest, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                reqException = exception;
            }
            catch (Exception ex)
            {
                reqException = ex;
            }

            stopwatch.Stop();

            duration = stopwatch.Elapsed;

            if (reqException != null)
            {
                throw reqException;
            }

            var reader = new StreamReader(await response.Content.ReadAsStreamAsync()
                .ConfigureAwait(false));

            return new QontakResponse(
                response.StatusCode,
                response.Headers,
                await reader.ReadToEndAsync().ConfigureAwait(false));
        }

        public HttpRequestMessage BuildRequestMessage(Uri uri, HttpMethod method, Dictionary<string, string> headers, HttpContent content = null)
        {
            var req = new HttpRequestMessage();

            req.RequestUri = uri;

            req.Method = method;

            if (headers != null && headers.Any())
            {
                foreach (var item in headers)
                {
                    req.Headers.Add(name: item.Key, value: item.Value);
                }
            }

            if (content != null)
            {
                req.Content = content;
            }

            return req;
        }

        public static HttpClient BuildHttpClient()
        {
            return new HttpClient
            {
                Timeout = DefaultHttpTimeout,
            };
        }
    }
}
