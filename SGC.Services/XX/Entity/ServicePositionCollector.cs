
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.XX.Entity
{
    public class ServicePositionCollector : IServicePositionCollector
    {
        private readonly string _context;

        public ServicePositionCollector(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/PositionCollector/GetAll
        public async Task<List<PositionCollector>> GetAll()
        {
            var response = new List<PositionCollector>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].PositionCollector_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPositionCollector(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return new List<PositionCollector>();
                throw e;
            }
        }

        private PositionCollector MapToPositionCollector(SqlDataReader reader)
        {
            return new PositionCollector()
            {
                PosCollec_ID = (int)reader["PosCollec_ID"],
                PosCollec_Cod = (int)reader["PosCollec_Cod"],
                PosCollec_Name = reader["PosCollec_Name"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                PosCollec_Status = reader["PosCollec_Status"].ToString(),
            };
        }

        // GET api/PositionCollector/Get/1
        public PositionCollector Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].PositionCollector_Get";
                cmd.Parameters.Add(new SqlParameter("@PosCollec_ID", id));

                PositionCollector response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToPositionCollector(reader);
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
