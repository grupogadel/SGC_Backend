using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.FI.DataMaster;
using SGC.InterfaceServices.FI.DataMaster;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.FI.DataMaster
{
    public class ServiceChartAccLocMaster : IServiceChartAccLocMaster
    {
        private readonly string _context;

        public ServiceChartAccLocMaster(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // POST: api/ChartAccLocMaster/GetAll/{}
        public async Task<List<ChartAccLocMaster>> GetAll(JObject obj)
        {
            var response = new List<ChartAccLocMaster>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[FI].ChartAccLocMaster_GetAll";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToChartAccLocMaster(reader));
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

        private ChartAccLocMaster MapToChartAccLocMaster(SqlDataReader reader)
        {
            return new ChartAccLocMaster()
            {
                MAccL_ID = (int)reader["MAccL_ID"],
                Company_ID = (int)reader["Company_ID"],
                MAccL_Cod = reader["MAccL_Cod"].ToString(),
                MAccL_Level = reader["MAccL_Level"].ToString(),
                MAccL_Father = reader["MAccL_Father"].ToString(),
                MAccL_Desc = reader["MAccL_Desc"].ToString(),
                AccCat_Desc = reader["AccCat_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                MAccL_Status = reader["MAccL_Status"].ToString()
            };
        }

        
    }
}
