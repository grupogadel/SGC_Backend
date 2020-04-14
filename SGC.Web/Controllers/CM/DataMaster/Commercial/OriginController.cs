using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster.Commercial;
using SGC.InterfaceServices.CM.DataMaster.Commercial;

namespace SGC.Web.Controllers.CM.DataMaster.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class OriginController : ControllerBase
    {
        IServiceOrigin _originService;
        public OriginController(IServiceOrigin OriginService)
        {
            this._originService = OriginService;
        }

        // GET: api/Origin/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._originService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Origin/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Origin model)
        {
            return Ok(
                _originService.Add(model)
            );
        }


        // PUT api/Origin/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Origin model)
        {
            return Ok(
                _originService.Update(model)
            );
        }

        // DELETE api/Origin/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _originService.Delete(obj)
            );
        }

        // GET api/Origin/Get/1
        /*[HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _originService.Get(id)
            );
        }
        */
    }
}
