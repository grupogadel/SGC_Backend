using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Operations;
using SGC.InterfaceServices.XX.Operations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Operations
{
    public class ServiceMineralsType: IServiceMineralsType
    {
        private readonly string _context;

        public ServiceMineralsType(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/DocIdentity/GetAll
        public async Task<List<MineralsType>> GetAll(int idCompany)
        {
            var response = new List<MineralsType>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MineralsType_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMineralsType(reader));
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

        private MineralsType MapToMineralsType(SqlDataReader reader)
        {
            return new MineralsType()
            {
                MinType_ID = (int)reader["MinType_ID"],
                Company_ID = (int)reader["Company_ID"],
                MinType_Cod = reader["MinType_Cod"].ToString(),
                MinType_Name = reader["MinType_Name"].ToString(),
                MinType_Desc = reader["MinType_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                MinType_Status = reader["MinType_Status"].ToString(),
            };
        }
    }
}
