using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Operations.Mining
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class AnalysisRequestController : ControllerBase
    {
        IServiceAnalysisRequest _analysisRequestService;
        public AnalysisRequestController(IServiceAnalysisRequest analysisRequestService)
        {
            this._analysisRequestService = analysisRequestService;
        }
        // GET: api/AnalysisRequest/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._analysisRequestService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/AnalysisRequest/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] AnalysisRequest model)
        {
            return Ok(
                _analysisRequestService.Add(model)
            );
        }

        // POST api/AnalysisRequest/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] AnalysisRequest model)
        {
            return Ok(
                _analysisRequestService.Update(model)
            );
        }

        // DELETE api/AnalysisRequest/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _analysisRequestService.Delete(obj)
            );
        }

        // GET: api/AnalysisRequest/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._analysisRequestService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
