using Diogo.Softplan.Challenge.Api2.Api;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Diogo.Softplan.Challenge.Api2.Integration.Tests.Api
{
    public class ShowMeTheCodeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        const string GIT_URL = "https://github.com/DiogoSBorges/softplan-challenge";

        private readonly WebApplicationFactory<Startup> _factory;

        public ShowMeTheCodeControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;

        }

        [Theory]
        [InlineData("GET")]
        public async void Quando_acessar_showmethecode(string metodo)
        {

            var client = _factory.CreateClient();

            var request = new HttpRequestMessage(new HttpMethod(metodo), $"/api/showmethecode");

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();

            var result = await response.Content.ReadAsStringAsync();
            result.Should().Be(GIT_URL);
        }

    }
}
