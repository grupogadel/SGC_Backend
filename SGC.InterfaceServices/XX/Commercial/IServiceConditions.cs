using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;

namespace SGC.InterfaceServices.XX.Commercial
{
    public interface IServiceConditions
    {
        //Conditions by Zones
        Task<List<Conditions>> GetAllByZones(int id);
        int AddByZones(Conditions model);
        int UpdateByZones(Conditions model);
        int Delete(JObject obj);

        //Conditions by Origins
        Task<List<Conditions>> GetAllByOrigins(int id);
        int AddByOrigins(Conditions model);
        int UpdateByOrigins(Conditions model);


        //Conditions by Vendors
        Task<List<Conditions>> GetAllByVendors(int id);
        int AddByVendors(Conditions model);
        int UpdateByVendors(Conditions model);

        /*Conditions Get(int id);*/
    }
}
