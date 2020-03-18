using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.XX.Entity;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class RegionController : ControllerBase
    {
        IServiceRegion _regionService;
        public RegionController(IServiceRegion regionService)
        {
            this._regionService = regionService;
        }

        // GET: api/Region/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._regionService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}