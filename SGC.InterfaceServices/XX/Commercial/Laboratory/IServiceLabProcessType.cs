using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Commercial.Laboratory
{
    public interface IServiceLabProcessType
    {
        Task<List<LabProcessType>> GetAll();
        int Add(LabProcessType model);
        int Update(LabProcessType model);
        int Delete(JObject obj);
        Task<List<LabProcessType>> Search(JObject obj);
    }
}
