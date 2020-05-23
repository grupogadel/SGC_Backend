using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Operations.Mining
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class MineralFromController : ControllerBase
    {
        IServiceMineralFrom _mineralFromService;
        public MineralFromController(IServiceMineralFrom mineralFromService)
        {
            this._mineralFromService = mineralFromService;
        }
        // GET: api/MineralFrom/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._mineralFromService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/MineralFrom/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] MineralFrom model)
        {
            return Ok(
                _mineralFromService.Add(model)
            );
        }

        // POST api/MineralFrom/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] MineralFrom model)
        {
            return Ok(
                _mineralFromService.Update(model)
            );
        }

        // DELETE api/MineralFrom/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _mineralFromService.Delete(obj)
            );
        }

        // GET: api/MineralFrom/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._mineralFromService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
