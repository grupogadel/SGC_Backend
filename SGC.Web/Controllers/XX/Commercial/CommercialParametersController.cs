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
    public class CommercialParametersController : ControllerBase
    {
        IServiceCommercialParameters _commercialParametersService;
        public CommercialParametersController(IServiceCommercialParameters commercialParametersService)
        {
            this._commercialParametersService = commercialParametersService;
        }
        // GET: api/LaboratorySetting/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._commercialParametersService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/CommercialParameters/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] CommercialParameters model)
        {
            return Ok(
                _commercialParametersService.Add(model)
            );
        }

        // POST api/CommercialParameters/Update
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] CommercialParameters model)
        {
            return Ok(
                _commercialParametersService.Update(model)
            );
        }

        // DELETE api/CommercialParameters/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _commercialParametersService.Delete(obj)
            );
        }

        // GET: api/CommercialParameters/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._commercialParametersService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
