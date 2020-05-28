using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception.Sampling;
using SGC.InterfaceServices.CM.MineralReception.Sampling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.MineralReception.Sampling
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class SampleCommercialController: ControllerBase
    {
        IServiceSampleCommercial _sampleCommercialService;
        public SampleCommercialController(IServiceSampleCommercial SampleCommercialService)
        {
            this._sampleCommercialService = SampleCommercialService;
        }

        // GET: api/SampleCommercial/GetAll/1
        [HttpGet("[action]/{id}")]
        public IActionResult GetAll(int id)
        {
            try
            {
                var result = this._sampleCommercialService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/SampleCommercial/Add
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] SampleDetailsCommercial model)
        {
            return Ok(
                _sampleCommercialService.Add(model)
            );
        }


        // PUT api/SampleCommercial/Update
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] SampleDetailsCommercial model)
        {
            return Ok(
                _sampleCommercialService.Update(model)
            );
        }

        // DELETE api/SampleCommercial/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _sampleCommercialService.Delete(obj)
            );
        }
    }
}
