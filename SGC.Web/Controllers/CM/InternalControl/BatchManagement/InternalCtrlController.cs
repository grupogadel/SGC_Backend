using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.InterfaceServices.CM.InternalControl.BatchManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.InternalControl.BatchManagement
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class InternalCtrlController : ControllerBase
    {
        IServiceInternalCtrl _internalCtrlService;
        public InternalCtrlController(IServiceInternalCtrl InternalCtrlService)
        {
            this._internalCtrlService = InternalCtrlService;
        }

        // GET: api/InternalCtrl/GetAll/1
        [HttpGet("[action]/{id}")]
        public IActionResult GetAll(int id)
        {
            try
            {
                var result = this._internalCtrlService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/InternalCtrl/AddPuruna
        [HttpPost("[action]")]
        public IActionResult AddPuruna([FromBody] JObject obj)
        {
            return Ok(
                _internalCtrlService.AddPuruna(obj)
            );
        }

        // POST api/InternalCtrl/AddReq
        [HttpPost("[action]")]
        public IActionResult AddReq([FromBody] JObject obj)
        {
            return Ok(
                _internalCtrlService.AddReq(obj)
            );
        }
		
		// DELETE api/InternalCtrl/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _internalCtrlService.Delete(obj)
            );
        }

        // POST api/InternalCtrl/AddLabExt
        [HttpPost("[action]")]
        public IActionResult AddLabExt([FromBody] JObject obj)
        {
            return Ok(
                _internalCtrlService.AddLabExt(obj)
            );
        }

        // PUT api/InternalCtrl/Approve
        [HttpPut("[action]")]
        public IActionResult Approve([FromBody] JObject obj)
        {
            return Ok(
                _internalCtrlService.Approve(obj)
            );
        }
		
	    // POST: api/InternalCtrl/SearchCommercial/{}
        [HttpPost("[action]")]
        public IActionResult SearchCommercial([FromBody] JObject obj)
        {
            try
            {
                var result = this._internalCtrlService.SearchCommercial(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/InternalCtrl/SearchCommercialInt/{}
        [HttpPost("[action]")]
        public IActionResult SearchCommercialInt([FromBody] JObject obj)
        {
            try
            {
                var result = this._internalCtrlService.SearchCommercialInt(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/InternalCtrl/SearchOperational/{}
        [HttpPost("[action]")]
        public IActionResult SearchOperational([FromBody] JObject obj)
        {
            try
            {
                var result = this._internalCtrlService.SearchOperational(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/InternalCtrl/SearchOperationalInt/{}
        [HttpPost("[action]")]
        public IActionResult SearchOperationalInt([FromBody] JObject obj)
        {
            try
            {
                var result = this._internalCtrlService.SearchOperationalInt(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
