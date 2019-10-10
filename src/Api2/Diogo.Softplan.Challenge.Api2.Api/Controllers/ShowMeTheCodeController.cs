using Diogo.Softplan.Challenge.Api2.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Diogo.Softplan.Challenge.Api2.Api.Controllers
{
    [Route("api/showmethecode")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly IShowMeTheCodeService _showMeTheCodeService;

        public ShowMeTheCodeController(IShowMeTheCodeService showMeTheCodeService)
        {
            _showMeTheCodeService = showMeTheCodeService;
        }

        /// <summary>
        /// Retorna a URL onde se Localiza o Repositório GIT da aplicação
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> ObterUrlGit()
        {
            return _showMeTheCodeService.ObterUrlGit();
        }
    }
}
