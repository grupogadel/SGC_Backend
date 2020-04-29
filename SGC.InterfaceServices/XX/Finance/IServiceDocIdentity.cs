
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.InterfaceServices.XX.Finance
{
    public interface IServiceDocIdentity
    {
        Task<List<DocIdentity>> GetAll();
        int Add(DocIdentity model);
        int Update(DocIdentity model);
        int Delete(JObject obj);
        DocIdentity Get(int id);
        DocIdentity GetCod(String cod);
        Task<List<DocIdentity>> Search(JObject obj);
    }
}
