
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace SGC.Services.XX.Entity

{
    public class ServicePolicyCorp : IServicePolicyCorp
    {
        private readonly string _context;

        public ServicePolicyCorp(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/PolicyCorp/GetAll/1
        public async Task<List<PolicyCorp>> GetAll(int idCompany)
        {
            var response = new List<PolicyCorp>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].PolicyCorp_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPolicyCorp(reader));
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

        private PolicyCorp MapToPolicyCorp(SqlDataReader reader)
        {
            return new PolicyCorp()
            {
                PolCorp_ID = (int)reader["PolCorp_ID"],
                Company_ID = (int)reader["Company_ID"],
                PolCorp_Cod = reader["PolCorp_Cod"].ToString(),
                PolCorp_Value1 = (decimal)reader["PolCorp_Value1"],
                PolCorp_Value2 = reader["PolCorp_Value2"] == DBNull.Value ? (decimal?)null: (decimal)reader["PolCorp_Value2"],
                PolCorp_Desc = reader["PolCorp_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                PolCorp_Status = reader["PolCorp_Status"].ToString()
            };
        }


        // PUT: api/PolicyCorp/Update/{}
        public int Update(PolicyCorp model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].PolicyCorp_Update";

                cmd.Parameters.Add(new SqlParameter("@PolCorp_ID", model.PolCorp_ID));
                cmd.Parameters.Add(new SqlParameter("@PolCorp_Value1", model.PolCorp_Value1));
                cmd.Parameters.Add(new SqlParameter("@PolCorp_Value2", model.PolCorp_Value2));
                cmd.Parameters.Add(new SqlParameter("@PolCorp_Desc", model.PolCorp_Desc));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));

                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                conn.Close();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }

        public async Task<List<PolicyCorp>> Search(JObject obj)
        {
            var response = new List<PolicyCorp>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].PolicyCorp_Search";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@PolCorp_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPolicyCorp(reader));
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
