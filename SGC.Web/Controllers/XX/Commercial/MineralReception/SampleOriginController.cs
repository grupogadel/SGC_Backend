using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.InterfaceServices.XX.Commercial.MineralReception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Commercial.MineralReception
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class SampleOriginController: ControllerBase
    {
        IServiceSampleOrigin _sampleOriginService;
        public SampleOriginController(IServiceSampleOrigin SampleOriginService)
        {
            this._sampleOriginService = SampleOriginService;
        }

        // GET: api/SampleOrigin/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._sampleOriginService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/SampleOrigin/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] SampleOrigin model)
        {
            return Ok(
                _sampleOriginService.Add(model)
            );
        }


        // PUT api/SampleOrigin/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] SampleOrigin model)
        {
            return Ok(
                _sampleOriginService.Update(model)
            );
        }

        // DELETE api/SampleOrigin/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _sampleOriginService.Delete(obj)
            );
        }

        // POST: api/SampleOrigin/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._sampleOriginService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
