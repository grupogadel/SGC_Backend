using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Operations.Mining
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class MaterialTypeController : ControllerBase
    {
        IServiceMaterialType _materialTypeService;
        public MaterialTypeController(IServiceMaterialType materialTypeService)
        {
            this._materialTypeService = materialTypeService;
        }
        // GET: api/MaterialType/GetAll
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._materialTypeService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
