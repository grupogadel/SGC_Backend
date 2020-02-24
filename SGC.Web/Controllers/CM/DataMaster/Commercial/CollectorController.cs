using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.InterfaceServices.CM.DataMaster;

namespace SGC.Web.Controllers.CM.DataMaster.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class CollectorController : ControllerBase
    {
        IServiceCollector _collectorService;
        public CollectorController(IServiceCollector CollectorService)
        {
            this._collectorService = CollectorService;
        }

        // GET: api/Collector/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._collectorService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Collector/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Collector model)
        {
            return Ok(
                _collectorService.Add(model)
            );
        }


        // PUT api/Collector/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Collector model)
        {
            return Ok(
                _collectorService.Update(model)
            );
        }

        // DELETE api/Collector/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _collectorService.Delete(obj)
            );
        }

        // GET api/Collector/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _collectorService.Get(id)
            );
        }

    }
}
