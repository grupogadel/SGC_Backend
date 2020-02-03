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
    public class PeriodController : ControllerBase
    {
        IServicePeriod _periodService { get; }

        public PeriodController(IServicePeriod periodService)
        {
            this._periodService = periodService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._periodService.GetAll();
                return Ok(result);
            }
            catch(Exception ex)
            {   
                throw ex;
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] Period period)
        {
            try
            {
                var result = await this._periodService.Create(period);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this._periodService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Search(int id)
        {
            try
            {
                var result = await this._periodService.Search(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
