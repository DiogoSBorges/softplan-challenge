using Autofac;
using Autofac.Extensions.DependencyInjection;
using Diogo.Softplan.Challenge.Api1.Api.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Diogo.Softplan.Challenge.Api1.Api
{
    public class Startup
    {

        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add services to the collection
            services.AddOptions();

            // create a container-builder and register dependencies
            var builder = new ContainerBuilder();

            // populate the service-descriptors added to `IServiceCollection`

            builder.Populate(services);

            builder.RegisterModule(new ServicesModule());

            // this will be used as the service-provider for the application!
            return new AutofacServiceProvider(builder.Build());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
