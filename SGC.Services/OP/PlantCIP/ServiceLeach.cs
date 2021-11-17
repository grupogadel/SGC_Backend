using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.OP.PlantCIP;
using SGC.InterfaceServices.OP.PlantCIP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.OP.PlantCIP
{
    public class ServiceLeach : IServiceLeach
    {
        private readonly string _context;

        public ServiceLeach(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
    
        private LeachHeader MapToLeachHead(SqlDataReader reader)
        {
            return new LeachHeader()
            {
                LeachH_ID = (int)reader["LeachH_ID"],
                CampH_ID = (int)reader["CampH_ID"],
                Company_ID = (int)reader["Company_ID"],
                LeachH_Process_Date = (DateTime)reader["LeachH_Process_Date"],
                LeachH_NO = reader["LeachH_NO"].ToString(),
                LeachH_Desc = reader["LeachH_Desc"].ToString(),
                LeachH_First_Date = (DateTime)reader["LeachH_First_Date"],
                LeachH_End_Date = (DateTime)reader["LeachH_End_Date"],
                LeachH_Coal_FinosAuGr = (decimal)reader["LeachH_Coal_FinosAuGr"],
                LeachH_Coal_FinosAgGr = (decimal)reader["LeachH_Coal_FinosAgGr"],
                LeachH_Solid_FinosAuGr = (decimal)reader["LeachH_Solid_FinosAuGr"],
                LeachH_Solid_FinosAgGr = (decimal)reader["LeachH_Solid_FinosAgGr"],
                LeachH_Solution_FinosAuGr = (decimal)reader["LeachH_Solution_FinosAuGr"],
                LeachH_Solution_FinosAgGr = (decimal)reader["LeachH_Solution_FinosAgGr"],
                LeachH_Authsd_By = reader["LeachH_Authsd_By"].ToString(),
                LeachH_Authsd_Date = (DateTime)reader["LeachH_Authsd_Date"],
                LeachH_Authsd_Status = reader["LeachH_Authsd_Status"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                LeachH_Status = reader["LeachH_Status"].ToString(),

                CampH_NO = reader["CampH_NO"].ToString(),
            };
        }
        public async Task<List<LeachHeader>> Search(JObject obj)
        {
            var response = new List<LeachHeader>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].LeachHeader_Search";

                cmd.Parameters.Add(new SqlParameter("@CampH_NO", obj["campH_NO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToLeachHead(reader));
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
