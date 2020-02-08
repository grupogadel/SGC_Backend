using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGC.Entities.Entities.Comercial.Maestros;
using SGC.InterfaceServices.Comercial.Maestros;

namespace SGC.Web.Controllers.Comercial.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class ZonasController : ControllerBase
    {
        IServiceZona _zonaService;
        public ZonasController(IServiceZona zonaService)
        {
            this._zonaService = zonaService;
        }

        // GET: api/Zonas/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var result = await this._zonaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        // POST api/Zonas/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Zona model) 
        {
            return Ok(
                _zonaService.Add(model)
            );
        }


        // POST api/Zonas/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Zona model)
        {
            return Ok(
                _zonaService.Update(model)
            );
        }

        // DELETE api/Zonas/Delete/1
        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _zonaService.Delete(id)
            );
        }

        // GET api/Zonas/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _zonaService.Get(id)
            );
        }

    }
}
