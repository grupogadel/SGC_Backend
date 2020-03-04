using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Commercial
{
    public interface IServiceMaquilaCommercial
    {
        Task<List<MaquilaCommercial>> GetAll(int id, int cond);
        int Add(MaquilaCommercial model);
        int Update(MaquilaCommercial model);
        int Delete(int id, string user);
    }
}
