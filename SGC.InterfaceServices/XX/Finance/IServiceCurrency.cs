
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.InterfaceServices.XX.Finance
{
    public interface IServiceCurrency
    {
        Task<List<Currency>> GetAll();
        Currency Get(int id);
        int Add(Currency model);
        int Update(Currency model);
        int ChangeStatus(JObject obj);
        Task<List<Currency>> Search(JObject obj);
    }
}
