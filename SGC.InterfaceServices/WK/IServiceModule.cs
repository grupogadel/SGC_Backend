using SGC.Entities.Entities.WK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.InterfaceServices.WK
{
    public interface IServiceModule
    {
        Task<List<Module>> GetAll();
        int Add(Module model);
        int Update(Module model);
		Task<List<Module>> Search(JObject obj);
    }
}
