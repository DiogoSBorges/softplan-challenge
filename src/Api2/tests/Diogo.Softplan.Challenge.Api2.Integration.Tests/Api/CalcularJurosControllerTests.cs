using Diogo.Softplan.Challenge.Api2.Api;
using Diogo.Softplan.Challenge.Api2.Application.Services;
using Diogo.Softplan.Challenge.Api2.Domain.Services;
using Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
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

            _factory.WithWebHostBuilder(builder => {

                builder.ConfigureTestServices(services =>
                {
                    var mockTeste = new Mock<Api1Service>();
                    mockTeste.Setup(x => x.ObterTaxaDeJurosAsync()).Returns(Task.FromResult(0.01m));
                                       
                    services.AddSingleton<IApi1Service>((sp) => mockTeste.Object);
                });
            });
        }

        [Theory]
        [InlineData("GET", 100,5)]
        public async void Quando_calcular_taxa_juros(string metodo, decimal valorInicial, int meses)
        {
            var client = _factory.WithWebHostBuilder(builder => {

                builder.ConfigureTestServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();
                    var descriptor =
                        new ServiceDescriptor(
                            typeof(IApi1Service),
                            typeof(MockedServiceClient));
                    services.Replace(descriptor);
                });
            }).CreateClient();

            var request = new HttpRequestMessage(new HttpMethod(metodo), $"/api/calcularJuros?valorInicial={valorInicial}&meses={meses}");

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();

            var result = await response.Content.ReadAsStringAsync();

            result.Should().Be("105.1");
        }
    }

    public class MockedServiceClient : IApi1Service
    {       
        public Task<decimal> ObterTaxaDeJurosAsync()
        {
            return Task.FromResult(0.01m);
        }        
    }
}
