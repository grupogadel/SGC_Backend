using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Finance;
using SGC.InterfaceServices.XX.Finance;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Finance
{
    public class ServiceBank: IServiceBank
    {
        private readonly string _context;

        public ServiceBank(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/Currency/GetAll
        public async Task<List<Bank>> GetAll()
        {
            var response = new List<Bank>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Bank_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToBank(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return new List<Bank>();
                throw e;
            }
        }

        private Bank MapToBank(SqlDataReader reader)
        {
            return new Bank()
            {
                Bank_ID = (int)reader["Bank_ID"],
                Country_ID = (int)reader["Country_ID"],
                Bank_Cod = reader["Bank_Cod"].ToString(),
                Bank_Name = reader["Bank_Name"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Bank_Status = reader["Bank_Status"].ToString(),
            };
        }
    }
}
