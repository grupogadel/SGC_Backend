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
        int Add(JObject obj);
        int Update(Humidity model);
        int ChangeStatus(JObject obj);
    }
}
