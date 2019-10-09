using Diogo.Softplan.Challenge.Api1.Domain.Services;

namespace Diogo.Softplan.Challenge.Api1.Application.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        public decimal Obter()
        {
            var taxa = (1 / 100m);
            return taxa;
        }
    }
}
