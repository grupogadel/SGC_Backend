using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.MineralReception
{
    [Route("api/[controller]")]
    [ApiController]
    public class RumaController : ControllerBase
    {
        IServiceRuma _rumaService;
        public RumaController(IServiceRuma rumaService)
        {
            this._rumaService = rumaService;
        }

        // GET: api/Ruma/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._rumaService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
