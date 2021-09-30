using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.FI.DataMaster;

namespace SGC.InterfaceServices.FI.DataMaster
{
    public interface IServiceChartAccLocMaster

    {
        Task<List<ChartAccLocMaster>> GetAll(JObject obj);
        //int Add(ChartAccLocMaster model);
        //int Update(ChartAccLocMaster model);
        //int ChangeStatus(JObject obj);
        //ChartAccLocMaster Get(int id);
        //Task<List<ChartAccLocMaster>> Search(JObject obj);

    }
}
