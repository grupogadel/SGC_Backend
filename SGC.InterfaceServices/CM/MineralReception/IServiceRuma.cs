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
        Task<int> Add(Ruma model);
        Task<int> Update(JObject obj);
        Task<int> FinishRuma(Ruma model);
        int Delete(JObject obj);
        Ruma Get(int id);
        Task<List<Ruma>> Search(JObject obj);
        Task<List<BatchMineral>> SearchLote(JObject obj);
        Task<List<BatchMineral>> GetBatches(int id);

    }
}
