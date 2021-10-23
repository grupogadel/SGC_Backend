using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Proposal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Commercial.Proposal
{
    public interface IServiceLiquidationAdvance
    {
        Task<List<LiquidationAdvance>> Search(JObject obj);
        int Approb(JObject obj);
        //Task<PriceInternational> PriceInternationalGetDay(JObject obj);
        //int ChangeStatus(JObject obj);
        Task<int> Add(ModelProposal model);
        int ApprobFact(JObject obj);
        //Task<int> Update(ManagementLiquidation model);
    }
}
