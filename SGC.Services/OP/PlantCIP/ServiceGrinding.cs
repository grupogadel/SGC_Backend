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
    public class ServiceGrinding : IServiceGrinding
    {
        private readonly string _context;

        public ServiceGrinding(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
    
        private GrindingHead MapToGrindingHead(SqlDataReader reader)
        {
            return new GrindingHead()
            {
                GrindH_ID = (int)reader["GrindH_ID"],
                CampH_ID = (int)reader["CampH_ID"],
                Circuit_ID = (int)reader["Circuit_ID"],
                GrindH_Date = (DateTime)reader["GrindH_Date"],
                GrindH_GravEsp_GE = (decimal)reader["GrindH_GravEsp_GE"],
                GrindH_DensAver = (decimal)reader["GrindH_DensAver"],
                GrindH_SolidosPor = (decimal)reader["GrindH_SolidosPor"],
                GrindH_WeightS = (decimal)reader["GrindH_WeightS"],
                GrindH_DIL = (decimal)reader["GrindH_DIL"],
                GrindH_VOLSOL = (decimal)reader["GrindH_VOLSOL"],
                GrindH_Cola_Mesh = (decimal)reader["GrindH_Cola_Mesh"],
                GrindH_Operator_User = reader["GrindH_Operator_User"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                GrindH_Status = reader["GrindH_Status"].ToString(),

                CampH_NO = reader["CampH_NO"].ToString(),
            };
        }
        public async Task<List<GrindingHead>> Search(JObject obj)
        {
            var response = new List<GrindingHead>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].GrindingHead_Search";

                cmd.Parameters.Add(new SqlParameter("@CampH_NO", obj["campH_NO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToGrindingHead(reader));
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
