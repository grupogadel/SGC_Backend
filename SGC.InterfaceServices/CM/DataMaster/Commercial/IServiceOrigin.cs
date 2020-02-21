using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster.Commercial;

namespace SGC.InterfaceServices.CM.DataMaster.Commercial
{
    public interface IServiceOrigin
    {
        Task<List<Origin>> GetAll(int id);
        int Add(Origin model);
        int Update(Origin model);
        int Delete(JObject obj);
        Origin Get(int id);
    }
}
