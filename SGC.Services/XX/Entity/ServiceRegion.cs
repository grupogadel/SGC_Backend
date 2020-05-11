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
    public class ServiceRegion:IServiceRegion
    {
        private readonly string _context;

        public ServiceRegion(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int Add(Region model)
        {
            throw new NotImplementedException();
        }

        public int Delete(Region obj)
        {
            throw new NotImplementedException();
        }

        public Region Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAll()
        {
            var response = new List<Region>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Region_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToRegion(reader));
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
        private Region MapToRegion(SqlDataReader reader)
        {
            return new Region()
            {
                Region_ID = (int)reader["Region_ID"],
                Country_ID = (int)reader["Country_ID"],
                Region_Cod = reader["Region_Cod"].ToString(),
                Region_Name = reader["Region_Name"].ToString(),
                Region_Desc = reader["Region_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Region_Status = reader["Region_Status"].ToString(),
                Countrys = new Country
                {
                    Country_ID = (int)reader["Country_ID"],
                    Country_Name = reader["Country_Name"].ToString()
                }
            };
        }

        public int Update(Region model)
        {
            throw new NotImplementedException();
        }
    }
}
