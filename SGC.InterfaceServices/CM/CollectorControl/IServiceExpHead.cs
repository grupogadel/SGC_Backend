using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.CollectorControl;

namespace SGC.InterfaceServices.CM.CollectorControl
{
    public interface IServiceExpHead

    {
        int Add(ExpHead model);
        int Update(ExpHead model);
        //int Delete(JObject obj);
        ExpHead Get(int id);
        Task<List<ExpHead>> Search(JObject obj);

    }
}
