using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class MPeriodController : ControllerBase
    {
        IServiceMPeriod _mPeriodService;
        public MPeriodController(IServiceMPeriod mPeriodService)
        {
            this._mPeriodService = mPeriodService;
        }

        // GET: api/Moneda/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._mPeriodService.GetAll();
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
                _mPeriodService.Get(id)
            );
        }

    }
}
