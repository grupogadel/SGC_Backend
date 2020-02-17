
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.XX.Entidad;

namespace SGC.InterfaceServices.XX.Entidad
{
    public interface IServiceCompania
    {
        
        Task<List<Compania>> GetAll();
        int Add(Compania model);
        int Update(Compania model);
        int Delete(int id);
        Compania Get(int id);
    }
}
