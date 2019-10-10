using Diogo.Softplan.Challenge.Api1.Application.Services;
using FluentAssertions;
using Xunit;

namespace Diogo.Softplan.Challenge.Api1.Tests.Services
{
    public class TaxaDeJurosServiceTests
    {
        private readonly TaxaDeJurosService _service = new TaxaDeJurosService();

        [Fact]
        public void Quando_obter_taxa_de_juros()
        {
            var resultado = _service.Obter();

            resultado.Should().Be(0.01m);
        }
    }
}
