using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.XX.Commercial.Laboratory;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Commercial.Laboratory
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class AnalisysTypeController : ControllerBase
    {
        IServiceAnalisysType _analisysTypeService;
        public AnalisysTypeController(IServiceAnalisysType analisysTypeService)
        {
            this._analisysTypeService = analisysTypeService;
        }
        // GET: api/AnalisysType/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._analisysTypeService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
