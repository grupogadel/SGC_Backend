
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.InterfaceServices.XX.Finance
{
    public interface IServiceCurrency
    {
        Task<List<Currency>> GetAll();
        Currency Get(int id);
    }
}
