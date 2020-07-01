using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;

namespace SGC.InterfaceServices.CM.MineralReception
{
    public interface IServiceScales
    {
        Task<List<Scales>> GetAll(int id);
        int Add(Scales model);
        int Update(Scales model);
        int Delete(JObject obj);
        Scales Get(int id);
        Task<List<Scales>> Search(JObject obj);
        Task<List<Scales>> Search2(JObject obj);
    }
}
