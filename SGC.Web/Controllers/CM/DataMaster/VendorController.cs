using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
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
    public class VendorController:ControllerBase
    {
        IServiceVendor _vendorService;
        public VendorController(IServiceVendor VendorService)
        {
            this._vendorService = VendorService;
        }
        // GET: api/Vendor/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._vendorService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // POST api/Vendor/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Vendor model)
        {
            return Ok(
                _vendorService.Add(model)
            );
        }

        // PUT api/Vendor/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Vendor model)
        {
            return Ok(
                _vendorService.Update(model)
            );
        }

        // DELETE api/Vendor/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _vendorService.Delete(obj)
            );
        }

        // GET api/Vendor/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _vendorService.Get(id)
            );
        }

    }
}
