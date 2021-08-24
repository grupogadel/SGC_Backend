using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using SGC.InterfaceServices.XX.Commercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporationParametersController : ControllerBase
    {
        IServiceCorporationParameters _corporationParametersService;
        public CorporationParametersController(IServiceCorporationParameters corporationParametersService)
        {
            this._corporationParametersService = corporationParametersService;
        }
        // GET: api/CorporationParameters/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._corporationParametersService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/CorporationParameters/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] CorporationParameters model)
        {
            return Ok(
                _corporationParametersService.Add(model)
            );
        }

        // POST api/CorporationParameters/Update
       [HttpPut("[action]")]
        public IActionResult Update([FromBody] CorporationParameters model)
        {
            return Ok(
                _corporationParametersService.Update(model)
            );
        }

        // DELETE api/CorporationParameters/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _corporationParametersService.Delete(obj)
            );
        }

        // GET: api/CorporationParameters/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._corporationParametersService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
