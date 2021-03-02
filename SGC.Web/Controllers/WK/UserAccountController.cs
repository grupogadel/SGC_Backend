using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGC.Entities.Entities.WK;
using SGC.InterfaceServices.WK;
using Newtonsoft.Json.Linq;

namespace SGC.Web.Controllers.WK
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class UserAccountController : ControllerBase
    {
        IServiceUserAccount _userAccountService;
        public UserAccountController(IServiceUserAccount userAccountService)
        {
            this._userAccountService = userAccountService;
        }

        // GET: api/UserAccount/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._userAccountService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
		
		// GET api/UserAccount/GetAllPositionByUser/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllPositionByUser(int id)
        {
            try
            {
                var result = await this._userAccountService.GetAllPositionByUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
        // GET api/UserAccount/GetUserAccount/1
        [HttpGet("[action]/{dni}")]
        public IActionResult GetUserAccount(string dni)
        {
            return Ok(
                _userAccountService.GetUserAccount(dni)
            );
        }
		
		// GET api/UserAccount/GetPerson/1
        [HttpGet("[action]/{dni}")]
        public IActionResult GetPerson(string dni)
        {
            return Ok(
                _userAccountService.GetPerson(dni)
            );
        }
		
        // POST api/UserAccount/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] JObject obj)
        {
            return Ok(
                _userAccountService.Add(obj)
            );
        }


        // POST api/UserAccount/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] UserAccount model)
        {
            return Ok(
                _userAccountService.Update(model)
            );
        }
		
		// POST api/UserAccount/UpdateUserPosition/
        [HttpPut("[action]")]
        public IActionResult UpdateUserPosition([FromBody] UserAccount model)
        {
            return Ok(
                _userAccountService.UpdateUserPosition(model)
            );
        }


    }

}
