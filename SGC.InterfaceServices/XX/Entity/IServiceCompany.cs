
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceCompany
    {
        
        Task<List<Company>> GetAll();
        int Add(Company model);
        int Update(Company model);
        int Delete(int id);
        Company Get(int id);
    }
}
