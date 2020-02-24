using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using SGC.InterfaceServices.XX.Commercial;

namespace SGC.Web.Controllers.XX.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class ConditionsController : ControllerBase
    {
        IServiceConditions _conditionService;
        public ConditionsController(IServiceConditions ConditionService)
        {
            this._conditionService = ConditionService;
        }

        // GET: api/Conditions/GetAll/{}
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._conditionService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Conditions/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Conditions model)
        {
            return Ok(
                _conditionService.Add(model)
            );
        }


        // PUT api/Conditions/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Conditions model)
        {
            return Ok(
                _conditionService.Update(model)
            );
        }

        // DELETE api/Conditions/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _conditionService.Delete(obj)
            );
        }

        // GET api/Conditions/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _conditionService.Get(id)
            );
        }

    }
}
