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

    public class ServicePeriod : IServicePeriod
    {
        private readonly DbContextSGC _context;
        public ServicePeriod(DbContextSGC context)
        {
            _context = context;
        }

        private static ICollection<Period> FormatAnonymousType(ICollection<PeriodView> entitiesFormatted)
        {
            try
            {
                return entitiesFormatted.Select(c => new Period
                {
                    Period_ID = c.Id,
                    Company_ID = c.Company_ID,
                    Period_Value = c.Period_Value,
                    Period_Cod = c.Period_Cod,
                    Period_Year = c.Period_Year,
                    Period_Date_Start = c.Period_Date_Start,
                    Period_Date_End = c.Period_Date_End,
                    Creation_User = c.Creation_User,
                    Creation_Date = c.Creation_Date,
                    Modified_User = c.Modified_User,
                    Modified_Date = c.Modified_Date,
                    Period_Status = c.Period_Status,

                    Period_Global = new Global { 
                        Glob_ID = c.Period_Value_ID, 
                        Globa_Name = c.Period_Name, 
                        Globa_Name2 = c.Period_Name2
                    },
                    Status = new Global
                    {
                        Glob_ID = c.Status_ID,
                        Globa_Name = c.Status_Name
                    }

                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Create(Period period)
        {
            try 
            {
                period.Period_Cod = period.Period_Value + "/" + period.Period_Year;
                period.Period_Status = "G";
                period.Creation_Date = DateTime.Now;
                period.Modified_Date = DateTime.Now;
                _context.Period.Add(period);
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
                var period = await _context.Period.FindAsync(id);
                period.Period_Status = "E";

                _context.Period.Update(period);

                var result = await _context.SaveChangesAsync() != default(int) ? true : false;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Period>> GetAll()
        {
            try
            {
                IEnumerable<Period> entitiesAnonymousType  = await _context.Period.Where(x => (x.Period_Status == "G")).Include("Company").ToListAsync();
                return entitiesAnonymousType;
                //return periods.Select(c => new Period
                //{
                //    Period_ID = c.Period_ID,
                //    Company_ID = c.Company_ID,
                //    Period_Value = c.Period_Value,
                //    Period_Cod = c.Period_Cod,
                //    Period_Year = c.Period_Year,
                //    Period_Date_Start = c.Period_Date_Start,
                //    Period_Date_End = c.Period_Date_End,
                //    Creation_User = c.Creation_User,
                //    Creation_Date = c.Creation_Date,
                //    Modified_User = c.Modified_User,
                //    Modified_Date = c.Modified_Date,
                //    Period_Status = c.Period_Status
                //});;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Period>> Search(int id)
        {
            try
            {
                ICollection<Period> entities = new HashSet<Period>();
                ICollection<PeriodView> entitiesAnonymousType = new HashSet<PeriodView>();

                entitiesAnonymousType = await _context.PeriodView.Where(x => (x.Id == id)).ToListAsync();
                entities = FormatAnonymousType(entitiesAnonymousType);

                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
