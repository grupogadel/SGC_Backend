using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;

namespace SGC.InterfaceServices.CM.DataMaster
{
    public interface IServiceCollector
    {
        Task<List<Collector>> GetAll(int id);
        int Add(Collector model);
        int Update(Collector model);
        int ChangeStatus(JObject obj);
        Collector Get(int id);
        Task<List<Collector>> Search(JObject obj);
    }
}