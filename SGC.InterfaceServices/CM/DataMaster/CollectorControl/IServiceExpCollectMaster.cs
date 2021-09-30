using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster.CollectorControl;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.DataMaster.CollectorControl
{
    public interface IServiceExpCollectMaster
    {
        Task<List<ExpCollectMaster>> GetAllM(JObject obj);
        Task<List<ExpCollectMaster>> SearchM(JObject obj);
        int Add(ExpCollectMaster model);
        int Update(ExpCollectMaster model);
        int Delete(JObject obj);
    }
}

