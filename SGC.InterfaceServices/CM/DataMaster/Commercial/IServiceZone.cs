using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.DataMaster
{
    public interface IServiceZone
    {
        Task<List<Zone>> GetAll();
        int Add(Zone model);
        int Update(Zone model);
        int Delete(JObject obj);
        Zone Get(int id);
        Task<List<Zone>> Search(JObject obj);

    }
}
