using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Operations.Mining
{
    public class ServicePlants : IServicePlants
    {
        private readonly string _context;

        public ServicePlants(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
    
        private Plants MapToPlants(SqlDataReader reader)
        {
            return new Plants()
            {
                Plant_ID = (int)reader["Plant_ID"],
                Company_ID = (int)reader["Company_ID"],
                Plant_Cod = (int)reader["Plant_Cod"],
                Plant_Desc = reader["Plant_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Plant_Status = reader["Plant_Status"].ToString(),
            };
        }
        public async Task<List<Plants>> Search(JObject obj)
        {
            var response = new List<Plants>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Plants_Search";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPlants(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return response;// 
                throw e;
            }
        }
    }
}
