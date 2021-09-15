using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Settlement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.Commercial.Settlement
{
    public interface IServiceManagementBatchMineral
    {
        Task<List<ManagementBatchMineral>> GetAll(int id);
        int Delete(JObject obj);
        List<ManagementBatchMineral> Search(JObject obj);
        ManagementBatchMineral Get(int id);
        //ManagementSettlement GetS(int id);
    }
}
