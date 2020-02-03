using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGC.Data;
using SGC.Entities.Entities.Comercial.Maestros;
using SGC.Entities.View.Comercial.Maestros.Zona;
using SGC.InterfaceServices.Comercial.Maestros;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.Comercial.Maestros
{
    public class ServiceZona : IServiceZona
    {
        private readonly DbContextSGC _context;
        public ServiceZona(DbContextSGC context)
        {
            _context = context;
        }

        public bool Add(Zona model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public Zona Get(int id)
        {
            var result = new Zona();

            try
            {
                result = _context.Zonas.Single(x => x.Zona_ID == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        // GET: api/Zones/Select
        public async Task<IEnumerable<ZonaView>> GetAll()
        {
            var zone = await _context.Zonas.ToListAsync();

            return zone.Select(z => new ZonaView
            {
                Zona_ID = z.Zona_ID,
                Zone_Cod = z.Zone_Cod,
                Dist_ID = z.Dist_ID,
                Zone_Name = z.Zone_Name,
                Zone_Desc = z.Zone_Desc,
                Zone_Status = z.Zone_Status,
            });
        }
        // GET: api/Zones/Select
        public async Task<IEnumerable<SelectView>> Selec()
        {
            var categoria = await _context.Zonas.Where(c => (c.Zone_Status == "3")).ToListAsync();

            return categoria.Select(c => new SelectView
            {
                Zone_Cod = c.Zone_Cod,
                Zone_Name = c.Zone_Name
            });
        }

        public bool Update(Zona model)
        {
            try
            {
                var originalModel = _context.Zonas.Single(x =>
                    x.Zona_ID == model.Zona_ID
                );

                originalModel.Zone_Cod = model.Zone_Cod;
                originalModel.Zone_Name = model.Zone_Name;
                originalModel.Zone_Desc = model.Zone_Desc;
                originalModel.Zone_Status = model.Zone_Status;

                _context.Update(originalModel);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                _context.Entry(new Zona { Zona_ID = id }).State = EntityState.Deleted; ;
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}