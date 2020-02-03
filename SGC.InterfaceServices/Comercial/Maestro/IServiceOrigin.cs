using SGC.Entities.View.Comercial.Maestros.Origin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.Comercial.Maestros
{
    public interface IServiceOrigin
    {
        Task<IEnumerable<OriginView>> GetAll();
    }
}
