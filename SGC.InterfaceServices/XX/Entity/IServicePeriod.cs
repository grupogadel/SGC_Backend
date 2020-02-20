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
        Task<List<Period>> GetAll(int idCompany);
        int Add(Period model);
        int Update(Period model);
        int Delete(JObject obj);
        Period Get(JObject obj);
    }
}
