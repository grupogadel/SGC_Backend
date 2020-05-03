using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class LanguageController : ControllerBase
    {
        IServiceLanguage _languageService;
        public LanguageController(IServiceLanguage languageService)
        {
            this._languageService = languageService;
        }


        // POST api/Language/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Language model)
        {
            return Ok(
                _languageService.Add(model)
            );
        }


        // PUT api/Language/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Language model)
        {
            return Ok(
                _languageService.Update(model)
            );
        }


        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _languageService.ChangeStatus(obj)
            );
        }

        // POST: api/Language/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._languageService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}