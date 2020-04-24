using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    }
}
