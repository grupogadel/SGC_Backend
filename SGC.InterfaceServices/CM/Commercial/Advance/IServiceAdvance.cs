using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Advance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Commercial.Advance
{
    public interface IServiceAdvance
    {
        List<AdvanceHead> Search(JObject obj);
        List<AdvanceHead> GetAllForLiquidation(JObject obj);
        List<AdvanceHead> SearchByInterval(JObject obj);
        List<AdvanceHead> SearchForDiscounts(JObject obj);
        int Add(AdvanceHead model);
		int Update(AdvanceDetails model);
		int Approb(JObject obj);
		Task<List<AdvanceBalance>> Balance(JObject obj);
        Task<List<AdvanceBalanceAccumulated>> BalanceAccumulated(JObject obj);
        Task<List<Discounts>> DiscountsGetAll(int id);
        int DiscountsAdd(ModelDiscounts model);
        int DiscountsEdit(ModelDiscounts model);
        int DocumentUpdate(JObject obj);
    }
}
