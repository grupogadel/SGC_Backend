using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.CM.MineralReception;

namespace SGC.InterfaceServices.CM.MineralReception
{
    public interface IServiceBatchMineral
    {
        Task<List<BatchMineral>> GetAll(int id);
        Task<List<BatchMineral>> GetAllNoHumidity(int id);
        int Add(BatchMineral model);
        int Update(BatchMineral model);
        int Delete(JObject obj);
        BatchMineral Get(int id);
        Task<List<BatchMineral>> Search(JObject obj);
        Task<List<BatchMineral>> SearchByRuma(JObject obj);
        Task<List<ModelBatchMineral>> SearchByDocApprob(JObject obj);
        int ApproveDoc(JObject obj);
    }
}
