using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations.Mining
{
    public interface IServiceMineralsType
    {
        Task<List<MineralsType>> GetAll(int id);
        int Add(MineralsType model);
        int Update(MineralsType model);
        int Delete(JObject obj);
        MineralsType Get(int id);
        MineralsType GetCod(String cod);
        Task<List<MineralsType>> Search(JObject obj);
    }
}
