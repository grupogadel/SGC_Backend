using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.InterfaceServices.XX.Finance
{
    public interface IServiceTaxMaster
    {
        Task<List<TaxMaster>> Search(JObject obj);
    }
}
