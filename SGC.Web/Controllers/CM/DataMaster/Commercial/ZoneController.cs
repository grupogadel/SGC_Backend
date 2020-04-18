using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.InterfaceServices.CM.DataMaster;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.DataMaster
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class ZoneController : ControllerBase
    {
        IServiceZone _zoneService;
        public ZoneController(IServiceZone zoneService)
        {
            this._zoneService = zoneService;
        }

        // GET: api/Zone/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._zoneService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Zone/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Zone model)
        {
            return Ok(
                _zoneService.Add(model)
            );
        }


        // POST api/Zone/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Zone model)
        {
            return Ok(
                _zoneService.Update(model)
            );
        }

        // DELETE api/Zone/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _zoneService.Delete(obj)
            );
        }

        // GET: api/Zone/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._zoneService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/Zone/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _zoneService.Get(id)
            );
        }

    }
}
