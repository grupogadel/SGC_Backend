using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Collect;

namespace SGC.InterfaceServices.CM.Collect
{
    public interface IServiceQuota

    {
        Task<List<Quota>> GetAll(int id);
        int Add(Quota model);
        int Update(Quota model);
        int Delete(JObject obj);
        Quota Get(int id);
        Task<List<Quota>> Search(JObject obj);

    }
}
