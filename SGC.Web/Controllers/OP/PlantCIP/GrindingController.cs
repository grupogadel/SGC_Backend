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
    public class GrindingController : ControllerBase
    {
        IServiceGrinding _grindingService;
        public GrindingController(IServiceGrinding grindingService)
        {
            this._grindingService = grindingService;
        }

        // GET: api/Grinding/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._grindingService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
