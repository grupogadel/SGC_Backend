using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Operations.Mining
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricSettingController : ControllerBase
    {
        IServiceMetricSetting _metricSettingService;
        public MetricSettingController(IServiceMetricSetting metricSettingService)
        {
            this._metricSettingService = metricSettingService;
        }
        // GET: api/MetricSetting/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._metricSettingService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/MetricSetting/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] MetricSetting model)
        {
            return Ok(
                _metricSettingService.Add(model)
            );
        }

        // POST api/MetricSetting/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] MetricSetting model)
        {
            return Ok(
                _metricSettingService.Update(model)
            );
        }

        // DELETE api/MetricSetting/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _metricSettingService.Delete(obj)
            );
        }

        // GET: api/MetricSetting/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._metricSettingService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
