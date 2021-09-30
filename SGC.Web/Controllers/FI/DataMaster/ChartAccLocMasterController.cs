using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.FI.DataMaster;
using SGC.InterfaceServices.FI.DataMaster;

namespace SGC.Web.Controllers.FI.DataMaster
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class ChartAccLocMasterController : ControllerBase
    {
        IServiceChartAccLocMaster _chartAccLocMasterService;
        public ChartAccLocMasterController(IServiceChartAccLocMaster ChartAccLocMasterService)
        {
            this._chartAccLocMasterService = ChartAccLocMasterService;
        }

        // GET: api/ExchangeRate/GetAll
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(JObject obj)
        {
            try
            {
                var result = await this._chartAccLocMasterService.GetAll(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
