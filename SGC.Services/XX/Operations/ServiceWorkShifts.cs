using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Operations;
using SGC.InterfaceServices.XX.Operations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.XX.Operations
{
    public class ServiceWorkShifts : IServiceWorkShifts
    {
        private readonly string _context;

        public ServiceWorkShifts(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/WorkShifts/GetAll
        public async Task<List<WorkShifts>> GetAll()
        {
            var response = new List<WorkShifts>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].WorkShifts_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToWorkShifts(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return response;
                throw e;
            }
        }

        private WorkShifts MapToWorkShifts(SqlDataReader reader)
        {
            return new WorkShifts()
            {
                WrkShi_ID = (int)reader["WrkShi_ID"],
                WrkShi_Cod = reader["WrkShi_Cod"].ToString(),
                WrkShi_Desc = reader["WrkShi_Desc"].ToString(),
                WrkShi_TimeStar = (DateTime)reader["WrkShi_TimeStar"],
                WrkShi_TimeEnd = (DateTime)reader["WrkShi_TimeEnd"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                WrkShi_Status = reader["WrkShi_Status"].ToString(),
            };
        }
    }
}
