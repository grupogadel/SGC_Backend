
using SGC.Entities.Entities.Comercial.Maestros;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace SGC.InterfaceServices.Comercial.Maestros
{
    public interface IServiceZona
    {
        
        Task<List<Zona>> GetAll();
        int Add(Zona model);
        int Update(Zona model);
        int Delete(int id);
        Zona Get(int id);
    }
}
