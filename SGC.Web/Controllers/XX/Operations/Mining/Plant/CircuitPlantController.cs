using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining.Plant;
using SGC.InterfaceServices.XX.Operations.Mining.Plant;

namespace SGC.Web.Controllers.XX.Operations.Mining.Plant
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class CircuitPlantController : ControllerBase
    {
        IServiceCircuitPlant _circuitPlantService;
        public CircuitPlantController(IServiceCircuitPlant circuitPlantService)
        {
            this._circuitPlantService = circuitPlantService;
        }

        // GET: api/CircuitPlant/Get/{}
        [HttpPost("[action]")]
        public IActionResult Get(JObject obj)
        {
            try
            {
                var result = this._circuitPlantService.Get(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
