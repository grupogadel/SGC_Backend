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
    public class ServiceDepartment: IServiceDepartment
    {
        private readonly string _context;

        public ServiceDepartment(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int Add(Department model)
        {
            throw new NotImplementedException();
        }

        public int Delete(Department obj)
        {
            throw new NotImplementedException();
        }

        public Department Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Department>> GetAll()
        {
            var response = new List<Department>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Department_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToDepartment(reader));
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
        private Department MapToDepartment(SqlDataReader reader)
        {
            return new Department()
            {
                Depa_ID = (int)reader["Depa_ID"],
                Region_ID = (int)reader["Region_ID"],
                Depa_Cod = reader["Depa_Cod"].ToString(),
                Depa_Name = reader["Depa_Name"].ToString(),
                Depa_Desc = reader["Depa_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Depa_Status = reader["Depa_Status"].ToString(),
                Regions = new Region
                {
                    Region_ID = (int)reader["Region_ID"],
                    Region_Name = reader["Region_Name"].ToString()
                }
            };
        }
        public int Update(Department model)
        {
            throw new NotImplementedException();
        }
    }
}
