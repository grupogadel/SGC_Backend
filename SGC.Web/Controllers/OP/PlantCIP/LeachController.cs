using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.OP.PlantCIP;
using SGC.InterfaceServices.OP.PlantCIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.MineralReception
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeachController : ControllerBase
    {
        IServiceLeach _leachService;
        public LeachController(IServiceLeach leachService)
        {
            this._leachService = leachService;
        }

        // GET: api/Leach/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._leachService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
