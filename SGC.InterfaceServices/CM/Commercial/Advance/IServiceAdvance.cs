using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Advance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Commercial.Advance
{
    public interface IServiceAdvance
    {
        List<AdvanceHead> Search(JObject obj);
        int Add(AdvanceHead model);
		int Update(AdvanceDetails model);
		int Approb(JObject obj);
		Task<List<AdvanceBalance>> Balance(JObject obj);
    }
}
