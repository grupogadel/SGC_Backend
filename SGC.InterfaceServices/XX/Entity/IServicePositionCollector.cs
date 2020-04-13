
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.XX.Entity;

namespace SGC.InterfaceServices.XX.Entity
{
    public interface IServicePositionCollector
    {
        Task<List<PositionCollector>> GetAll();
        PositionCollector Get(int id);
    }
}
