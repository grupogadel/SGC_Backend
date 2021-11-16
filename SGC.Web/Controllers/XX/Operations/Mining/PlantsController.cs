using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Operations.Mining
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class PlantsController : ControllerBase
    {
        IServicePlants _plantsService;
        public PlantsController(IServicePlants plantsService)
        {
            this._plantsService = plantsService;
        }
        // GET: api/Plants/GetAll
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._plantsService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
