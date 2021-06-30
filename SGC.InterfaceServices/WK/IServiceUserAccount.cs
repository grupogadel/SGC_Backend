using SGC.Entities.Entities.WK;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace SGC.InterfaceServices.WK
{
    public interface IServiceUserAccount
    {

        Task<List<UserAccount>> GetAll();
		UserAccount GetUserAccount(string dni);
		Task<List<UserPosition>> GetAllPositionByUser(int id);
		Person GetPerson(string dni);
        int Add(JObject obj);
        int Update(UserAccount model);
        int UpdateUserPosition(UserAccount model);
        int Delete(JObject obj);
        
    }
}
