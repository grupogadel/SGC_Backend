
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entidad;

namespace SGC.InterfaceServices.XX.Entidad
{
    public interface IServiceDistrito
    {
        Task<List<Distrito>> GetAll();
        int Add(Distrito model);
        int Update(Distrito model);
        int Delete(JObject obj);
        Distrito Get(int id);
    }
}
