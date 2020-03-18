using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.XX.Finance;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class DocIdentityController : ControllerBase
    {
        IServiceDocIdentity _docIdentityService;
        public DocIdentityController(IServiceDocIdentity docIdentityService)
        {
            this._docIdentityService = docIdentityService;
        }

        // GET: api/DocIdentity/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._docIdentityService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
