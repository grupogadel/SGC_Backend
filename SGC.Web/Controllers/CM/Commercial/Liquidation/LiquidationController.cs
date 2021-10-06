using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Liquidation;
using SGC.InterfaceServices.CM.Commercial.Liquidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.Commercial.Liquidation
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquidationController : ControllerBase
    {
        IServiceLiquidation _liquidationService;
        public LiquidationController(IServiceLiquidation liquidationService)
        {
            this._liquidationService = liquidationService;
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._liquidationService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PriceInternationalGetDay([FromBody] JObject obj)
        {
            try
            {
                var result = await this._liquidationService.PriceInternationalGetDay(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _liquidationService.ChangeStatus(obj)
            );
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] ManagementLiquidation model)
        {
            try
            {   
                var result = await this._liquidationService.Add(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] ManagementLiquidation model)
        {
            try
            {
                var result = await this._liquidationService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
