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
    public class ComprobanteDePagoController : ControllerBase
    {
        IServiceComprobanteDePago _comprobanteDePagoService;
        public ComprobanteDePagoController(IServiceComprobanteDePago ComprobanteDePagoService)
        {
            this._comprobanteDePagoService = ComprobanteDePagoService;
        }

        // GET: api/ComprobanteDePago/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search()
        {
            try
            {
                var result = await this._comprobanteDePagoService.Search();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
