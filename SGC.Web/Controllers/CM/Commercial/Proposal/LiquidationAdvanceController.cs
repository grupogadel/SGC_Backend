using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Proposal;
using SGC.InterfaceServices.CM.Commercial.Proposal;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.Commercial.Proposal
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquidationAdvanceController : ControllerBase
    {
        IServiceLiquidationAdvance _liquidationAdvanceService;
        public LiquidationAdvanceController(IServiceLiquidationAdvance liquidationAdvanceService)
        {
            this._liquidationAdvanceService = liquidationAdvanceService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._liquidationAdvanceService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] ModelProposal model)
        {
            try
            {
                var result = await this._liquidationAdvanceService.Add(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpPut("[action]")]
        public IActionResult Approb([FromBody] JObject obj)
        {
            return Ok(
                _liquidationAdvanceService.Approb(obj)
            );
        }

        [HttpPut("[action]")]
        public IActionResult ApprobRefund([FromBody] JObject obj)
        {
            return Ok(
                _liquidationAdvanceService.ApprobRefund(obj)
            );
        }

        [HttpPost("[action]")]
        public IActionResult ApprobFact([FromBody] JObject obj)
        {
            return Ok(
                _liquidationAdvanceService.ApprobFact(obj)
            );
        }

        [HttpPost("[action]")]
        public IActionResult ApprobDocRefund([FromBody] JObject obj)
        {
            return Ok(
                _liquidationAdvanceService.ApprobDocRefund(obj)
            );
        }
    }
}
