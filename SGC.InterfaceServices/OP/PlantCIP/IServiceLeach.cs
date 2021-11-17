using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.OP.PlantCIP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.OP.PlantCIP
{
    public interface IServiceLeach
    {
        Task<List<LeachHeader>> Search(JObject obj);
    }
}
