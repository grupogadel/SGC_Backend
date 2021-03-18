using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.WK;
using SGC.InterfaceServices.WK;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.DataMaster
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class LoginController : ControllerBase
    {
        IServiceLogin _loginService;
        public LoginController(IServiceLogin loginService)
        {
            this._loginService = loginService;
        }

        // POST: api/Login/LoginUser/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginUser([FromBody] JObject obj)
        {
            try
            {
                var result = await this._loginService.LoginUser(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

        // GET: api/Login/NavigationMenuGet/{}
        [HttpGet("[action]/{idPosition}")]
        public async Task<IActionResult> NavigationMenuGet(int idPosition)
        {
            try
            {
                var result = await this._loginService.NavigationMenuGet(idPosition);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }
    }
}
