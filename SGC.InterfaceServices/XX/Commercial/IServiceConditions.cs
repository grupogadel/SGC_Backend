using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;

namespace SGC.InterfaceServices.XX.Commercial
{
    public interface IServiceConditions
    {
        Task<List<Conditions>> GetAll(int id);
        int Add(Conditions model);
        int Update(Conditions model);
        int Delete(JObject obj);
        Conditions Get(int id);
    }
}
