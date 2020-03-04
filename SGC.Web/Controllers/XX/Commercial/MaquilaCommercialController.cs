using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using SGC.InterfaceServices.XX.Commercial;

namespace SGC.Web.Controllers.XX.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class MaquilaCommercialController : ControllerBase
    {
        IServiceMaquilaCommercial _maquilaCommercialService;
        public MaquilaCommercialController(IServiceMaquilaCommercial MaquilaCommercialService)
        {
            this._maquilaCommercialService = MaquilaCommercialService;
        }

        // GET: api/MaquilaCommercial/GetAll/1/1
        [HttpGet("[action]/{id}/{cond}")]
        public async Task<IActionResult> GetAll(int id, int cond)
        {
            try
            {
                var result = await this._maquilaCommercialService.GetAll(id, cond);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/MaquilaCommercial/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] MaquilaCommercial model)
        {
            return Ok(
                _maquilaCommercialService.Add(model)
            );
        }


        // PUT api/MaquilaCommercial/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] MaquilaCommercial model)
        {
            return Ok(
                _maquilaCommercialService.Update(model)
            );
        }

        // DELETE api/MaquilaCommercial/Delete/{}
        [HttpDelete("[action]/{id}/{user}")]
        public IActionResult Delete(int id, string user)
        {
            return Ok(
                _maquilaCommercialService.Delete(id, user)
            );
        }

    }
}
