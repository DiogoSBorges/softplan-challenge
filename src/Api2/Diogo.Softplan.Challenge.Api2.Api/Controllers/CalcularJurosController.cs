using Diogo.Softplan.Challenge.Api2.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Diogo.Softplan.Challenge.Api2.Api.Controllers
{
    [Route("api/calcularJuros")]
    [ApiController]
    public class CalcularJurosController : ControllerBase
    {
        private readonly ICalcularJurosService _calcularJurosService;

        public CalcularJurosController(ICalcularJurosService calcularJurosService)
        {
            _calcularJurosService = calcularJurosService;
        }

        /// <summary>
        /// Calcula Juros juros compostos
        /// </summary>
        /// <param name="valorInicial">Valor Inicial</param>
        /// <param name="meses">Quantidade de Meses</param>
        /// <returns>Retorna um decimal com o valor</returns>
        [HttpGet]
        public async Task<decimal> CalcurarJurosAsync([FromQuery]decimal valorInicial, [FromQuery] int meses)
        {
            return await _calcularJurosService.CalcularAsync(valorInicial, meses);
        }

        /// <summary>
        /// Calcula Juros juros compostos e retorna formatado
        /// </summary>
        /// <param name="valorInicial">Valor Inicial</param>
        /// <param name="meses">Quantidade de Meses</param>
        /// <returns>Retorna uma string com o valor formatado</returns>
        [HttpGet("formatado")]
        public async Task<string> CalcurarJurosFormatadoAsync([FromQuery]decimal valorInicial, [FromQuery] int meses)
        {
            return await _calcularJurosService.CalcularComFormatacaoAsync(valorInicial, meses);
        }
    }
}
