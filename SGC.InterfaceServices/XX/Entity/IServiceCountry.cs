using SGC.Entities.Entities.XX.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceCountry
    {
        Task<List<Country>> GetAll();
        int Add(Country model);
        int Update(Country model);
        int Delete(Country obj);
        Country Get(int id);
    }
}
