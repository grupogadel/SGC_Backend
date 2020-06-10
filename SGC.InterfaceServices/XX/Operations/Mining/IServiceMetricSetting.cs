using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations.Mining
{
    public interface IServiceMetricSetting
    {
        Task<List<MetricSetting>> GetAll(int id);
        int Add(MetricSetting model);
        int Update(MetricSetting model);
        int Delete(JObject obj);
        Task<List<MetricSetting>> Search(JObject obj);
    }
}
