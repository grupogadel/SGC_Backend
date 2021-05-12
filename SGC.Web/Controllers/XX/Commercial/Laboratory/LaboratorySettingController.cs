using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.InterfaceServices.XX.Commercial.Laboratory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Commercial.Laboratory
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratorySettingController : ControllerBase
    {
        IServiceLaboratorySetting _laboratorySettingService;
        public LaboratorySettingController(IServiceLaboratorySetting laboratorySettingService)
        {
            this._laboratorySettingService = laboratorySettingService;
        }
        // GET: api/LaboratorySetting/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._laboratorySettingService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/LaboratorySetting/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] LaboratorySetting model)
        {
            return Ok(
                _laboratorySettingService.Add(model)
            );
        }

        // POST api/LaboratorySetting/Update
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] LaboratorySetting model)
        {
            return Ok(
                _laboratorySettingService.Update(model)
            );
        }

        // DELETE api/LaboratorySetting/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySettingService.Delete(obj)
            );
        }

        // GET: api/LaboratorySetting/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._laboratorySettingService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("[action]/{id}")]
        public  IActionResult Get(int id)
        {
            try
            {
                var result = this._laboratorySettingService.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetUsed(int id)
        {
            try
            {
                var result = this._laboratorySettingService.GetUsed(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
