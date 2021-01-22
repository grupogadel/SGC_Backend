using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.WK;
using SGC.InterfaceServices.WK;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.DataMaster
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class PositionController : ControllerBase
    {
        IServicePosition _positionService;
        public PositionController(IServicePosition positionService)
        {
            this._positionService = positionService;
        }

        // POST api/Position/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Position model)
        {
            return Ok(
                _positionService.Add(model)
            );
        }


        // POST api/Position/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Position model)
        {
            return Ok(
                _positionService.Update(model)
            );
        }
		
		// POST: api/Position/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._positionService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
