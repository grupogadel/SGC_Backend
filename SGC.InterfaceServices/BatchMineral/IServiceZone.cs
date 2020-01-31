using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.View.BatchMineral;

namespace SGC.InterfaceServices.BatchMineral
{
    public interface IServiceZone
    {
        Task<IEnumerable<ZoneView>> GetAll();
    }
}
