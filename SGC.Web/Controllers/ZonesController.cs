using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.BatchMineral;

namespace SGC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        IServiceZone _zoneService { get; }

        public ZonesController(IServiceZone zoneService)
        {
            this._zoneService = zoneService;
        }

        // GET: api/Zones
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            //return await _context.Zones.ToListAsync();
            try
            {
                var result = await this._zoneService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
