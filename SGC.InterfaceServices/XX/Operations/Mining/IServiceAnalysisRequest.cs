using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations.Mining
{
    public interface IServiceAnalysisRequest
    {
        Task<List<AnalysisRequest>> GetAll();
        int Add(AnalysisRequest model);
        int Update(AnalysisRequest model);
        int Delete(JObject obj);
        Task<List<AnalysisRequest>> Search(JObject obj);
    }
}
