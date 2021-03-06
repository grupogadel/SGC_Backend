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
        public DistrictController(IServiceDistrict DistrictService)
        {
            this._districtService = DistrictService;
        }

        // GET: api/District/GetAll
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


        // POST api/District/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] District model)
        {
            return Ok(
                _districtService.Add(model)
            );
        }


        // PUT api/District/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] District model)
        {
            return Ok(
                _districtService.Update(model)
            );
        }

        // DELETE api/District/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _districtService.Delete(obj)
            );
        }
		
		// POST: api/District/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._districtService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
        /*
        // GET api/District/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _districtService.Get(id)
            );
        }*/

    }
}
