using SGC.Entities.Entities.CM.DataMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.DataMaster
{
    public interface IServiceVendorOrigin
    {
        Task<List<VendorOrigin>> GetAllVendors(int id);
    }
}
