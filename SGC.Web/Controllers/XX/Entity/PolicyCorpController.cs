using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Web.Controllers.XX.Entity
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class PolicyCorpController : ControllerBase
    {
        IServicePolicyCorp _policyCorpService;
        public PolicyCorpController(IServicePolicyCorp PolicyCorpService)
        {
            this._policyCorpService = PolicyCorpService;
        }

        // GET: api/PolicyCorp/GetAll/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var result = await this._policyCorpService.GetAll(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/PolicyCorp/Update/{}
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] PolicyCorp model)
        {
            return Ok(
                _policyCorpService.Update(model)
            );
        }

        // POST: api/PolicyCorp/Search/{}
        [HttpPost("[action]")]
        public async Task<IActionResult> Search(JObject obj)
        {
            try
            {
                var result = await this._policyCorpService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
