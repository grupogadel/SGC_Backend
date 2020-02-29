
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.XX.Entity
{
    public class ServiceMPeriod : IServiceMPeriod
    {
        private readonly string _context;

        public ServiceMPeriod(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/MPeriod/GetAll
        public async Task<List<MPeriod>> GetAll()
        {
            var response = new List<MPeriod>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MPeriod_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMPeriod(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return new List<MPeriod>();
                throw e;
            }
        }

        private MPeriod MapToMPeriod(SqlDataReader reader)
        {
            return new MPeriod()
            {
                MPeriod_ID = (int)reader["MPeriod_ID"],
                MPeriod_Cod = reader["MPeriod_Cod"].ToString(),
                MPeriod_Name = reader["MPeriod_Name"].ToString(),
                MPeriod_Name2 = reader["MPeriod_Name2"].ToString(),
                MPeriod_Desc = reader["MPeriod_Desc"].ToString(),
                MPeriod_Month = reader["MPeriod_Month"].ToString(),
                MPeriod_Status = reader["MPeriod_Status"].ToString(),
            };
        }

        // GET api/MPeriod/Get/1
        public MPeriod Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MPeriod_Get";
                cmd.Parameters.Add(new SqlParameter("@MPeriod_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                MPeriod response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToMPeriod(reader);
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
