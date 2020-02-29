
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServiceMPeriod
    {
        Task<List<MPeriod>> GetAll();
        MPeriod Get(int id);
    }
}
