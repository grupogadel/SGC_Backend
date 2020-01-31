using SGC.Entities.View.BatchMineral;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.BatchMineral
{
    public interface IServiceOrigin
    {
        Task<IEnumerable<OriginView>> GetAll();
    }
}
