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
    public class ModuleController : ControllerBase
    {
        IServiceModule _moduleService;
        public ModuleController(IServiceModule moduleService)
        {
            this._moduleService = moduleService;
        }

        // GET: api/Module/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._moduleService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Module/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Module model)
        {
            return Ok(
                _moduleService.Add(model)
            );
        }


        // POST api/Module/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Module model)
        {
            return Ok(
                _moduleService.Update(model)
            );
        }
		
		// POST: api/Module/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._moduleService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
