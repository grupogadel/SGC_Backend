using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Reports;
using System;
using System.Collections.Generic;
using System.Text;
using SGC.Entities.Entities.CM.Commercial;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Commercial.Reports
{
    public interface IServiceReports
    {
        Task<List<BatchComProcTime>> SearchTimeProc(JObject obj);
        Task<List<MineralBatchLiquidation>> SearchMineralBatchLiiquidation(JObject obj);
    }
}
