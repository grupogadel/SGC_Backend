using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.FI.DataMaster;
using SGC.InterfaceServices.FI.DataMaster;
using SGC.Entities.Entities.XX.Finance;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.FI.DataMaster
{
    public class ServiceComprobanteDePago : IServiceComprobanteDePago
    {
        private readonly string _context;

        public ServiceComprobanteDePago(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        private ComprobanteDePago MapToComprobanteDePago(SqlDataReader reader)
        {
            return new ComprobanteDePago()
            {
                CompPago_ID = (int)reader["CompPago_ID"],
                CompPago_Cod = reader["CompPago_Cod"].ToString(),
                CompPago_Desc = reader["CompPago_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                CompPago_Status = reader["CompPago_Status"].ToString(),
            };
        }

        public async Task<List<ComprobanteDePago>> Search()
        {
            var response = new List<ComprobanteDePago>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[FI].ComprobanteDePago_Search";
              

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToComprobanteDePago(reader));
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
    }
}
