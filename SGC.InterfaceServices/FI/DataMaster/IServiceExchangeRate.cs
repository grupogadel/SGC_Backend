using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.FI.DataMaster;

namespace SGC.InterfaceServices.FI.DataMaster
{
    public interface IServiceExchangeRate

    {
        Task<List<ExchangeRate>> GetAll();
        int Add(ExchangeRate model);
        int Update(ExchangeRate model);
        int ChangeStatus(JObject obj);
        ExchangeRate Get(int id);
        Task<List<ExchangeRate>> Search(JObject obj);

    }
}
