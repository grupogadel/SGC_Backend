using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.View.Configuracion.Sistema;
using SGC.Entities.Entities.Configuracion.Sistema;
using SGC.Entities.View;

namespace SGC.InterfaceServices.Configuracion.Sistema
{
    public interface IServiceCompany
    {
        //IEnumerable<Company> GetAll();
        Task<IEnumerable<Company>> GetAll();
        Task<bool> Create(Company company);
        Task<bool> Delete(int id);

    }
}
