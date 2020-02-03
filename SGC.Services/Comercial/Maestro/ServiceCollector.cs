using System.Collections.Generic;
using System.Threading.Tasks;
using SGC.Data;
using Microsoft.EntityFrameworkCore;
using SGC.InterfaceServices.Comercial.Maestro;
using System.Linq;
using SGC.Entities.View.Comercial.Maestro;
using System;
using SGC.Entities.Entities.Comercial.Maestro;

namespace SGC.Services.Comercial.Maestro
{

    public class ServiceCollector : IServiceCollector
    {
        private readonly DbContextSGC _context;
        public ServiceCollector(DbContextSGC context)
        {
            _context = context;
        }

        public async Task<bool> Create(Collector collector)
        {
            try 
            {
                collector.Creation_Date = DateTime.Now;
                collector.Modified_Date = DateTime.Now;
                collector.Collec_Status = "G";
                _context.Collector.Add(collector);
                var result = await _context.SaveChangesAsync() != default(int) ? true : false;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var collector = await _context.Collector.FindAsync(id);
                collector.Collec_Status = "E";

                _context.Collector.Update(collector);

                var result = await _context.SaveChangesAsync() != default(int) ? true : false;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Collector>> GetAll()
        {
            var collectors =  await _context.Collector.ToListAsync();
            try
            {    
                return collectors.Select(c => new Collector
            {
                    Collec_ID = c.Collec_ID,
                    Collec_Cod = c.Collec_Cod,
                    Collec_TaxID = c.Collec_TaxID,
                    Collec_Name = c.Collec_Name,
                    Collec_LastName = c.Collec_LastName,
                    Creation_User = c.Creation_User,
                    Creation_Date = c.Creation_Date,
                    Modified_User = c.Modified_User,
                    Modified_Date = c.Modified_Date,
                    Collec_Status = c.Collec_Status
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
