
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.InternalControl;

namespace SGC.InterfaceServices.CM.InternalControl
{
    public interface IServiceSampleHeadOperational
    {
        int Add(SampleHeadOperational model);
        int Update(SampleHeadOperational model);
        int ChangeStatus(JObject obj);
        Task<List<SampleOriginArea>> GetAllArea(int idCompany);
        Task<Code> GetCode(int idCompany);
        Task<List<SampleHeadOperational>> Search(JObject obj);
    }
}
