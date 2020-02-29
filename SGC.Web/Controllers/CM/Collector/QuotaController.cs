using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Collect;
using SGC.InterfaceServices.CM.Collect;

namespace SGC.Web.Controllers.CM.DataMaster.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class QuotaController : ControllerBase
    {
        IServiceQuota _quotaService;
        public QuotaController(IServiceQuota QuotaService)
        {
            this._quotaService = QuotaService;
        }

        // GET: api/Quota/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._quotaService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Quota/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Quota model)
        {
            return Ok(
                _quotaService.Add(model)
            );
        }


        // PUT api/Quota/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Quota model)
        {
            return Ok(
                _quotaService.Update(model)
            );
        }

        // DELETE api/Quota/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _quotaService.Delete(obj)
            );
        }

        // GET api/Quota/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _quotaService.Get(id)
            );
        }

    }
}
