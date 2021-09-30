using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster.CollectorControl;
using SGC.InterfaceServices.CM.DataMaster.CollectorControl;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.DataMaster.Commercial.CollectorControl
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class ExpCollectMasterController: ControllerBase
    {
        IServiceExpCollectMaster _expCollectMasterService;
        public ExpCollectMasterController(IServiceExpCollectMaster expCollectMasterService)
        {
            this._expCollectMasterService = expCollectMasterService;
        }

        //POST: api/ExpCollectMaster/GetAllM
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllM(JObject obj)
        {
            try
            {
                var result = await this._expCollectMasterService.GetAllM(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/ExpCollectMaster/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> SearchM(JObject obj)
        {
            try
            {
                var result = await this._expCollectMasterService.SearchM(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/ExpCollectMaster/Add/{}
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] ExpCollectMaster model)
        {
            return Ok(
                _expCollectMasterService.Add(model)
            );
        }

        // PUT api/ExpCollectMaster/Update/{}
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] ExpCollectMaster model)
        {
            return Ok(
                _expCollectMasterService.Update(model)
            );
        }

        // DELETE api/ExpCollectMaster/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _expCollectMasterService.Delete(obj)
            );
        }

        
    }
}
