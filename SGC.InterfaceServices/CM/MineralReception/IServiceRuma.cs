using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.MineralReception
{
    public interface IServiceRuma
    {
        Task<List<Ruma>> GetAll(int id);
        int Add(Ruma model);
        int Update(Ruma model);
        int Delete(JObject obj);
        Ruma Get(int id);
        Task<List<Ruma>> Search(JObject obj);
        Task<List<BatchMineral>> SearchLote(JObject obj);

    }
}
