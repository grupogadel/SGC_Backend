using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.InterfaceServices.XX.Commercial.Laboratory;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Commercial.Laboratory
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class LabProcessTypeController : ControllerBase
    {
        IServiceLabProcessType _labProcessTypeService;
        public LabProcessTypeController(IServiceLabProcessType LabProcessTypeService)
        {
            this._labProcessTypeService = LabProcessTypeService;
        }

        // GET: api/LabProcessType/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._labProcessTypeService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/LabProcessType/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] LabProcessType model)
        {
            return Ok(
                _labProcessTypeService.Add(model)
            );
        }


        // PUT api/LabProcessType/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] LabProcessType model)
        {
            return Ok(
                _labProcessTypeService.Update(model)
            );
        }

        // DELETE api/LabProcessType/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _labProcessTypeService.Delete(obj)
            );
        }

        // POST: api/LabProcessType/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._labProcessTypeService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/LabProcessType/Get
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await this._labProcessTypeService.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
