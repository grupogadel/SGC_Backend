using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class PeriodController : ControllerBase
    {
        IServicePeriod _periodService;
        public PeriodController(IServicePeriod periodService)
        {
            this._periodService = periodService;
        }

        // GET: api/Period/GetAll/idCompany
        [HttpGet("[action]/{idCompany}")]
        public async Task<IActionResult> GetAll(int idCompany)
        {
            try
            {
                var result = await this._periodService.GetAll(idCompany);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Period/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Period model)
        {
            return Ok(
                _periodService.Add(model)
            );
        }


        // POST api/Period/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Period model)
        {
            return Ok(
                _periodService.Update(model)
            );
        }

        // DELETE api/Period/Delete/1
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _periodService.Delete(obj)
            );
        }

        // GET api/Period/Get/
        [HttpGet("[action]")]
        public IActionResult Get([FromBody] JObject obj)
        {
            return Ok(
                _periodService.Get(obj)
            );
        }

    }
}
