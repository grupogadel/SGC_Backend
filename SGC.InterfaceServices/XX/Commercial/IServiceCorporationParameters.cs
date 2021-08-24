using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Commercial
{
    public interface IServiceCorporationParameters
    {
        Task<List<CorporationParameters>> GetAll(int id);
        int Add(CorporationParameters model);
        int Update(CorporationParameters model);
        int Delete(JObject obj);
        Task<List<CorporationParameters>> Search(JObject obj);
    }
}
