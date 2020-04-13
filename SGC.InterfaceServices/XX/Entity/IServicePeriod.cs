using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServicePeriod
    {
        int Add(Period model);
        int Update(Period model);
        int ChangeStatus(JObject obj);
        Period Get(JObject obj);
        Task<List<Period>> Search(JObject obj);
    }
}
