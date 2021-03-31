using SGC.Entities.Entities.WK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.InterfaceServices.WK
{
    public interface IServiceAccess
    {
        int ChangeStatus(JObject obj);

        int Add(Access model);
        int Update(Access model);
        Task<List<Access>> Search(JObject obj);
    }
}
