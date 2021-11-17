using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.OP.PlantCIP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.OP.PlantCIP
{
    public interface IServiceGrinding
    {
        Task<List<GrindingHead>> Search(JObject obj);
    }
}
