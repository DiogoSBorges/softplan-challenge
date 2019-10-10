using Diogo.Softplan.Challenge.Api2.Domain.Services;

namespace Diogo.Softplan.Challenge.Api2.Application.Services
{
    public class ShowMeTheCodeService : IShowMeTheCodeService
    {
        const string GIT_URL = "https://github.com/DiogoSBorges/softplan-challenge";

        public string ObterUrlGit()
        {
            return GIT_URL;
        }
    }
}
