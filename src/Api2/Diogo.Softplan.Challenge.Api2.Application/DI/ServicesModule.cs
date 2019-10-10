using Autofac;
using Diogo.Softplan.Challenge.Api2.Application.Services;

namespace Diogo.Softplan.Challenge.Api2.Application.DI
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServicesFoo).Assembly)
               .Where(x => x.FullName.StartsWith("Diogo.Softplan.Challenge.Api2.Application.Services.") &&
                           x.FullName.EndsWith("Service"))
               .AsImplementedInterfaces();
        }
    }
}
