using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.InterfaceServices.CM.MineralReception;

namespace SGC.Web.Controllers.CM.MineralReception
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScalesController : ControllerBase
    {
        IServiceScales _scalesService;
        public ScalesController(IServiceScales ScalesService)
        {
            this._scalesService = ScalesService;
        }

        // GET: api/Scales/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._scalesService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // POST api/Scales/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Scales model)
        {
            return Ok(
                _scalesService.Add(model)
            );
        }
        // DELETE api/Scales/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _scalesService.Delete(obj)
            );
        }

        // PUT api/Scales/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Scales model)
        {
            return Ok(
                _scalesService.Update(model)
            );
        }
    }
}