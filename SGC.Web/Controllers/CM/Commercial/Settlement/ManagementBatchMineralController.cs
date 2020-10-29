using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.InterfaceServices.CM.Commercial.Settlement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.CM.Commercial.Settlement
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementBatchMineralController : ControllerBase
    {
        IServiceManagementBatchMineral _managementBatchMineralService;
        public ManagementBatchMineralController(IServiceManagementBatchMineral managementBatchMineralService)
        {
            this._managementBatchMineralService = managementBatchMineralService;
        }
        // GET: api/ManagementBatchMineral/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._managementBatchMineralService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // GET api/ManagementBatchMineral/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _managementBatchMineralService.Get(id)
            );
        }

        // GET api/ManagementSettlement/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult GetS(int id)
        {
            return Ok(
                _managementBatchMineralService.GetS(id)
            );
        }
    }
}
