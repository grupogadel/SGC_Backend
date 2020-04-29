using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.InterfaceServices.XX.Commercial.Laboratory;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Commercial.Laboratory
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class AnalisysTypeController : ControllerBase
    {
        IServiceAnalisysType _analisysTypeService;
        public AnalisysTypeController(IServiceAnalisysType analisysTypeService)
        {
            this._analisysTypeService = analisysTypeService;
        }
        // GET: api/DocIdentity/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._analisysTypeService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/AnalisysType/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] AnalisysType model)
        {
            return Ok(
                _analisysTypeService.Add(model)
            );
        }

        // POST api/AnalisysType/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] AnalisysType model)
        {
            return Ok(
                _analisysTypeService.Update(model)
            );
        }

        // DELETE api/AnalisysType/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _analisysTypeService.Delete(obj)
            );
        }

        // GET: api/AnalisysType/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._analisysTypeService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
