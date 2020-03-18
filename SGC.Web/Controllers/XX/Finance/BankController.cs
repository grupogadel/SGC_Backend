using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.XX.Finance;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class BankController : ControllerBase
    {
        IServiceBank _bankService;
        public BankController(IServiceBank bankService)
        {
            this._bankService = bankService;
        }

        // GET: api/Bank/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._bankService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
