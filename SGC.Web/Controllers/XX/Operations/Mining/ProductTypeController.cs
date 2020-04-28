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
    //[EnableCors("MyPolicy")]
    public class ProductTypeController : ControllerBase
    {
        IServiceProductType _productTypeService;
        public ProductTypeController(IServiceProductType ProductTypeService)
        {
            this._productTypeService = ProductTypeService;
        }

        // GET: api/ProductType/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._productTypeService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/ProductType/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] ProductType model)
        {
            return Ok(
                _productTypeService.Add(model)
            );
        }


        // PUT api/ProductType/Update/
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] ProductType model)
        {
            return Ok(
                _productTypeService.Update(model)
            );
        }

        // DELETE api/ProductType/Delete/{}
        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] JObject obj)
        {
            return Ok(
                _productTypeService.Delete(obj)
            );
        }

        // POST: api/ProductType/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._productTypeService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
