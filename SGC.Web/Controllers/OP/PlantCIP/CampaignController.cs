using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.OP.PlantCIP;
using SGC.InterfaceServices.OP.PlantCIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.MineralReception
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        IServiceCampaign _campaignService;
        public CampaignController(IServiceCampaign campaignService)
        {
            this._campaignService = campaignService;
        }

        //// GET: api/Campaign/GetAll/1
        //[HttpGet("[action]/{id}")]
        //public async Task<IActionResult> GetAll(int id)
        //{
        //    try
        //    {
        //        var result = await this._campaignService.GetAll(id);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        // POST api/Campaign/Add/
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] Campaign model)
        {
            try
            {
                var result = await this._campaignService.Add(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/Campaign/Update/
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] Campaign model)
        {
            try
            {
                var result = await this._campaignService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/Campaign/Delete/
        [HttpDelete("[action]")]
        public async Task<IActionResult> ChangeStatus([FromBody] JObject obj)
        {
            try
            {
                var result = await this._campaignService.ChangeStatus(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Campaign/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._campaignService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SearchRuma(JObject obj)
        {
            try
            {
                var result = await this._campaignService.SearchRuma(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //// GET api/Campaign/Get/1
        //[HttpGet("[action]/{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok(
        //        _campaignService.Get(id)
        //    );
        //}

        //// GET: api/Campaign/SearchLote/{}
        //[HttpPost("[action]")]
        //public async Task<IActionResult> SearchLote(JObject obj)
        //{
        //    try
        //    {
        //        var result = await this._campaignService.SearchLote(obj);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        // GET: api/Campaign/GetRumas/{}
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetRumas(int id)
        {
            try
            {
                var result = await this._campaignService.GetRumas(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
