using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SGC.Data;
using Newtonsoft.Json;
using SGC.InterfaceServices.BatchMineral;
using SGC.Services.BatchMineral;
using SGC.InterfaceServices.Configuracion.Sistema;
using SGC.Services.Configuracion.Sistema;
using SGC.InterfaceServices.Comercial.Maestro;
using SGC.Services.Comercial.Maestro;

namespace SGC.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("Conexion");
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddDbContext<DbContextSGC>(options=>options.UseSqlServer(connection));
            services.AddTransient<IServiceZone, ServiceZone>();
            services.AddTransient<IServiceOrigin, ServiceOrigin>();
            services.AddTransient<IServiceCompany, ServiceCompany>();
            services.AddTransient<IServiceCollector, ServiceCollector>();
            services.AddTransient<IServicePeriod, ServicePeriod>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
