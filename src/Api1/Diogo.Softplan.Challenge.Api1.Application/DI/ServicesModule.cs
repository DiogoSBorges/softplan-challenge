using Autofac;
using System.Linq;

namespace Diogo.Softplan.Challenge.Api1.Api.DI
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
               .Where(x => x.FullName.StartsWith("Diogo.Softplan.Challenge.Api1.Application.Services.") &&
                           x.FullName.EndsWith("Service"))
               .AsImplementedInterfaces();
        }
    }
}
