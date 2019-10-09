using Diogo.Softplan.Challenge.Api2.Api.DI.Provider;
using Diogo.Softplan.Challenge.Api2.Domain.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services
{
    public class Api1Service : IApi1Service
    {

        private readonly Api1Provider _api1Provider;

        public Api1Service(Api1Provider api1Provider)
        {
            _api1Provider = api1Provider;
        }

        public async Task<double> ObterTaxaDeJurosAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_api1Provider.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseMessage = await client.GetAsync("api/taxaJuros");
                var response = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                {
                    return double.Parse(response);
                }

                switch (responseMessage.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        throw new ArgumentException(response);

                    default:
                        throw new Exception(response);
                }

            }
        }
    }
}
