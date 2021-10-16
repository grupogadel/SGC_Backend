using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.InterfaceServices.XX.Finance;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class TaxMasterController : ControllerBase
    {
        IServiceTaxMaster _taxMasterService;
        public TaxMasterController(IServiceTaxMaster taxMasterService)
        {
            this._taxMasterService = taxMasterService;
        }

        // POST: api/TaxMaster/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._taxMasterService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
