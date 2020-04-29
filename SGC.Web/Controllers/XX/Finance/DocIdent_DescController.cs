using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Finance;
using SGC.InterfaceServices.XX.Finance;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class DocIdentityController : ControllerBase
    {
        IServiceDocIdentity _docIdentityService;
        public DocIdentityController(IServiceDocIdentity docIdentityService)
        {
            this._docIdentityService = docIdentityService;
        }

        // GET: api/DocIdentity/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._docIdentityService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // POST api/DocIdentity/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] DocIdentity model)
        {
            return Ok(
                _docIdentityService.Add(model)
            );
        }

        // POST api/DocIdentity/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] DocIdentity model)
        {
            return Ok(
                _docIdentityService.Update(model)
            );
        }

        // DELETE api/DocIdentity/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _docIdentityService.Delete(obj)
            );
        }

        // GET: api/DocIdentity/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._docIdentityService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
