﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGC.Entities.Entities.XX.Entidad;
using SGC.InterfaceServices.XX.Entidad;

namespace SGC.Web.Controllers.M_XX.Sistema
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class CompaniaController : ControllerBase
    {
        IServiceCompania _companyService;
        public CompaniaController(IServiceCompania companyService)
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
        public IActionResult Add([FromBody] Compania model) 
        {
            return Ok(
                _companyService.Add(model)
            );
        }


        // POST api/Company/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Compania model)
        {
            return Ok(
                _companyService.Update(model)
            );
        }

        // DELETE api/Company/Delete/1
        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _companyService.Delete(id)
            );
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