using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Laboratory;
using SGC.InterfaceServices.CM.Laboratory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.Laboratory
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleLaboratoryController : ControllerBase
    {
        IServiceSampleLaboratory _sampleLaboratoryService;
        public SampleLaboratoryController(IServiceSampleLaboratory sampleLaboratoryService)
        {
            this._sampleLaboratoryService = sampleLaboratoryService;
        }

        // GET: api/SampleLaboratory/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._sampleLaboratoryService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/SampleLaboratory/GetAll2/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll2(int id)
        {
            try
            {
                var result = await this._sampleLaboratoryService.GetAll2(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/SampleLaboratory/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._sampleLaboratoryService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/SampleLaboratory/SearchCommercialLte
        [HttpPost("[action]")]
        public async Task<IActionResult> SearchCommercialLte([FromBody] JObject obj)
        {
            try
            {
                var result = await this._sampleLaboratoryService.SearchCommercialLte(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/SampleLaboratory/GetAllArea
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllArea(int id)
        {
            try
            {
                var result = await this._sampleLaboratoryService.GetAllArea(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/SampleLaboratory/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] LaboratoryRecepcion model)
        {
            return Ok(
                _sampleLaboratoryService.Add(model)
            );
        }
    }
}
