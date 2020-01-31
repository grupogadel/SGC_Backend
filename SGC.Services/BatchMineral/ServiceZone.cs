using Microsoft.EntityFrameworkCore;
using SGC.Data;
using SGC.Entities.View.BatchMineral;
using SGC.InterfaceServices.BatchMineral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.BatchMineral
{
    public class ServiceZone : IServiceZone
    {
        private readonly DbContextSGC _context;
        public ServiceZone(DbContextSGC context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ZoneView>> GetAll()
        {
            var zone = await _context.Zones.ToListAsync();

            return zone.Select(z => new ZoneView
            {
                Zone_ID = z.Zone_ID,
                District_ID = z.District_ID,
                Zone_Cod = z.Zone_Cod,
                Zone_Name = z.Zone_Name,
                Zone_Desc = z.Zone_Desc,
                Creation_User = z.Creation_User,
                Creation_Date = z.Creation_Date,
                Modified_User = z.Modified_User,
                Modified_Date = z.Modified_Date
            });
        }
    }
}
