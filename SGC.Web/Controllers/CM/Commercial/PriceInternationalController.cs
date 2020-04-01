using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial;
using SGC.InterfaceServices.CM.Commercial;

namespace SGC.Web.Controllers.FI.DataMaster
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class PriceInternationalController : ControllerBase
    {
        IServicePriceInternational _priceInternationalService;
        public PriceInternationalController(IServicePriceInternational PriceInternationalService)
        {
            this._priceInternationalService = PriceInternationalService;
        }

        // POST api/PriceInternational/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] PriceInternational model)
        {
            return Ok(
                _priceInternationalService.Add(model)
            );
        }


        // PUT api/PriceInternational/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] PriceInternational model)
        {
            return Ok(
                _priceInternationalService.Update(model)
            );
        }

        // DELETE api/PriceInternational/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _priceInternationalService.ChangeStatus(obj)
            );
        }

        // GET api/PriceInternational/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _priceInternationalService.Get(id)
            );
        }

        // GET: api/PriceInternational/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._priceInternationalService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
