using Microsoft.EntityFrameworkCore;
using SGC.Data;
using SGC.Entities.View.Comercial.Maestros.Origin;
using SGC.InterfaceServices.Comercial.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.Comercial.Maestros
{
    public class ServiceOrigin:IServiceOrigin
    {
        private readonly DbContextSGC _context;
        public ServiceOrigin(DbContextSGC context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OriginView>> GetAll()
        {
            var origin = await _context.Origins.Include(o => o.Zona).ToListAsync();

            return origin.Select(o => new OriginView
            {
                Orig_ID = o.Orig_ID,
                Zona_ID = o.Zona_ID,
                Zona_Name=o.Zona.Zone_Name,
                Orig_Cod = o.Orig_Cod,
                Orig_Name = o.Orig_Name,
                Orig_Desc = o.Orig_Desc,
                Orig_Address = o.Orig_Address,
                Orig_Reference = o.Orig_Reference,
                Orig_Coordinates = o.Orig_Coordinates,
                Orig_Status = o.Orig_Status,
            });
        }
    }
}