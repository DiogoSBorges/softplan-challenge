using Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Diogo.Softplan.Challenge.Api2.Infrastructure.Http.DI
{
    public static class HttpModule
    {
        public static void HttpModuleRegister(this IServiceCollection services)
        {
            var httpServices = typeof(ServicesFoo).Assembly.GetTypes().Where(t => t.FullName.StartsWith("Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services.") && t.FullName.EndsWith("Service"));

            foreach (var httpService in httpServices)
            {
                services.AddSingleton(httpService.GetInterfaces().First(), httpService);
            }
        }
    }
}
