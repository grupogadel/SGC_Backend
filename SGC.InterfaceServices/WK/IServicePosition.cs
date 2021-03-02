using SGC.Entities.Entities.WK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.InterfaceServices.WK
{
    public interface IServicePosition
    {
		Task<List<Position>> GetAll();
        int Add(Position model);
        int Update(Position model);
		Task<List<Position>> Search(JObject obj);
    }
}
