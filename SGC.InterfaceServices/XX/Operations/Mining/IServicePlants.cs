using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations.Mining
{
    public interface IServicePlants
    {
        Task<List<Plants>> Search(JObject obj);
    
    }
}
