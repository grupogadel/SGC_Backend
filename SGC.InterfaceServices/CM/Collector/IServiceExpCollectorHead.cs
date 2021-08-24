using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Collect;

namespace SGC.InterfaceServices.CM.Collect
{
    public interface IServiceExpCollectorHead
    {
        Task<List<ExpCollectorHead>> Search(JObject obj);
        Task<List<ExpCollectMaster>> SearchExpMaster();
        Task<int> Add(ExpCollectorHead model);
        Task<int> Update(ExpCollectorHead model);
        Task<List<ExpCollectorDetails>> GetBatches(int id);
    }
}
