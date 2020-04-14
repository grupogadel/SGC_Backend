using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.XX.Operations;
using System;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Operations
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class MineralsTypeController: ControllerBase
    {
        IServiceMineralsType _mineralsTypeService;
        public MineralsTypeController(IServiceMineralsType mineralsTypeService)
        {
            this._mineralsTypeService = mineralsTypeService;
        }
        // GET: api/MineralsType/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._mineralsTypeService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
