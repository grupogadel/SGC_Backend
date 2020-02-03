using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SGC.Data;
using SGC.Entities.Entities.Configuracion.Sistema;
using SGC.InterfaceServices.Configuracion.Sistema;
using SGC.Services.Configuracion.Sistema;

namespace SGC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        IServiceCompany _companyService { get; }

        public CompanyController(IServiceCompany companyService)
        {
            this._companyService = companyService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._companyService.GetAll();
                return Ok(result);
            }
            catch(Exception ex)
            {   
                throw ex;
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            try
            {
                //Company company = model.ToObject<Company>();
                var result = await this._companyService.Create(company);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            try
            {
                //Company company = model.ToObject<Company>();
                var result = await this._companyService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
