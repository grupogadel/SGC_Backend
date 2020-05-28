using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception.Sampling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.MineralReception.Sampling
{
    public interface IServiceSampleCommercial
    {
        List<SampleHeadCommercial> GetAll(int id);
        int Add(SampleDetailsCommercial model);
        int Update(SampleDetailsCommercial model);
        int Delete(JObject obj);
        //Task<List<SampleHeadCommercial>> Search(JObject obj);
    }
}
