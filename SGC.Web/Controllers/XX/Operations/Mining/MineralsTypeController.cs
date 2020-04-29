using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Operations.Mining
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class MineralsTypeController : ControllerBase
    {
        IServiceMineralsType _mineralsTypeService;
        public MineralsTypeController(IServiceMineralsType mineralsTypeService)
        {
            this._mineralsTypeService = mineralsTypeService;
        }
        // GET: api/MineralsType/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._mineralsTypeService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/MineralsType/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] MineralsType model)
        {
            return Ok(
                _mineralsTypeService.Add(model)
            );
        }

        // POST api/MineralsType/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] MineralsType model)
        {
            return Ok(
                _mineralsTypeService.Update(model)
            );
        }

        // DELETE api/MineralsType/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _mineralsTypeService.Delete(obj)
            );
        }

        // GET: api/MineralsType/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._mineralsTypeService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
