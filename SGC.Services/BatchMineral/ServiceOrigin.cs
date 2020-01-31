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
    public class ServiceOrigin: IServiceOrigin
    {
        private readonly DbContextSGC _context;
        public ServiceOrigin(DbContextSGC context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OriginView>> GetAll()
        {
            var origin = await _context.Origins.Include(o => o.zone).ToListAsync();
            try{
                return origin.Select(o => new OriginView
                {
                    Orig_ID = o.Orig_ID,
                    Orig_Date = o.Orig_Date,
                    Zone_ID = o.Zone_ID,
                    zone = o.zone.Zone_Name,
                    Orig_Cod = o.Orig_Cod,
                    Orig_Name = o.Orig_Name,
                    Orig_Desc = o.Orig_Desc,
                    Orig_Address = o.Orig_Address,
                    Orig_Reference = o.Orig_Reference,
                    Orig_Coordinates = o.Orig_Coordinates,
                    Orig_Status = o.Orig_Status
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}