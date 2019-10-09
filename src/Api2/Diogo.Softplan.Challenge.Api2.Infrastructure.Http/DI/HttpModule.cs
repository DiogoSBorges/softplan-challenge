using Autofac;
using Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services;

namespace Diogo.Softplan.Challenge.Api2.Infrastructure.Http.DI
{
    public class HttpModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServicesFoo).Assembly)
               .Where(x => x.FullName.StartsWith("Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services.") &&
                           x.FullName.EndsWith("Service"))
               .AsImplementedInterfaces();
        }
    }
}
