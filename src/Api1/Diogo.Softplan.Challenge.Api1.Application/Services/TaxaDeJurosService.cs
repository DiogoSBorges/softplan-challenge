using Diogo.Softplan.Challenge.Api1.Domain.Services;

namespace Diogo.Softplan.Challenge.Api1.Application.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        public double Obter()
        {
            return (1 / 100);
        }
    }
}
