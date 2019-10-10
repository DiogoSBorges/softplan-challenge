
using Diogo.Softplan.Challenge.Api2.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Diogo.Softplan.Challenge.Api2.Application.DI
{
    public static class ApplicationServicesModule
    {
        public static void ApplicationServicesModuleRegister(this IServiceCollection services)
        {
            var appServices = typeof(ServicesFoo).Assembly.GetTypes().Where(t => t.FullName.StartsWith("Diogo.Softplan.Challenge.Api2.Application.Services.") &&
                           t.FullName.EndsWith("Service"));

            foreach (var appService in appServices)
            {
                services.AddSingleton(appService.GetInterfaces().First(), appService);
            }
        }
    }
}
