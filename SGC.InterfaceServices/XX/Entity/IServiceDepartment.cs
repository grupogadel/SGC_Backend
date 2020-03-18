using SGC.Entities.Entities.XX.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceDepartment
    {
        Task<List<Department>> GetAll();
        int Add(Department model);
        int Update(Department model);
        int Delete(Department obj);
        Department Get(int id);
    }
}
