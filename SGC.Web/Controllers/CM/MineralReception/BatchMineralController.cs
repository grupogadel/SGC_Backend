using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.InterfaceServices.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.MineralReception
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchMineralController : ControllerBase
    {
        IServiceBatchMineral _batchMineralService;
        public BatchMineralController(IServiceBatchMineral batchMineralService)
        {
            this._batchMineralService = batchMineralService;
        }
        // GET: api/BatchMineral/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._batchMineralService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/BatchMineral/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._batchMineralService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/BatchMineral/SearchByRuma/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> SearchByRuma(JObject obj)
        {
            try
            {
                var result = await this._batchMineralService.SearchByRuma(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
