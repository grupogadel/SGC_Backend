using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.InterfaceServices.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.MineralReception
{
    [Route("api/[controller]")]
    [ApiController]
    public class RumaController : ControllerBase
    {
        IServiceRuma _rumaService;
        public RumaController(IServiceRuma rumaService)
        {
            this._rumaService = rumaService;
        }

        // GET: api/Ruma/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._rumaService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // POST api/Ruma/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Ruma model)
        {
            return Ok(
                _rumaService.Add(model)
            );
        }

        // POST api/Ruma/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Ruma model)
        {
            return Ok(
                _rumaService.Update(model)
            );
        }

        // DELETE api/Ruma/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _rumaService.Delete(obj)
            );
        }

        // GET: api/Ruma/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._rumaService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // GET api/Ruma/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _rumaService.Get(id)
            );
        }

        // GET: api/Ruma/SearchLote/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> SearchLote(JObject obj)
        {
            try
            {
                var result = await this._rumaService.SearchLote(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // GET api
    }
}
