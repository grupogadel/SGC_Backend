using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Operations.Mining
{
    public class ServiceMaterialType : IServiceMaterialType
    {
        private readonly string _context;

        public ServiceMaterialType(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int Add(MaterialType model)
        {
            throw new NotImplementedException();
        }

        public int Delete(JObject obj)
        {
            throw new NotImplementedException();
        }

        public MaterialType Get(int id)
        {
            throw new NotImplementedException();
        }

        // GET: api/MaterialType/GetAll
        public async Task<List<MaterialType>> GetAll(int idCompany)
        {
            var response = new List<MaterialType>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MaterialType_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMaterialType(reader));
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

        public MaterialType GetCod(string cod)
        {
            throw new NotImplementedException();
        }

        public Task<List<MaterialType>> Search(JObject obj)
        {
            throw new NotImplementedException();
        }

        public int Update(MaterialType model)
        {
            throw new NotImplementedException();
        }

        private MaterialType MapToMaterialType(SqlDataReader reader)
        {
            return new MaterialType()
            {
                MatType_ID = (int)reader["MatType_ID"],
                Company_ID = (int)reader["Company_ID"],
                MatType_Cod = reader["MatType_Cod"].ToString(),
                MatType_Name = reader["MatType_Name"].ToString(),
                MatType_Desc = reader["MatType_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                MatType_Status = reader["MatType_Status"].ToString(),
            };
        }
    }
}
