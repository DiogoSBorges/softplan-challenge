using Diogo.Softplan.Challenge.Api2.Api.DI.Provider;
using Diogo.Softplan.Challenge.Api2.Domain.Services;
using System;
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

        public Task<double> ObterTaxaDeJurosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
