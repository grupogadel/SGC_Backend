
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Laboratory;

namespace SGC.InterfaceServices.CM.Laboratory
{
    public interface IServiceLaboratorySampleAnalysis
    {
        int Add(JObject obj);
        int ChangeStatus(JObject obj);
        int AddDetails(JObject obj);
        LeyMineralHead Get(int id);
        int RemoveItem(JObject obj);
        int UpdateResults(JObject obj);
        Task<List<SampleHead>> Search(JObject obj);
        Task<ConsumeHead> GetConsume(int id);
        int UpdateConsume(ConsumeHead consumeHead);
        int AddConsume(JObject obj);
        int AddRecovery(JObject obj);
        int UpdateRecovery(RecoveryHead recoveryHead);
        Task<RecoveryHead> GetRecovery(int id);
    }
}
