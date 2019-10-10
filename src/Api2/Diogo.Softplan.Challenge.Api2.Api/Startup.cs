using Autofac;
using Autofac.Extensions.DependencyInjection;
using Diogo.Softplan.Challenge.Api2.Api.Extensions;
using Diogo.Softplan.Challenge.Api2.Application.DI;
using Diogo.Softplan.Challenge.Api2.Infrastructure.Http.DI;
using Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Diogo.Softplan.Challenge.Api2.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.ProvidersConfigure(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Diogo.Softplan.Challenge.API2 - API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var httpServices = typeof(ServicesFoo).Assembly.GetTypes().Where(t => t.FullName.StartsWith("Diogo.Softplan.Challenge.Api2.Infrastructure.Http.Services.") &&
                           t.FullName.EndsWith("Service"));

            foreach (var httpService in httpServices)
            {
                services.AddSingleton(httpService.GetInterfaces().First(), httpService);
            }

            var appServices = typeof(Application.Services.ServicesFoo).Assembly.GetTypes().Where(t => t.FullName.StartsWith("Diogo.Softplan.Challenge.Api2.Application.Services.") &&
                           t.FullName.EndsWith("Service"));

            foreach (var appService in appServices)
            {
                services.AddSingleton(appService.GetInterfaces().First(), appService);
            }
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Diogo.Softplan.Challenge.API2 - API V1");
            });

            app.UseMvc();
        }
        
    }
}
