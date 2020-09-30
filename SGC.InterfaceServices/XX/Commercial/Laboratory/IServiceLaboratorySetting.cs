using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Commercial.Laboratory
{
    public interface IServiceLaboratorySetting
    {
        Task<List<LaboratorySetting>> GetAll(int id);
        int Add(LaboratorySetting model);
        int Update(LaboratorySetting model);
        int Delete(JObject obj);
        Task<List<LaboratorySetting>> Search(JObject obj);
        LaboratorySetting Get(int id);

    }
}