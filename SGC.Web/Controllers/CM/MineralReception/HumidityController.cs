using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.InterfaceServices.CM.MineralReception;
using SGC.Entities.Entities.CM.Laboratory;

namespace SGC.Web.Controllers.FI.DataMaster
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class HumidityController : ControllerBase
    {
        IServiceHumidity _humidityService;
        public HumidityController(IServiceHumidity HumidityService)
        {
            this._humidityService = HumidityService;
        }

        // POST api/Humidity/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] JObject obj)
        {
            return Ok(
                _humidityService.Add(obj)
            );
        }


        // PUT api/Humidity/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Humidity model)
        {
            return Ok(
                _humidityService.Update(model)
            );
        }

        // DELETE api/Humidity/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _humidityService.ChangeStatus(obj)
            );
        }

        // POST: api/Humidity/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._humidityService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Humidity/SampleNoHumidity
        [HttpPost("[action]")]
        public async Task<IActionResult> SampleNoHumidity([FromBody] JObject obj)
        {
            try
            {
                var result = await this._humidityService.SampleNoHumidity(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
