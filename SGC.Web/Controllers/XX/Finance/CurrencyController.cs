using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Finance;
using SGC.InterfaceServices.XX.Finance;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class CurrencyController : ControllerBase
    {
        IServiceCurrency _currencyService;
        public CurrencyController(IServiceCurrency currencyService)
        {
            this._currencyService = currencyService;
        }

        // GET: api/Moneda/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._currencyService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/Moneda/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _currencyService.Get(id)
            );
        }

        // POST api/Currency/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Currency model)
        {
            return Ok(
                _currencyService.Add(model)
            );
        }


        // PUT api/Currency/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Currency model)
        {
            return Ok(
                _currencyService.Update(model)
            );
        }


        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _currencyService.ChangeStatus(obj)
            );
        }

        // POST: api/Currency/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._currencyService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
