using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.View.Configuracion.Sistema;
using SGC.Entities.Entities.Configuracion.Sistema;
using SGC.Entities.View;

namespace SGC.InterfaceServices.Configuracion.Sistema
{
    public interface IServicePeriod
    {
        //IEnumerable<Period> GetAll();
        Task<IEnumerable<Period>> GetAll();
        Task<bool> Create(Period period);
        Task<bool> Delete(int id);
        Task<IEnumerable<Period>> Search(int id);

    }
}
