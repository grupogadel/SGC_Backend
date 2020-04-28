using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Entity
{
    public class ServiceCorrelDocuments : IServiceCorrelDocuments
    {
        private readonly string _context;

        public ServiceCorrelDocuments(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/CorrelDocuments/GetAll
        public async Task<List<CorrelDocuments>> GetAll(int idCompany)
        {
            var response = new List<CorrelDocuments>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CorrelDocuments_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCorrelDocuments(reader));
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

        private CorrelDocuments MapToCorrelDocuments(SqlDataReader reader)
        {
            return new CorrelDocuments()
            {
                Correl_ID = (int)reader["Correl_ID"],
                Company_ID = (int)reader["Company_ID"],
                Correl_Cod = reader["Correl_Cod"].ToString(),
                Correl_Module = reader["Correl_Module"].ToString(),
                Correl_ProcessName = reader["Correl_ProcessName"].ToString(),
                Correl_TransacName = reader["Correl_TransacName"].ToString(),
                Correl_Prefix = reader["Correl_Prefix"].ToString(),
                Correl_OrigDoc_NO = reader["Correl_OrigDoc_NO"].ToString(),
                Correl_AcctDoc_NO = reader["Correl_AcctDoc_NO"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Correl_Status = reader["Correl_Status"].ToString()
            };
        }

        // PUT: api/CorrelDocuments/Update/1
        public int Update(CorrelDocuments model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CorrelDocuments_Update";

                cmd.Parameters.Add(new SqlParameter("@Correl_ID", model.Correl_ID));
                cmd.Parameters.Add(new SqlParameter("@Correl_Prefix", model.Correl_Prefix));
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

        public async Task<List<CorrelDocuments>> Search(JObject obj)
        {
            var response = new List<CorrelDocuments>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CorrelDocuments_Search";

                cmd.Parameters.Add(new SqlParameter("@Correl_Cod", obj["cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["companyID"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCorrelDocuments(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return response;// 
                throw e;
            }
        }
    }
}
