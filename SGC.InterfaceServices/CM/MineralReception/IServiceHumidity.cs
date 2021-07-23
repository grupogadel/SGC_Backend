using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.CM.Laboratory;

namespace SGC.InterfaceServices.CM.MineralReception
{
    public interface IServiceHumidity
    {
        Task<List<BatchMineral>> Search(JObject obj);
        Task<int> Add(JObject obj);
        Task<int> Update(JObject obj);
        int ChangeStatus(JObject obj);
    }
}
