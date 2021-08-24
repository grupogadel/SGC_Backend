using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.FI.DataMaster;

namespace SGC.InterfaceServices.FI.DataMaster
{
    public interface IServiceComprobanteDePago

    {
        Task<List<ComprobanteDePago>> Search();
    }
}
