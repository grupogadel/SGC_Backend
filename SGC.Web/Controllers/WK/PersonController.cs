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
    public class PersonController : ControllerBase
    {
        IServicePerson _personService;
        public PersonController(IServicePerson personService)
        {
            this._personService = personService;
        }
		
		// GET: api/Person/GetAll/
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._personService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/Person/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Person model)
        {
            return Ok(
                _personService.Add(model)
            );
        }


        // POST api/Person/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Person model)
        {
            return Ok(
                _personService.Update(model)
            );
        }
		
		// POST: api/Position/Search/{}
        /*[HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._positionService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}
