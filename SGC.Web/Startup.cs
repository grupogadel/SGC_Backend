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
using SGC.InterfaceServices.CM.Collect;
using SGC.Services.CM.Collect;
using SGC.InterfaceServices.CM.MineralReception;
using SGC.Services.CM.MineralReception;
using SGC.Services.XX.Finance;
using SGC.InterfaceServices.FI.DataMaster;
using SGC.Services.FI.DataMaster;
using SGC.InterfaceServices.CM.Commercial;
using SGC.Services.CM.Commercial;
using SGC.InterfaceServices.XX.Operations.Mining;
using SGC.Services.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Commercial.Laboratory;
using SGC.Services.XX.Commercial.Laboratory;
using SGC.InterfaceServices.XX.Commercial.MineralReception;
using SGC.Services.XX.Commercial.MineralReception;
using SGC.InterfaceServices.CM.MineralReception.Sampling;
using SGC.Services.CM.MineralReception.Sampling;
using SGC.InterfaceServices.CM.InternalControl;
using SGC.Services.CM.InternalControl;
using SGC.InterfaceServices.CM.Laboratory;
using SGC.Services.CM.Laboratory;
using SGC.InterfaceServices.CM.InternalControl.BatchManagement;
using SGC.Services.CM.InternalControl.BatchManagement;
using SGC.InterfaceServices.CM.Commercial.Advance;
using SGC.Services.CM.Commercial.Advance;
using SGC.Services.CM.Commercial.Settlement;
using SGC.InterfaceServices.CM.Commercial.Settlement;
using SGC.InterfaceServices.CM.CollectorControl;
using SGC.Services.CM.CollectorControl;
using SGC.InterfaceServices.CM.Commercial.SampleReferential;
using SGC.Services.CM.Commercial.SampleReferential;
using SGC.InterfaceServices.CM.Commercial.CommercialCondition;
using SGC.Services.CM.Commercial.CommercialCondition;

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
            services.AddScoped<IServiceCurrency, ServiceCurrency>();
            services.AddScoped<IServicePeriod, ServicePeriod>();
            services.AddScoped<IServiceOrigin, ServiceOrigin>();
            services.AddScoped<IServiceCollector, ServiceCollector>();
            services.AddScoped<IServiceQuota, ServiceQuota>();
            services.AddScoped<IServiceMPeriod, ServiceMPeriod>();
            services.AddScoped<IServiceCommercialConditions, ServiceCommercialConditions>();
            services.AddScoped<IServiceMaquilaCommercial, ServiceMaquilaCommercial>();
            services.AddScoped<IServiceVendor, ServiceVendor>();
            services.AddScoped<IServiceScales, ServiceScales>();
            services.AddScoped<IServiceBank, ServiceBank>();
            services.AddScoped<IServiceDocIdentity, ServiceDocIdentity>();
            services.AddScoped<IServiceCountry, ServiceCountry>();
            services.AddScoped<IServiceRegion, ServiceRegion>();
            services.AddScoped<IServiceDepartment, ServiceDepartment>();
            services.AddScoped<IServiceExchangeRate, ServiceExchangeRate>();
            services.AddScoped<IServicePriceInternational, ServicePriceInternational>();
            services.AddScoped<IServiceHumidity, ServiceHumidity>();
            services.AddScoped<IServiceHumidity, ServiceHumidity>();
            services.AddScoped<IServicePositionCollector, ServicePositionCollector>();
            services.AddScoped<IServiceMineralsType, ServiceMineralsType>();
            services.AddScoped<IServiceWorkShifts, ServiceWorkShifts>();
            services.AddScoped<IServiceAnalisysType, ServiceAnalisysType>();
            services.AddScoped<IServiceProductType, ServiceProductType>();
            services.AddScoped<IServiceLabProcessType, ServiceLabProcessType>();
            services.AddScoped<IServiceSampleOrigin, ServiceSampleOrigin>();
            services.AddScoped<IServiceCorrelDocuments, ServiceCorrelDocuments>();
            services.AddScoped<IServiceLanguage, ServiceLanguage>();
            services.AddScoped<IServiceStatus, ServiceStatus>();
            services.AddScoped<IServiceUnitMeasuare, ServiceUnitMeasuare>();
            services.AddScoped<IServiceAnalysisRequest, ServiceAnalysisRequest>();
            services.AddScoped<IServiceMineralFrom, ServiceMineralFrom>();
            services.AddScoped<IServiceRuma, ServiceRuma>();
            services.AddScoped<IServiceBatchMineral, ServiceBatchMineral>();
            services.AddScoped<IServiceLaboratorySetting, ServiceLaboratorySetting>();
            services.AddScoped<IServiceCommercialParameters, ServiceCommercialParameters>();
            services.AddScoped<IServiceMaterialType, ServiceMaterialType>();
            services.AddScoped<IServiceSampleCommercial, ServiceSampleCommercial>();
            services.AddScoped<IServiceSampleHeadOperational, ServiceSampleHeadOperational>();
            services.AddScoped<IServiceMetricSetting, ServiceMetricSetting>();
            services.AddScoped<IServiceSampleLaboratory, ServiceSampleLaboratory>();
            services.AddScoped<IServiceInternalCtrl, ServiceInternalCtrl>();
	        services.AddScoped<IServiceLabExternal, ServiceLabExternal>();
            services.AddScoped<IServiceLaboratorySampleAnalysis, ServiceLaboratorySampleAnalysis>();
			services.AddScoped<IServiceAdvance, ServiceAdvance>();
            services.AddScoped<IServiceManagementBatchMineral, ServiceManagementBatchMineral>();
            services.AddScoped<IServiceCommercialBatchManagement, ServiceCommercialBatchManagement>();
            services.AddScoped<IServiceExpHead, ServiceExpHead>();
            services.AddScoped<IServiceModule, ServiceModule>();
			services.AddScoped<IServicePosition, ServicePosition>();
			services.AddScoped<IServiceUserAccount, ServiceUserAccount>();
			services.AddScoped<IServicePerson, ServicePerson>();
			services.AddScoped<IServiceLogin, ServiceLogin>();
			services.AddScoped<IServiceAccess, ServiceAccess>();
            services.AddScoped<IServiceSampleReferential, ServiceSampleReferential>();

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
