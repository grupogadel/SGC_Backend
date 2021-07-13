using SGC.Entities.Entities.CM.Commercial.CommercialCondition;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Commercial.CommercialCondition
{
    public interface IServiceMaquilaCommercial
    {
        Task<List<MaquilaCommercial>> GetAll(int id, int cond);
    }
}
