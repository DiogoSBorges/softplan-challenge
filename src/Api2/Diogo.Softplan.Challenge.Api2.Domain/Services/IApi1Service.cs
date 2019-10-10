using System.Threading.Tasks;

namespace Diogo.Softplan.Challenge.Api2.Domain.Services
{
    public interface IApi1Service
    {
        Task<decimal> ObterTaxaDeJurosAsync();
    }
}
