
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.InterfaceServices.CM.Commercial.SampleReferential;
using System;

namespace SGC.Web.Controllers.CM.Commercial.SampleReferential
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class SampleReferentialController: ControllerBase
    {
        IServiceSampleReferential _sampleReferentialService;
        public SampleReferentialController(IServiceSampleReferential SampleReferentialService)
        {
            this._sampleReferentialService = SampleReferentialService;
        }

        // POST: api/SampleReferential/GetAll/{}
        [HttpPost("[action]")]
        public IActionResult GetAll([FromBody] JObject obj)
        {
            try
            {
                var result = this._sampleReferentialService.GetAll(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/SampleReferential/GetAllByApprover/{}
        [HttpPost("[action]")]
        public IActionResult GetAllByApprover([FromBody] JObject obj)
        {
            try
            {
                var result = this._sampleReferentialService.GetAllByApprover(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/SampleReferential/Add
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] JObject obj)
        {
            return Ok(
                _sampleReferentialService.Add(obj)
            );
        }


        // PUT api/SampleReferential/Update
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] JObject obj)
        {
            return Ok(
                _sampleReferentialService.Update(obj)
            );
        }

        // DELETE api/SampleReferential/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _sampleReferentialService.Delete(obj)
            );
        }

        // POST: api/SampleReferential/Search/{}
        [HttpPost("[action]")]
        public IActionResult Search([FromBody] JObject obj)
        {
            try
            {
                var result = this._sampleReferentialService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/SampleReferential/SearchByApprover/{}
        [HttpPost("[action]")]
        public IActionResult SearchByApprover([FromBody] JObject obj)
        {
            try
            {
                var result = this._sampleReferentialService.SearchByApprover(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
