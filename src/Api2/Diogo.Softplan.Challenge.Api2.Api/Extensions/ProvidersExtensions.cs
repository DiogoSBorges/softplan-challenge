using Diogo.Softplan.Challenge.Api2.Api.DI.Provider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diogo.Softplan.Challenge.Api2.Api.Extensions
{
    public static class ProvidersExtensions
    {
        public static void ProvidersConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Api1Provider>(configuration.GetSection("Api1Provider"));
        }
    }
}
