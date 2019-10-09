using Autofac;
using Diogo.Softplan.Challenge.Api2.Api.DI.Provider;
using Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services;
using Microsoft.Extensions.Configuration;

namespace Diogo.Softplan.Challenge.Api2.Api.DI{
    public class HttpModule: Module
    {
        public IConfiguration Configuration { get; }

        public HttpModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        protected override void Load(ContainerBuilder builder)
        {
            var api1Url = Configuration.GetSection("Api1Provider").GetSection("Url").Value;
            builder.RegisterInstance(new Api1Provider(api1Url));

            builder.RegisterAssemblyTypes(typeof(ServicesFoo).Assembly)
               .Where(x => x.FullName.StartsWith("Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services.") &&
                           x.FullName.EndsWith("Service"))
               .AsImplementedInterfaces();
        }
    }
}
