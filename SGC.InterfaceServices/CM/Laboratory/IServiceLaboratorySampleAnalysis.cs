
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
        Task<int> Add(JObject obj);
        int ChangeStatus(JObject obj);
        Task<int> AddDetails(JObject obj);
        LeyMineralHead Get(int id);
        int RemoveItem(JObject obj);
        Task<int> UpdateResults(JObject obj);
        Task<List<SampleHead>> Search(JObject obj);
        Task<ConsumeHead> GetConsume(int id);
        Task<int> UpdateConsume(ConsumeHead consumeHead);
        Task<int> AddConsume(JObject obj);
        Task<int> AddRecovery(JObject obj);
        Task<int> UpdateRecovery(RecoveryHead recoveryHead);
        Task<RecoveryHead> GetRecovery(int id);
        int LeyMineralEnd(JObject obj);
        int RecoveryEnd(JObject obj);
        int ConsumeEnd(JObject obj);
    }
}
