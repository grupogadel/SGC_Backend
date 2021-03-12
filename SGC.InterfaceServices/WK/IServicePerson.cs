using SGC.Entities.Entities.WK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.InterfaceServices.WK
{
    public interface IServicePerson
    {
		Task<List<Person>> GetAll();
        int Add(Person model);
        int Update(Person model);
		//Task<List<Position>> Search(JObject obj);
    }
}
