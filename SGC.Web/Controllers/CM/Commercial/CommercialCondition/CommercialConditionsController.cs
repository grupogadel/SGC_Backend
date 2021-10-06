using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.CommercialCondition;
using SGC.InterfaceServices.CM.Commercial.CommercialCondition;

namespace SGC.Web.Controllers.CM.Commercial.CommercialCondition
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class CommercialConditionsController : ControllerBase
    {
        IServiceCommercialConditions _commercialConditionService;
        public CommercialConditionsController(IServiceCommercialConditions CommercialConditionService)
        {
            this._commercialConditionService = CommercialConditionService;
        }

        // GET: api/CommercialConditions/GetAllByZones/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllByZones(int id)
        {
            try
            {
                var result = await this._commercialConditionService.GetAllByZones(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/CommercialConditions/AddByZones/
        [HttpPost("[action]")]
        public IActionResult AddByZones([FromBody] CommercialConditions model)
        {
            return Ok(
                _commercialConditionService.AddByZones(model)
            );
        }


        // PUT api/CommercialConditions/UpdateByZones/
        [HttpPut("[action]")]
        public IActionResult UpdateByZones([FromBody] CommercialConditions model)
        {
            return Ok(
                _commercialConditionService.UpdateByZones(model)
            );
        }

        // DELETE api/CommercialConditions/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _commercialConditionService.Delete(obj)
            );
        }

        // GET: api/CommercialConditions/GetAllByOrigins/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllByOrigins(int id)
        {
            try
            {
                var result = await this._commercialConditionService.GetAllByOrigins(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/CommercialConditions/AddByOrigins/
        [HttpPost("[action]")]
        public IActionResult AddByOrigins([FromBody] CommercialConditions model)
        {
            return Ok(
                _commercialConditionService.AddByOrigins(model)
            );
        }


        // PUT api/CommercialConditions/UpdateByOrigins/
        [HttpPut("[action]")]
        public IActionResult UpdateByOrigins([FromBody] CommercialConditions model)
        {
            return Ok(
                _commercialConditionService.UpdateByOrigins(model)
            );
        }

        // GET: api/CommercialConditions/GetAllByVendors/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllByVendors(int id)
        {
            try
            {
                var result = await this._commercialConditionService.GetAllByVendors(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/CommercialConditions/AddByVendors/
        [HttpPost("[action]")]
        public IActionResult AddByVendors([FromBody] CommercialConditions model)
        {
            return Ok(
                _commercialConditionService.AddByVendors(model)
            );
        }


        // PUT api/CommercialConditions/UpdateByVendors/
        [HttpPut("[action]")]
        public IActionResult UpdateByVendors([FromBody] CommercialConditions model)
        {
            return Ok(
                _commercialConditionService.UpdateByVendors(model)
            );
        }

        // PUT api/CommercialConditions/UpdateByMaquilas/
        [HttpPut("[action]")]
        public IActionResult UpdateByMaquilas([FromBody] CommercialConditions model)
        {
            return Ok(
                _commercialConditionService.UpdateByMaquilas(model)
            );
        }

        // POST: api/CommercialConditions/LiquidationCommercialConditionsSearch
        [HttpPost("[action]")]
        public async Task<IActionResult> LiquidationCommercialConditionsSearch([FromBody] JObject obj)
        {
            try
            {
                var result = await this._commercialConditionService.LiquidationCommercialConditionsSearch(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
