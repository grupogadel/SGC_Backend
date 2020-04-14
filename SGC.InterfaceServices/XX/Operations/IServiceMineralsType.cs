using SGC.Entities.Entities.XX.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations
{
    public interface IServiceMineralsType
    {
        Task<List<MineralsType>> GetAll(int id);
    }
}
