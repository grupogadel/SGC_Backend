using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Collect;
using SGC.InterfaceServices.CM.Collect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.Collect
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToPayCollectorController : ControllerBase
    {
        IServiceToPayCollector _toPayCollectorService;
        public ToPayCollectorController(IServiceToPayCollector toPayCollectorService)
        {
            this._toPayCollectorService = toPayCollectorService;
        }

        // POST: api/ToPayCollector/Search/
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._toPayCollectorService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/ToPayCollector/Search/
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await this._toPayCollectorService.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/ToPayCollector/Add/
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] ToPayCollector model)
        {
            try
            {
                var result = await this._toPayCollectorService.Add(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/ToPayCollector/Update/1
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] ToPayCollector model)
        {
            try
            {
                var result = await this._toPayCollectorService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // DELETE api/ToPayCollector/ChangeStatus/{}
        [HttpDelete("[action]")]
        public async Task<IActionResult> ChangeStatus([FromBody] JObject obj)
        {
            try
            {
                var result = await this._toPayCollectorService.ChangeStatus(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
