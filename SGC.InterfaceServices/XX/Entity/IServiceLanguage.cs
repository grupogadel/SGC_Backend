
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceLanguage
    {
        int Add(Language model);
        int Update(Language model);
        int ChangeStatus(JObject obj);
        Task<List<Language>> Search(JObject obj);
    }
}
