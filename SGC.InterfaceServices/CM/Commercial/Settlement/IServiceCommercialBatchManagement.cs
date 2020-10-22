using SGC.Entities.Entities.CM.Commercial.Settlement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Commercial.Settlement
{
    public interface IServiceCommercialBatchManagement
    {
        Task<List<CommercialBatchManagement>> GetAll(int id);
    }
}
