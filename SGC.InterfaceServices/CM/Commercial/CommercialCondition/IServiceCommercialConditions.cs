using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.CommercialCondition;

namespace SGC.InterfaceServices.CM.Commercial.CommercialCondition
{
    public interface IServiceCommercialConditions
    {
        //Conditions by Zones
        Task<List<CommercialConditions>> GetAllByZones(int id);
        int AddByZones(CommercialConditions model);
        int UpdateByZones(CommercialConditions model);
        int Delete(JObject obj);

        //Conditions by Origins
        Task<List<CommercialConditions>> GetAllByOrigins(int id);
        int AddByOrigins(CommercialConditions model);
        int UpdateByOrigins(CommercialConditions model);

        //Conditions by Vendors
        Task<List<CommercialConditions>> GetAllByVendors(int id);
        int AddByVendors(CommercialConditions model);
        int UpdateByVendors(CommercialConditions model);
		
		//Update by Maquilas
		int UpdateByMaquilas(CommercialConditions model);
    }
}
