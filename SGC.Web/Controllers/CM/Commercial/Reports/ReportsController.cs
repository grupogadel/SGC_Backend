using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Reports;
using SGC.InterfaceServices.CM.Commercial.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.Commercial.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        IServiceReports _reportsService;
        public ReportsController(IServiceReports reportsService)
        {
            this._reportsService = reportsService;
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> SearchTimeProc([FromBody] JObject obj)
        {
            try
            {
                var result = await this._reportsService.SearchTimeProc(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SearchMineralBatchLiiquidation([FromBody] JObject obj)
        {
            try
            {
                var result = await this._reportsService.SearchMineralBatchLiiquidation(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
