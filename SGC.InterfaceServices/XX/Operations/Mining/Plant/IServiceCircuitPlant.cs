using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining.Plant;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations.Mining.Plant
{
    public interface IServiceCircuitPlant
    {
       
        CircuitPlant Get(JObject obj);
    }
}
