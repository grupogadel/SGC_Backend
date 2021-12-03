using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.MineralReception
{
    public interface IServiceCrushed
    {
        Task<List<ModelCrushed>> Search(JObject obj);
        Task<int> Add(ModelCrushed model);
    }
}
