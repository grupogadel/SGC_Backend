using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Proposal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Commercial.Proposal
{
    public interface IServiceLiquidationAdvance
    {
        Task<List<LiquidationAdvance>> Search(JObject obj);
        //Task<PriceInternational> PriceInternationalGetDay(JObject obj);
        //int ChangeStatus(JObject obj);
        Task<int> Add(ModelProposal model);
        //Task<int> Update(ManagementLiquidation model);
    }
}
