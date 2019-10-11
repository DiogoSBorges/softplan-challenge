using Diogo.Softplan.Challenge.Api2.Api;
using Diogo.Softplan.Challenge.Api2.Domain.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Diogo.Softplan.Challenge.Api2.Integration.Tests.Api
{
    public class CalcularJurosControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public CalcularJurosControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;

        }

        [Theory]
        [InlineData("GET", 100, 5)]
        public async void Quando_calcular_taxa_juros(string metodo, decimal valorInicial, int meses)
        {

            var mock = new Mock<IApi1Service>();
            mock.Setup(x => x.ObterTaxaDeJurosAsync()).Returns(Task.FromResult(0.01m));

            var client = _factory.WithWebHostBuilder(hostbuilder =>
            {
                hostbuilder.ConfigureTestServices((services) =>
                {
                    services.AddSingleton<IApi1Service>(mock.Object);
                });
            })
        .CreateClient();

            var request = new HttpRequestMessage(new HttpMethod(metodo), $"/api/calcularJuros?valorInicial={valorInicial}&meses={meses}");

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();

            var result = await response.Content.ReadAsStringAsync();

            result.Should().Be("105.1");
        }

        [Theory]
        [InlineData("GET", 100, 5)]
        public async void Quando_calcular_taxa_juros_formatado(string metodo, decimal valorInicial, int meses)
        {

            var mock = new Mock<IApi1Service>();
            mock.Setup(x => x.ObterTaxaDeJurosAsync()).Returns(Task.FromResult(0.01m));

            var client = _factory.WithWebHostBuilder(hostbuilder =>
            {
                hostbuilder.ConfigureTestServices((services) =>
                {
                    services.AddSingleton<IApi1Service>(mock.Object);
                });
            })
        .CreateClient();

            var request = new HttpRequestMessage(new HttpMethod(metodo), $"/api/calcularJuros/formatado?valorInicial={valorInicial}&meses={meses}");

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();

            var result = await response.Content.ReadAsStringAsync();
            result.Should().Be("105,10");
        }
    }
}
