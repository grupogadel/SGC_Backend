using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations.Mining
{
    public interface IServiceMineralFrom
    {
        Task<List<MineralFrom>> GetAll(int id);
        int Add(MineralFrom model);
        int Update(MineralFrom model);
        int Delete(JObject obj);
        Task<List<MineralFrom>> Search(JObject obj);
    }
}
