using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGC.InterfaceServices.XX.Entity;

namespace SGC.Web.Controllers.XX
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class CountryController : ControllerBase
    {
        IServiceCountry _countryService;
        public CountryController(IServiceCountry countryService)
        {
            this._countryService = countryService;
        }

        // GET: api/Company/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._countryService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // GET api/Country/Get/pe
        [HttpGet("[action]/{cod}")]
        public IActionResult GetCod(string cod)
        {
            return Ok(
                _countryService.GetCod(cod)
            );
        }
    }
}
