using System.Threading.Tasks;

namespace Diogo.Softplan.Challenge.Api2.Domain.Services
{
    public interface ICalcularJurosService
    {
        Task<decimal> CalcularAsync(decimal valorInicial, int meses);

        Task<string> CalcularComFormatacaoAsync(decimal valorInicial, int meses);
    }
}
