using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class ProvinceController : ControllerBase
    {
        IServiceProvince _provinciaService;
        public ProvinceController(IServiceProvince ProvinciaService)
        {
            this._provinciaService = ProvinciaService;
        }

        // GET: api/Provincias/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._provinciaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		/*
        // POST api/Distritos/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Distrito model)
        {
            return Ok(
                _distritoService.Add(model)
            );
        }


        // PUT api/Distritos/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Distrito model)
        {
            return Ok(
                _distritoService.Update(model)
            );
        }

        // DELETE api/Distritos/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _distritoService.Delete(obj)
            );
        }

        // GET api/Distritos/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _distritoService.Get(id)
            );
        }
		*/

    }
}
