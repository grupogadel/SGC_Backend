using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Entity
{
    public class ServiceCountry : IServiceCountry
    {
        private readonly string _context;

        public ServiceCountry(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int Add(Country model)
        {
            throw new NotImplementedException();
        }

        public int Delete(Country obj)
        {
            throw new NotImplementedException();
        }

        public Country Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Country>> GetAll()
        {
            var response = new List<Country>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Country_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCountry(reader));
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
        private Country MapToCountry(SqlDataReader reader)
        {
            return new Country()
            {
                Country_ID = (int)reader["Country_ID"],
                Country_Cod = reader["Country_Cod"].ToString(),
                Country_Name = reader["Country_Name"].ToString(),
                Country_Desc = reader["Country_Desc"].ToString(),
                Lenguaje_ID = (int)reader["Lenguaje_ID"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Country_Status = reader["Country_Status"].ToString()
            };
        }

        public int Update(Country model)
        {
            throw new NotImplementedException();
        }

        public Country GetCod(string cod)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Country_GetCod";
                cmd.Parameters.Add(new SqlParameter("@Country_Cod", cod));

                //cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                Country response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToCountry(reader);
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
