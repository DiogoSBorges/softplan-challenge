using Autofac;
using Diogo.Softplan.Challenge.Api1.Application.Services;
using System.Linq;

namespace Diogo.Softplan.Challenge.Api1.Application.DI {
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServicesFoo).Assembly)
               .Where(x => x.FullName.StartsWith("Diogo.Softplan.Challenge.Api1.Application.Services.") &&
                           x.FullName.EndsWith("Service"))
               .AsImplementedInterfaces();
        }
    }
}
