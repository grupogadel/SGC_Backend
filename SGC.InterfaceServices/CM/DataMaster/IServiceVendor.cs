using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;

namespace SGC.InterfaceServices.CM.DataMaster
{
    public interface IServiceVendor
    {
        Task<List<Vendor>> GetAll(int id);
        int Add(Vendor model);
        int Update(Vendor model);
        int Delete(JObject obj);
        Vendor Get(int id);
    }
}
