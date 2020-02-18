
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Finance;
using SGC.InterfaceServices.XX.Finance;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.XX.Entity
{
    public class ServiceCurrency : IServiceCurrency
    {
        private readonly string _context;

        public ServiceCurrency(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Currency/GetAll
        public async Task<List<Currency>> GetAll()
        {
            var response = new List<Currency>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Currency_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCurrency(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return new List<Currency>();
                throw e;
            }
        }

        private Currency MapToCurrency(SqlDataReader reader)
        {
            return new Currency()
            {
                Currency_ID = (int)reader["Currency_ID"],
                Currency_Country = reader["Currency_Country"].ToString(),
                Currency_Cod = reader["Currency_Cod"].ToString(),
                Currency_Name = reader["Currency_Name"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Currency_Status = reader["Currency_Status"].ToString(),
            };
        }

        // GET api/Currency/Get/1
        public Currency Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Currency_Get";
                cmd.Parameters.Add(new SqlParameter("@Currency_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                Currency response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToCurrency(reader);
                    }
                }
                conn.Close();
                return response;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

    }

}
