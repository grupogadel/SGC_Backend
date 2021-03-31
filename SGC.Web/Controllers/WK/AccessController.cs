using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.WK;
using SGC.InterfaceServices.WK;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.WK
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class AccessController : ControllerBase
    {
        IServiceAccess _accessService;
        public AccessController(IServiceAccess accessService)
        {
            this._accessService = accessService;
        }

        // DELETE api/Access/ChangeStatus/
        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _accessService.ChangeStatus(obj)
            );
        }

        // POST api/Access/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Access model)
        {
            return Ok(
                _accessService.Add(model)
            );
        }


        // POST api/Access/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Access model)
        {
            return Ok(
                _accessService.Update(model)
            );
        }
		
		// POST: api/Access/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._accessService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
