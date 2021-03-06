using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.CommercialCondition;
using SGC.InterfaceServices.CM.Commercial.CommercialCondition;

namespace SGC.Web.Controllers.XX.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class MaquilaCommercialController : ControllerBase
    {
        IServiceMaquilaCommercial _maquilaCommercialService;
        public MaquilaCommercialController(IServiceMaquilaCommercial MaquilaCommercialService)
        {
            this._maquilaCommercialService = MaquilaCommercialService;
        }

        // GET: api/MaquilaCommercial/GetAll/1/1
        [HttpGet("[action]/{id}/{cond}")]
        public async Task<IActionResult> GetAll(int id, int cond)
        {
            try
            {
                var result = await this._maquilaCommercialService.GetAll(id, cond);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
