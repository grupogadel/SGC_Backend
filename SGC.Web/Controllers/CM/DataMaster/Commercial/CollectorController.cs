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
        public IActionResult Add([FromBody] JObject obj)
        {
            return Ok(
                _collectorService.Add(obj)
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


        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _collectorService.ChangeStatus(obj)
            );
        }

        // POST: api/Company/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._collectorService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Company/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> GetDni([FromBody] JObject obj)
        {
            try
            {
                var result = await this._collectorService.GetDni(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

        // GET api/Collector/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _collectorService.Get(id)
            );
        }
        // GET api/Collector/GetRuc/1
        [HttpGet("[action]/{id}")]
        public IActionResult GetRuc(int id)
        {
            return Ok(
                _collectorService.GetRuc(id)
            );
        }
    }
}
