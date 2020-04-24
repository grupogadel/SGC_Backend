using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations.Mining
{
    public interface IServiceWorkShifts
    {
        Task<List<WorkShifts>> GetAll(int id);
        int Add(WorkShifts model);
        int Update(WorkShifts model);
        int Delete(JObject obj);
        WorkShifts Get(int id);
        WorkShifts GetCod(String Cod);
        Task<List<WorkShifts>> Search(JObject obj);
    }
}
