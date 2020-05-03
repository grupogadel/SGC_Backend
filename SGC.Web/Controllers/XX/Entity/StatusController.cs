using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class StatusController : ControllerBase
    {
        IServiceStatus _statusService;
        public StatusController(IServiceStatus statusService)
        {
            this._statusService = statusService;
        }


        // POST api/Status/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Status model)
        {
            return Ok(
                _statusService.Add(model)
            );
        }


        // PUT api/Status/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Status model)
        {
            return Ok(
                _statusService.Update(model)
            );
        }


        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _statusService.ChangeStatus(obj)
            );
        }

        // POST: api/Status/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._statusService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}