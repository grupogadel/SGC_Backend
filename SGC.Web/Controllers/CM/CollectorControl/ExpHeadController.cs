using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.CollectorControl;
using SGC.InterfaceServices.CM.CollectorControl;

namespace SGC.Web.Controllers.CM.CollectorControl
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class ExpHeadController : ControllerBase
    {
        IServiceExpHead _expHeadService;
        public ExpHeadController(IServiceExpHead ExpHeadService)
        {
            this._expHeadService = ExpHeadService;
        }

        // POST api/ExpHead/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] ExpHead model)
        {
            return Ok(
                _expHeadService.Add(model)
            );
        }


        // PUT api/ExpHead/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] ExpHead model)
        {
            return Ok(
                _expHeadService.Update(model)
            );
        }

    

        // GET api/ExpHead/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _expHeadService.Get(id)
            );
        }

        // GET: api/ExpHead/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._expHeadService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
