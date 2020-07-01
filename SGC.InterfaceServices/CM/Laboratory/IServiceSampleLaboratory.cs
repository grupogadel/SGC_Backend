using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Laboratory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Laboratory
{
    public interface IServiceSampleLaboratory
    {
        Task<List<SampleHeadLaboratory>> GetAll(int id);
        Task<List<LaboratoryRecep>> GetAll2(int id);
        int Add(LaboratoryRecepcion model);
        Task<List<SampleOriginArea>> GetAllArea(int idCompany);
        Task<List<LaboratoryRecep>> Search(JObject obj);
    }
}
