using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGC.Entities.Entities.M_WK;
using SGC.InterfaceServices.M_WK;


namespace SGC.Web.Controllers.M_WK
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]
    public class UsuariosController : ControllerBase
    {
        IServiceUsuario _usuarioService;
        public UsuariosController(IServiceUsuario usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        // GET: api/Usuarios/GetAll
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._usuarioService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
        // POST api/Usuarios/Add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] Usuario model)
        {
            return Ok(
                _usuarioService.Add(model)
            );
        }


        // POST api/Usuarios/Update/1
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Usuario model)
        {
            return Ok(
                _usuarioService.Update(model)
            );
        }

        // DELETE api/Usuarios/Delete/1
        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _usuarioService.Delete(id)
            );
        }

        // GET api/Usuarios/Get/1
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _usuarioService.Get(id)
            );
        }
        */

    }

}
