using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SGC.Data;
using SGC.Entities.Entities.Comercial.Maestro;
using SGC.InterfaceServices.Comercial.Maestro;

namespace SGC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectorController : ControllerBase
    {
        IServiceCollector _companyService { get; }

        public CollectorController(IServiceCollector companyService)
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
        public async Task<IActionResult> Create([FromBody] Collector company)
        {
            try
            {
                //Collector company = model.ToObject<Collector>();
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
                //Collector company = model.ToObject<Collector>();
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
