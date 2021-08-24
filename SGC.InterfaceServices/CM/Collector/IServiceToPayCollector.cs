using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Collect;

namespace SGC.InterfaceServices.CM.Collect
{
    public interface IServiceToPayCollector
    {
        Task<List<ToPayCollector>> Search(JObject obj);
        Task<int> Add(ToPayCollector model);
        Task<int> Update(ToPayCollector model);
        Task<int> ChangeStatus(JObject obj);
        Task<ToPayCollector> Get(int id);
    }
}
