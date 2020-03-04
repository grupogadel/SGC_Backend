using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.CM.DataMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.DataMaster
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class VendorOriginController : ControllerBase
    {
        IServiceVendorOrigin _vendorOriginService;
        public VendorOriginController(IServiceVendorOrigin VendorOriginService)
        {
            this._vendorOriginService = VendorOriginService;
        }

        // GET: api/VendorOrigin/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllVendors(int id)
        {
            try
            {
                var result = await this._vendorOriginService.GetAllVendors(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
