using Diogo.Softplan.Challenge.Api1.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Diogo.Softplan.Challenge.Api1.Api.Controllers
{
    [Route("api/taxaJuros")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly ITaxaDeJurosService _taxaDeJurosService;

        public JurosController(ITaxaDeJurosService taxaDeJurosService)
        {
            _taxaDeJurosService = taxaDeJurosService;
        }


        /// <summary>
        /// Retorna a taxa de juros - Valor Estático: 0.01
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<double> ObterTaxaJuros()
        {
            return _taxaDeJurosService.Obter();
        }        
    }
}
