using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Commercial
{
    public interface IServiceCommercialParameters
    {
        Task<List<CommercialParameters>> GetAll(int id);
        int Add(CommercialParameters model);
        int Update(CommercialParameters model);
        int Delete(JObject obj);
        Task<List<CommercialParameters>> Search(JObject obj);
    }
}
