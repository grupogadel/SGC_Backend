using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Laboratory;
using SGC.InterfaceServices.CM.Laboratory;

namespace SGC.Web.Controllers.CM
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class LaboratorySampleAnalysisController : ControllerBase
    {
        IServiceLaboratorySampleAnalysis _laboratorySampleAnalysisService;
        public LaboratorySampleAnalysisController(IServiceLaboratorySampleAnalysis laboratorySampleAnalysisService)
        {
            this._laboratorySampleAnalysisService = laboratorySampleAnalysisService;
        }

        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.ChangeStatus(obj)
            );
        }

        // POST: api/LaboratorySampleAnalysis/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._laboratorySampleAnalysisService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/LaboratorySampleAnalysis/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.Add(obj)
            );
        }

        // POST api/LaboratorySampleAnalysis/AddDetails/
        [HttpPost("[action]")]
        public IActionResult AddDetails([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.AddDetails(obj)
            );
        }

        // POST api/LaboratorySampleAnalysis/RemoveItem/
        [HttpPost("[action]")]
        public IActionResult RemoveItem([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.RemoveItem(obj)
            );
        }

        [HttpPost("[action]")]
        public IActionResult UpdateResults([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.UpdateResults(obj)
            );
        }

        // GET api/LaboratorySampleAnalysis/Get/
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _laboratorySampleAnalysisService.Get(id)
            );
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetConsume(int id)
        {
            try
            {
                var result = await _laboratorySampleAnalysisService.GetConsume(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("[action]")]
        public IActionResult AddConsume([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.AddConsume(obj)
            );
        }

        [HttpPost("[action]")]
        public IActionResult UpdateConsume([FromBody] ConsumeHead model)
        {
            return Ok(
                _laboratorySampleAnalysisService.UpdateConsume(model)
            );
        }

        [HttpPost("[action]")]
        public IActionResult AddRecovery([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.AddRecovery(obj)
            );
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetRecovery(int id)
        {
            try
            {
                var result = await _laboratorySampleAnalysisService.GetRecovery(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("[action]")]
        public IActionResult UpdateRecovery([FromBody] RecoveryHead model)
        {
            return Ok(
                _laboratorySampleAnalysisService.UpdateRecovery(model)
            );
        }

        [HttpPost("[action]")]
        public IActionResult ConsumeEnd([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.ConsumeEnd(obj)
            );
        }

        [HttpPost("[action]")]
        public IActionResult RecoveryEnd([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.RecoveryEnd(obj)
            );
        }

        [HttpPost("[action]")]
        public IActionResult LeyMineralEnd([FromBody] JObject obj)
        {
            return Ok(
                _laboratorySampleAnalysisService.LeyMineralEnd(obj)
            );
        }
    }
}
