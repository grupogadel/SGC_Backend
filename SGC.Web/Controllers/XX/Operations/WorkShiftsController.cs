using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.XX.Finance;
using SGC.InterfaceServices.XX.Operations;

namespace SGC.Web.Controllers.XX
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
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._workShiftsService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
