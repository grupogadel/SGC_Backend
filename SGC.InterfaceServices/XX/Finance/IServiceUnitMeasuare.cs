
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.InterfaceServices.XX.Finance
{
    public interface IServiceUnitMeasuare
    {
        int Add(UnitMeasuare model);
        int Update(UnitMeasuare model);
        int ChangeStatus(JObject obj);
        Task<List<UnitMeasuare>> Search(JObject obj);
    }
}
