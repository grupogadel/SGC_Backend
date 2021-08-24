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
    public class ExpCollectorHeadController : ControllerBase
    {
        IServiceExpCollectorHead _expCollectorHeadService;
        public ExpCollectorHeadController(IServiceExpCollectorHead expCollectorHeadService)
        {
            this._expCollectorHeadService = expCollectorHeadService;
        }

        // POST: api/ExpCollectorHead/Search/
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._expCollectorHeadService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/ExpCollectorHead/SearchExpMaster/
        [HttpPost("[action]")]
        public async Task<IActionResult> SearchExpMaster()
        {
            try
            {
                var result = await this._expCollectorHeadService.SearchExpMaster();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/ExpCollectorHead/Add/
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] ExpCollectorHead model)
        {
            try
            {
                var result = await this._expCollectorHeadService.Add(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/ExpCollectorHead/Update/1
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] ExpCollectorHead model)
        {
            try
            {
                var result = await this._expCollectorHeadService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/ExpCollectorHead/GetBatches/{}
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBatches(int id)
        {
            try
            {
                var result = await this._expCollectorHeadService.GetBatches(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
