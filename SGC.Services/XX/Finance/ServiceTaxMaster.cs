
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Finance;
using SGC.InterfaceServices.XX.Finance;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.Services.XX.Entity
{
    public class ServiceTaxMaster : IServiceTaxMaster
    {
        private readonly string _context;

        public ServiceTaxMaster(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public async Task<List<TaxMaster>> Search(JObject obj)
        {
            var response = new List<TaxMaster>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[FI].TaxMaster_Search";

                cmd.Parameters.Add(new SqlParameter("@MTax_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToTaxMaster(reader));
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

        private TaxMaster MapToTaxMaster(SqlDataReader reader)
        {
            return new TaxMaster()
            {
                MTax_ID = (int)reader["MTax_ID"],
                Company_ID = (int)reader["Company_ID"],
                MTax_Cod = reader["MTax_Cod"].ToString(),
                MTax_Rate1 = reader["MTax_Rate1"] == DBNull.Value ? 1 : (decimal)reader["MTax_Rate1"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                MTax_Status = reader["MTax_Status"].ToString()
               
            };
        }


    }

}
