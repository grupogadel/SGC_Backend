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
        public async Task<IActionResult> Add([FromBody] JObject obj)
        {
            try
            {
                var result = await this._laboratorySampleAnalysisService.Add(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/LaboratorySampleAnalysis/AddDetails/
        [HttpPost("[action]")]
        public async Task<IActionResult> AddDetails([FromBody] JObject obj)
        {
            try
            {
                var result = await this._laboratorySampleAnalysisService.AddDetails(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public async Task<IActionResult> UpdateResults([FromBody] JObject obj)
        {
            try
            {
                var result = await this._laboratorySampleAnalysisService.UpdateResults(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public async Task<IActionResult> AddConsume([FromBody] JObject obj)
        {
            try
            {
                var result = await this._laboratorySampleAnalysisService.AddConsume(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateConsume([FromBody] ConsumeHead model)
        {
            try
            {
                var result = await this._laboratorySampleAnalysisService.UpdateConsume(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRecovery([FromBody] JObject obj)
        {
            try
            {
                var result = await this._laboratorySampleAnalysisService.AddRecovery(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public async Task<IActionResult> UpdateRecovery([FromBody] RecoveryHead model)
        {
            try
            {
                var result = await this._laboratorySampleAnalysisService.UpdateRecovery(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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