using SGC.Entities.Entities.XX.Operations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.XX.Operations
{
    public interface IServiceWorkShifts
    {
        Task<List<WorkShifts>> GetAll();
    }
}
