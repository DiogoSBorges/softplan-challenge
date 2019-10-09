using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpClient CreateClient(this HttpClient httpClient, string urlBase)
        {
            if (string.IsNullOrWhiteSpace(urlBase)) throw new ArgumentNullException(nameof(urlBase));

            httpClient.BaseAddress = new Uri(urlBase);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
