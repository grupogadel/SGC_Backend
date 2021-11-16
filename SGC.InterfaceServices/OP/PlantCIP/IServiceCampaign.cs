using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.OP.PlantCIP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.OP.PlantCIP
{
    public interface IServiceCampaign
    {
        Task<int> Add(Campaign model);
        Task<int> Update(Campaign model);
        Task<int> ChangeStatus(JObject obj);
        Task<List<Campaign>> Search(JObject obj);
        Task<List<Ruma>> SearchRuma(JObject obj);
        Task<List<Ruma>> GetRumas(int id);
    }
}
