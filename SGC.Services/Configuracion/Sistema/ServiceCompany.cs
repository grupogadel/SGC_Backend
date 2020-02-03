using System.Collections.Generic;
using System.Threading.Tasks;
using SGC.Data;
using Microsoft.EntityFrameworkCore;
using SGC.InterfaceServices.Configuracion.Sistema;
using System.Linq;
using SGC.Entities.View.Configuracion.Sistema;
using System;
using SGC.Entities.Entities.Configuracion.Sistema;

namespace SGC.Services.Configuracion.Sistema
{

    public class ServiceCompany : IServiceCompany
    {
        private readonly DbContextSGC _context;
        public ServiceCompany(DbContextSGC context)
        {
            _context = context;
        }

        public async Task<bool> Create(Company company)
        {
            try 
            {
                company.Compa_Status = "G";
                _context.Company.Add(company);
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
                var company = await _context.Company.FindAsync(id);
                company.Compa_Status = "E";

                _context.Company.Update(company);

                var result = await _context.SaveChangesAsync() != default(int) ? true : false;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            var companys =  await _context.Company.ToListAsync();
            try
            {    
                return companys.Select(c => new Company
            {
                    Compa_ID = c.Compa_ID,
                    Compa_Cod = c.Compa_Cod,
                    Compa_Name = c.Compa_Name,
                    Compa_TaxID = c.Compa_TaxID,
                    Compa_Country = c.Compa_Country,
                    Compa_Region = c.Compa_Region,
                    Compa_Address = c.Compa_Address,
                    Compa_Curr_Funct = c.Compa_Curr_Funct,
                    Compa_Curr_Loc = c.Compa_Curr_Loc,
                    Compa_Curr_Grp = c.Compa_Curr_Grp,
                    Compa_AcctDeb = c.Compa_AcctDeb,
                    Compa_AcctCre = c.Compa_AcctCre,
                    Compa_Status = c.Compa_Status
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
