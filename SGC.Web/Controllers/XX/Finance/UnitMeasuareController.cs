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
    public class UnitMeasuareController : ControllerBase
    {
        IServiceUnitMeasuare _unitMeasuareService;
        public UnitMeasuareController(IServiceUnitMeasuare unitMeasuareService)
        {
            this._unitMeasuareService = unitMeasuareService;
        }

        // POST api/UnitMeasuare/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] UnitMeasuare model)
        {
            return Ok(
                _unitMeasuareService.Add(model)
            );
        }


        // PUT api/UnitMeasuare/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] UnitMeasuare model)
        {
            return Ok(
                _unitMeasuareService.Update(model)
            );
        }


        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _unitMeasuareService.ChangeStatus(obj)
            );
        }

        // POST: api/UnitMeasuare/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._unitMeasuareService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
