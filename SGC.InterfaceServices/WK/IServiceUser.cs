using SGC.Entities.Entities.WK;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGC.InterfaceServices.WK
{
    public interface IServiceUser
    {

        List<User> GetAll();
        //int Add(Usuario model);
        //int Update(Usuario model);
        //int Delete(int id);
        //Usuario Get(int id);
    }
}
