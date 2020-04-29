using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Operations.Mining;

namespace SGC.Web.Controllers.XX.Operations.Mining
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class WorkShiftsController : ControllerBase
    {
        IServiceWorkShifts _workShiftsService;
        public WorkShiftsController(IServiceWorkShifts workShiftsService)
        {
            this._workShiftsService = workShiftsService;
        }

        // GET: api/WorkShifts/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._workShiftsService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/WorkShifts/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] WorkShifts model)
        {
            return Ok(
                _workShiftsService.Add(model)
            );
        }

        // POST api/WorkShifts/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] WorkShifts model)
        {
            return Ok(
                _workShiftsService.Update(model)
            );
        }

        // DELETE api/WorkShifts/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _workShiftsService.Delete(obj)
            );
        }

        // GET: api/WorkShifts/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._workShiftsService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
