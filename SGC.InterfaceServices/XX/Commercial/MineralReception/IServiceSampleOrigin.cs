using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Commercial.MineralReception
{
    public interface IServiceSampleOrigin
    {
        Task<List<SampleOrigin>> GetAll(int id);
        int Add(SampleOrigin model);
        int Update(SampleOrigin model);
        int Delete(JObject obj);
        Task<List<SampleOrigin>> Search(JObject obj);
    }
}
