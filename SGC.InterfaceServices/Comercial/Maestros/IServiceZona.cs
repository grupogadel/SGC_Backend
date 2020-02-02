using Microsoft.AspNetCore.Mvc;
using SGC.Entities.Entities.Comercial.Maestros;
using SGC.Entities.View.Comercial.Maestros.Zona;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.Comercial.Maestros
{
    public interface IServiceZona
    {
        Task<IEnumerable<ZonaView>> GetAll();
        Task<IEnumerable<SelectView>> Selec();

        //Task<IActionResult> Show([FromRoute] int a);
        bool Add(Zona model);
        bool Update(Zona model);
        Zona Get(int id);
        bool Delete(int id);
    }
}
