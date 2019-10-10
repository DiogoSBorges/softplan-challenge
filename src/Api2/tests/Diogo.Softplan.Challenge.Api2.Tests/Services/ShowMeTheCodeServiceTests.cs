using Diogo.Softplan.Challenge.Api2.Application.Services;
using FluentAssertions;
using Xunit;

namespace Diogo.Softplan.Challenge.Api2.Tests.Services
{
    public class ShowMeTheCodeServiceTests
    {
        const string GIT_URL = "https://github.com/DiogoSBorges/softplan-challenge";

        private readonly ShowMeTheCodeService _service;

        public ShowMeTheCodeServiceTests()
        {
            _service = new ShowMeTheCodeService();
        }

        [Fact]
        public void Quando_obter_url_git()
        {
            var resultado = _service.ObterUrlGit();
            resultado.Should().Be(GIT_URL);
        }
    }
}
