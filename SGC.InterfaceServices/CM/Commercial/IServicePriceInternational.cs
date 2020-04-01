using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial;

namespace SGC.InterfaceServices.CM.Commercial
{
    public interface IServicePriceInternational
    {
        int Add(PriceInternational model);
        int Update(PriceInternational model);
        int ChangeStatus(JObject obj);
        PriceInternational Get(int id);
        Task<List<PriceInternational>> Search(JObject obj);

    }
}
