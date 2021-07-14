using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServicePolicyCorp
    {
        Task<List<PolicyCorp>> GetAll(int id);
        int Update(PolicyCorp model);
        Task<List<PolicyCorp>> Search(JObject obj);
    }
}
