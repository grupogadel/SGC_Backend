using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.SampleReferential;
using System.Collections.Generic;

namespace SGC.InterfaceServices.CM.Commercial.SampleReferential
{
    public interface IServiceSampleReferential
    {
        List<SampleHeadReferential> GetAll(JObject obj);
        List<SampleHeadReferential> GetAllByApprover(JObject obj);
        int Add(JObject obj);
        int Update(JObject obj);
        int Delete(JObject obj);
        List<SampleHeadReferential> Search(JObject obj);
        List<SampleHeadReferential> SearchByApprover(JObject obj);
    }
}
