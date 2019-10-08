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


        [HttpGet]
        public ActionResult<double> ObterTaxaJuros()
        {
            return _taxaDeJurosService.Obter();
        }        
    }
}
