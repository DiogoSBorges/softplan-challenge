using Diogo.Softplan.Challenge.Api1.Api;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Diogo.Softplan.Challenge.Api1.Integration.Tests.Api
{
    public class JurosControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public JurosControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("GET")]
        public async void Quando_obter_taxa_de_juros(string metodo)
        {
            var client = _factory.CreateClient();

            var request = new HttpRequestMessage(new HttpMethod(metodo), "/api/taxaJuros");

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
    }
}
