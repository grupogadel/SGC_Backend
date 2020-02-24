using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SGC.Services.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using SGC.InterfaceServices.WK;
using SGC.Services.WK;
using SGC.Services.XX;
using SGC.InterfaceServices.XX.Finance;
using SGC.InterfaceServices.CM.DataMaster;
using SGC.Services.CM.DataMaster;
using SGC.InterfaceServices.CM.DataMaster.Commercial;
using SGC.Services.CM.DataMaster.Commercial;
using SGC.InterfaceServices.XX.Commercial;
using SGC.Services.XX.Commercial;

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
            
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddScoped<IServiceZone, ServiceZone>();
            services.AddScoped<IServiceCompany, ServiceCompany>();
			services.AddScoped<IServiceDistrict, ServiceDistrict>();
			services.AddScoped<IServiceProvince, ServiceProvince>();
            services.AddScoped<IServiceUser, ServiceUser>();
            services.AddScoped<IServicePosition, ServicePosition>();
            services.AddScoped<IServiceCurrency, ServiceCurrency>();
            services.AddScoped<IServicePeriod, ServicePeriod>();
            services.AddScoped<IServiceOrigin, ServiceOrigin>();
            services.AddScoped<IServiceConditions, ServiceConditions>();
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");

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
