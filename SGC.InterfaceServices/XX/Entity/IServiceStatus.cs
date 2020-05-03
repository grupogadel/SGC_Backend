using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceStatus
    {
        int Add(Status model);
        int Update(Status model);
        int ChangeStatus(JObject obj);
        Task<List<Status>> Search(JObject obj);
    }
}
