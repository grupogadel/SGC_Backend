using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Commercial.Laboratory
{
    public interface IServiceAnalisysType
    {
        Task<List<AnalisysType>> GetAll(int id);
        int Add(AnalisysType model);
        int Update(AnalisysType model);
        int Delete(JObject obj);
        AnalisysType Get(int id);
        AnalisysType GetCod(String cod);
        Task<List<AnalisysType>> Search(JObject obj);
    }
}
