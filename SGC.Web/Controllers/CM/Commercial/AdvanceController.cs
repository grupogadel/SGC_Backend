using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Advance;
using SGC.InterfaceServices.CM.Commercial.Advance;
using System.Threading.Tasks;
using System;

namespace SGC.Web.Controllers.CM.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class AdvanceController: ControllerBase
    {
        IServiceAdvance _advanceService;
        public AdvanceController(IServiceAdvance AdvanceService)
        {
            this._advanceService = AdvanceService;
        }
		
		// POST: api/Advance/Search/{}
        [HttpPost("[action]")]
        public IActionResult Search([FromBody] JObject obj)
        {
            try
            {
                var result = this._advanceService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Advance/SearchForDiscounts/{}
        [HttpPost("[action]")]
        public IActionResult SearchForDiscounts([FromBody] JObject obj)
        {
            try
            {
                var result = this._advanceService.SearchForDiscounts(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/Advance/Add
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] AdvanceHead model)
        {
            return Ok(
                _advanceService.Add(model)
            );
        }
		
		// PUT api/Advance/Update
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] AdvanceDetails model)
        {
            return Ok(
                _advanceService.Update(model)
            );
        }
		
		// PUT api/Advance/Approb
        [HttpPut("[action]")]
        public IActionResult Approb([FromBody] JObject obj)
        {
            return Ok(
                _advanceService.Approb(obj)
            );
        }
		
		// POST: api/Advance/Balance/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Balance([FromBody] JObject obj)
        {
            try
            {
                var result = await this._advanceService.Balance(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Advance/DiscountsGetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> DiscountsGetAll(int id)
        {
            try
            {
                var result = await this._advanceService.DiscountsGetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/Advance/DiscountsAdd
        [HttpPost("[action]")]
        public IActionResult DiscountsAdd([FromBody] ModelDiscounts model)
        {
            return Ok(
                _advanceService.DiscountsAdd(model)
            );
        }

        // PUT api/Advance/DiscountsEdit
        [HttpPut("[action]")]
        public IActionResult DiscountsEdit([FromBody] ModelDiscounts model)
        {
            return Ok(
                _advanceService.DiscountsEdit(model)
            );
        }

        // PUT api/Advance/DocumentUpdate
        [HttpPut("[action]")]
        public IActionResult DocumentUpdate([FromBody] JObject obj)
        {
            return Ok(
                _advanceService.DocumentUpdate(obj)
            );
        }


    }
}
