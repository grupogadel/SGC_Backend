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
    public class DistrictController : ControllerBase
    {
        IServiceDistrict _districtService;
        public DistrictController(IServiceDistrict DistritoService)
        {
            this._districtService = DistritoService;
        }

        // GET: api/Distritos/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._districtService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Distritos/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] District model)
        {
            return Ok(
                _districtService.Add(model)
            );
        }


        // PUT api/Distritos/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] District model)
        {
            return Ok(
                _districtService.Update(model)
            );
        }

        // DELETE api/Distritos/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _districtService.Delete(obj)
            );
        }

        // GET api/Distritos/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _districtService.Get(id)
            );
        }

    }
}
