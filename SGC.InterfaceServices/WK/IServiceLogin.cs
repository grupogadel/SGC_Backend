using SGC.Entities.Entities.WK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.WK
{
    public interface IServiceLogin
    {
        Task<UserAccount> LoginUser(JObject obj);
        Task<List<NavigationMenu>> NavigationMenuGet(int idPosition);
        //Task<List<Company>> GetCompanyPosition(int id);
    }
}
