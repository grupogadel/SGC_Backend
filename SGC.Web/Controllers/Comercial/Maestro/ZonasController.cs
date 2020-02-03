using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGC.Data;
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
            //return await _context.Zones.ToListAsync();
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

        // GET: api/Zonas/Select
        [HttpGet("[action]")]
        public async Task<IActionResult> Selec()
        {
            //return await _context.Zones.ToListAsync();
            try
            {
                var result = await this._zonaService.Selec();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // GET api/Zonas/Get/5
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _zonaService.Get(id)
            );
        }
        // POST api/Zonas/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Zona model)
        {
            return Ok(
                _zonaService.Add(model)
            );
        }
        // PUT api/Zonas/Update/5
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Zona model)
        {
            return Ok(
                _zonaService.Update(model)
            );
        }
        // DELETE api/Zonas/Delete/5
        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _zonaService.Delete(id)
            );
        }
    }
}
