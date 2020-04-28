using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Entity
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class CorrelDocumentsController: ControllerBase
    {
        IServiceCorrelDocuments _correlDocumentsService;
        public CorrelDocumentsController(IServiceCorrelDocuments CorrelDocumentsService)
        {
            this._correlDocumentsService = CorrelDocumentsService;
        }

        // GET: api/CorrelDocuments/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._correlDocumentsService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/CorrelDocuments/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] CorrelDocuments model)
        {
            return Ok(
                _correlDocumentsService.Update(model)
            );
        }

        // GET: api/CorrelDocuments/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._correlDocumentsService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
