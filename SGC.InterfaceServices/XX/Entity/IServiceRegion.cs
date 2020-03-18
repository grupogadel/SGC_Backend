using SGC.Entities.Entities.XX.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceRegion
    {
        Task<List<Region>> GetAll();
        int Add(Region model);
        int Update(Region model);
        int Delete(Region obj);
        Region Get(int id);
    }
}
