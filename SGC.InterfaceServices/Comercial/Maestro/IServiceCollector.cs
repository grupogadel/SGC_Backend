using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.Comercial.Maestro;
using SGC.Entities.View;

namespace SGC.InterfaceServices.Comercial.Maestro
{
    public interface IServiceCollector
    {
        Task<IEnumerable<Collector>> GetAll();
        Task<bool> Create(Collector collector);
        Task<bool> Delete(int id);

    }
}
