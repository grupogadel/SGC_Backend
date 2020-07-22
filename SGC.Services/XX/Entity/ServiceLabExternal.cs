using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Entity
{
    public class ServiceLabExternal : IServiceLabExternal
    {
        private readonly string _context;

        public ServiceLabExternal(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/LabExternal/GetAll
        public async Task<List<LabExternal>> GetAll(int idCompany)
        {
            var response = new List<LabExternal>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LabExternal_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToLabExternal(reader));
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

        private LabExternal MapToLabExternal(SqlDataReader reader)
        {
            return new LabExternal()
            {
                LabExt_ID = (int)reader["LabExt_ID"],
                Company_ID = (int)reader["Company_ID"],
                LabExt_Cod = (int)reader["LabExt_Cod"],
                LabExt_Authorized = (bool) reader["LabExt_Authorized"],
                LabExt_Name = reader["LabExt_Name"].ToString(),
				LabExt_Address = reader["LabExt_Address"].ToString(),
                LabExt_City = reader["LabExt_City"].ToString(),
				Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                LabExt_Status = reader["LabExt_Status"].ToString()
            };
        }
    }
}
