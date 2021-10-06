using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Liquidation;
using System;
using System.Collections.Generic;
using System.Text;
using SGC.Entities.Entities.CM.Commercial;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Commercial.Liquidation
{
    public interface IServiceLiquidation
    {
        Task<List<ManagementLiquidation>> Search(JObject obj);
        Task<PriceInternational> PriceInternationalGetDay(JObject obj);
        int ChangeStatus(JObject obj);
        Task<int> Add(ManagementLiquidation model);
        Task<int> Update(ManagementLiquidation model);
    }
}
