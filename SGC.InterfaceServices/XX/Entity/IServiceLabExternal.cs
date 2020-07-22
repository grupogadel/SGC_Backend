using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceLabExternal
    {
        Task<List<LabExternal>> GetAll(int id);
    }
}
