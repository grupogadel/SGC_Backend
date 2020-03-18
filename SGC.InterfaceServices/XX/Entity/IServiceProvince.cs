
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceProvince
    {
        Task<List<Province>> GetAll();
        int Add(Province model);
        int Update(Province model);
        int Delete(Province obj);
        Province Get(int id);
    }
}
