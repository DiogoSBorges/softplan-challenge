using Diogo.Softplan.Challenge.Api1.Domain.Services;
using System;

namespace Diogo.Softplan.Challenge.Api1.Application.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        public double Obter()
        {
            var result = 1.0 / 100.0;
            return result;
        }
    }
}
