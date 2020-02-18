using SGC.Entities.Entities.WK;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGC.InterfaceServices.WK
{
    public interface IServicePosition
    {

        //Task<List<Usuario>> GetAll();
        //int Add(Usuario model);
        //int Update(Usuario model);
        //int Delete(int id);
        List<Position> GetByUser(int id);
    }
}
