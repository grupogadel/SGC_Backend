﻿using SGC.Entities.Entities.CM.DataMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGC.InterfaceServices.CM.DataMaster
{
    public interface IServiceZone
    {
        Task<List<Zone>> GetAll();
        int Add(Zone model);
        int Update(Zone model);
        int Delete(int id);
        Zone Get(int id);
    }
}