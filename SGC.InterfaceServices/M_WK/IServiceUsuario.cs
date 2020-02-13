using SGC.Entities.Entities.M_WK;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGC.InterfaceServices.M_WK
{
    public interface IServiceUsuario
    {

        List<Usuario> GetAll();
        //int Add(Usuario model);
        //int Update(Usuario model);
        //int Delete(int id);
        //Usuario Get(int id);
    }
}
