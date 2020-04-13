using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class CompanyController : ControllerBase
    {
        IServiceCompany _companyService;
        public CompanyController(IServiceCompany companyService)
        {
            this._companyService = companyService;
        }

        // GET: api/Company/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._companyService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/Company/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Company model)
        {
            return Ok(
                _companyService.Add(model)
            );
        }


        // POST api/Company/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Company model)
        {
            return Ok(
                _companyService.Update(model)
            );
        }

        [HttpDelete("[action]")]
        public IActionResult ChangeStatus([FromBody] JObject obj)
        {
            return Ok(
                _companyService.ChangeStatus(obj)
            );
        }

        // POST: api/Company/Search
        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] JObject obj)
        {
            try
            {
                var result = await this._companyService.Search(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // GET api/Company/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _companyService.Get(id)
            );
        }

    }
}
