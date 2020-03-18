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
    public class ServiceDocIdentity : IServiceDocIdentity
    {
        private readonly string _context;

        public ServiceDocIdentity(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/DocIdentity/GetAll
        public async Task<List<DocIdentity>> GetAll()
        {
            var response = new List<DocIdentity>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].DocIdentity_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToDocIdentity(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return new List<DocIdentity>();
                throw e;
            }
        }

        private DocIdentity MapToDocIdentity(SqlDataReader reader)
        {
            return new DocIdentity()
            {
                DocIdent_ID = (int)reader["DocIdent_ID"],
                DocIdent_Cod = reader["DocIdent_Cod"].ToString(),
                DocIdent_Name = reader["DocIdent_Name"].ToString(),
                DocIdent_Desc = reader["DocIdent_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                DocIdent_Status = reader["DocIdent_Status"].ToString(),
            };
        }
    }
}
