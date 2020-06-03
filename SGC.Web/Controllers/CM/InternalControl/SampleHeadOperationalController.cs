using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.InternalControl;
using SGC.InterfaceServices.CM.InternalControl;

namespace SGC.Web.Controllers.CM
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class SampleHeadOperationalController : ControllerBase
    {
        IServiceSampleHeadOperational _sampleHeadOperationalService;
        public SampleHeadOperationalController(IServiceSampleHeadOperational sampleHeadOperationalService)
        {
            this._sampleHeadOperationalService = sampleHeadOperationalService;
        }

        // POST api/SampleHeadOperational/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] SampleHeadOperational model)
        {
            return Ok(
                _sampleHeadOperationalService.Add(model)
            );
        }

        // PUT api/SampleHeadOperational/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] SampleHeadOperational model)
        {
            return Ok(
                _sampleHeadOperationalService.Update(model)
            );
        }


        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _sampleHeadOperationalService.ChangeStatus(obj)
            );
        }

        // POST: api/SampleHeadOperational/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._sampleHeadOperationalService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/SampleHeadOperational/GetAllArea
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllArea(int id)
        {
            try
            {
                var result = await this._sampleHeadOperationalService.GetAllArea(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
