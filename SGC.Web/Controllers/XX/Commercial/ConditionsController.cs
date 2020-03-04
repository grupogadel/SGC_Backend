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

        // GET: api/Conditions/GetAllByZones/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllByZones(int id)
        {
            try
            {
                var result = await this._conditionService.GetAllByZones(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/Conditions/AddByZones/
        [HttpPost("[action]")]
        public IActionResult AddByZones([FromBody] Conditions model)
        {
            return Ok(
                _conditionService.AddByZones(model)
            );
        }


        // PUT api/Conditions/UpdateByZones/
        [HttpPut("[action]")]
        public IActionResult UpdateByZones([FromBody] Conditions model)
        {
            return Ok(
                _conditionService.UpdateByZones(model)
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

        // GET: api/Conditions/GetAllByOrigins/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllByOrigins(int id)
        {
            try
            {
                var result = await this._conditionService.GetAllByOrigins(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/Conditions/AddByOrigins/
        [HttpPost("[action]")]
        public IActionResult AddByOrigins([FromBody] Conditions model)
        {
            return Ok(
                _conditionService.AddByOrigins(model)
            );
        }


        // PUT api/Conditions/UpdateByOrigins/
        [HttpPut("[action]")]
        public IActionResult UpdateByOrigins([FromBody] Conditions model)
        {
            return Ok(
                _conditionService.UpdateByOrigins(model)
            );
        }

        // GET: api/Conditions/GetAllByVendors/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllByVendors(int id)
        {
            try
            {
                var result = await this._conditionService.GetAllByVendors(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        // POST api/Conditions/AddByVendors/
        [HttpPost("[action]")]
        public IActionResult AddByVendors([FromBody] Conditions model)
        {
            return Ok(
                _conditionService.AddByVendors(model)
            );
        }


        // PUT api/Conditions/UpdateByVendors/
        [HttpPut("[action]")]
        public IActionResult UpdateByVendors([FromBody] Conditions model)
        {
            return Ok(
                _conditionService.UpdateByVendors(model)
            );
        }


        /*
        // GET api/Conditions/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _conditionService.Get(id)
            );
        }
        */
    }
}
