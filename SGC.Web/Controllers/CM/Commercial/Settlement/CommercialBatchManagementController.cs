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
    public class CommercialBatchManagementController : ControllerBase
    {
        IServiceCommercialBatchManagement _commercialBatchManagementService;
        public CommercialBatchManagementController(IServiceCommercialBatchManagement commercialBatchManagementService)
        {
            this._commercialBatchManagementService = commercialBatchManagementService;
        }
        // GET: api/CommercialBatchManagement/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._commercialBatchManagementService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
