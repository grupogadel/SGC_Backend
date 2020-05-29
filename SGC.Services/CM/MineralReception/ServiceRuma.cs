using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.MineralReception
{
    public class ServiceRuma : IServiceRuma
    {
        private readonly string _context;

        public ServiceRuma(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        public async Task<List<Ruma>> GetAll(int idCompany)
        {
            var response = new List<Ruma>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Ruma_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToRuma(reader));
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
        private Ruma MapToRuma(SqlDataReader reader)
        {
            return new Ruma()
            {
                Ruma_ID = (int)reader["Ruma_ID"],
                Company_ID = (int)reader["Company_ID"],
                Ruma_NO = reader["Ruma_NO"].ToString(),
                Ruma_Desc = reader["Ruma_Desc"].ToString(),
                MinType_ID = (int)reader["MinType_ID"],
                Ruma_Date = (DateTime)reader["Ruma_Date"],
                Ruma_Period = reader["Ruma_Period"].ToString(),
                Ruma_Weigth = (decimal)reader["Ruma_Weigth"],
                Ruma_LeyAu = (decimal)reader["Ruma_LeyAu"],
                Ruma_LeyAg = (decimal)reader["Ruma_LeyAg"],
                Ruma_RecovAu = (decimal)reader["Ruma_RecovAu"],
                Ruma_RecovAg = (decimal)reader["Ruma_RecovAg"],
                Ruma_ConsNaCN = (decimal)reader["Ruma_ConsNaCN"],
                Ruma_ConsNaOH = (decimal)reader["Ruma_ConsNaOH"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Ruma_Status = reader["Ruma_Status"].ToString(),
                MineralTypes = new MineralsType
                {
                    MinType_ID = (int)reader["MinType_ID"],
                    MinType_Cod = reader["MinType_Cod"].ToString(),
                    MinType_Desc = reader["MinType_Desc"].ToString()
                },
            };
        }
        public async Task<List<Ruma>> Search(JObject obj)
        {
            var response = new List<Ruma>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Ruma_Search";

                cmd.Parameters.Add(new SqlParameter("@Ruma_NO", obj["ruma"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToRuma(reader));
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

        public int Add(Ruma model)
        {
            throw new NotImplementedException();
        }

        public int Update(Ruma model)
        {
            throw new NotImplementedException();
        }

        public int Delete(JObject obj)
        {
            throw new NotImplementedException();
        }

        public Ruma Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
