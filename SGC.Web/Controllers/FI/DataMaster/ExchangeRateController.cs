using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.FI.DataMaster;
using SGC.InterfaceServices.FI.DataMaster;

namespace SGC.Web.Controllers.FI.DataMaster
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class ExchangeRateController : ControllerBase
    {
        IServiceExchangeRate _exchangeRateService;
        public ExchangeRateController(IServiceExchangeRate ExchangeRateService)
        {
            this._exchangeRateService = ExchangeRateService;
        }

        // GET: api/ExchangeRate/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._exchangeRateService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/ExchangeRate/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] ExchangeRate model)
        {
            return Ok(
                _exchangeRateService.Add(model)
            );
        }


        // PUT api/ExchangeRate/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] ExchangeRate model)
        {
            return Ok(
                _exchangeRateService.Update(model)
            );
        }

        // DELETE api/ExchangeRate/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _exchangeRateService.ChangeStatus(obj)
            );
        }

        // GET api/ExchangeRate/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _exchangeRateService.Get(id)
            );
        }

        // GET: api/ExchangeRate/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._exchangeRateService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
