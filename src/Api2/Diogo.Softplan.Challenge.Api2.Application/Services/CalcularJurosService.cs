using System.Threading.Tasks;
using Diogo.Softplan.Challenge.Api2.Domain.Services;

namespace Diogo.Softplan.Challenge.Api2.Application.Services
{
    public class CalcularJurosService : ICalcularJurosService
    {
        public async Task<decimal> CalcularAsync(decimal valorInicial, int tempo)
        {
            throw new System.NotImplementedException();
        }
    }
}
