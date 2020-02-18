
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceDistrict
    {
        Task<List<District>> GetAll();
        int Add(District model);
        int Update(District model);
        int Delete(JObject obj);
        District Get(int id);
    }
}
