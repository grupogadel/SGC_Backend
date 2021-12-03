using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.WK;
using SGC.InterfaceServices.WK;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.Services.WK
{
    public class ServiceAccess : IServiceAccess
    {
        private readonly string _context;

        public ServiceAccess(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        private Access MapToAccess(SqlDataReader reader)
        {
            return new Access()
            {
                Access_ID = (int)reader["Access_ID"],
                Module_ID = (int)reader["Module_ID"],
                Access_Cod = reader["Access_Cod"].ToString(),
                Access_Name = reader["Access_Name"].ToString(),
                Access_Desc = reader["Access_Desc"].ToString(),
                Access_Url = reader["Access_Url"].ToString(),
                Access_IconName = reader["Access_IconName"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Access_Status = reader["Access_Status"].ToString(),
                Module = new Module{
                     Module_Name = reader["Module_Name"].ToString(),
                     Module_Cod = reader["Module_Cod"].ToString(),
                }
            };
        }

        public int ChangeStatus(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Access_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@Access_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Action", obj["action"].ToObject<string>()));

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
        public async Task<List<Access>> Search(JObject obj)
        {
            var response = new List<Access>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Access_Search";
				
				cmd.Parameters.Add(new SqlParameter("@Access_Cod", obj["access_Cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Access_Name", obj["access_Name"].ToObject<string>()));
               
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToAccess(reader));
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

        // POST: api/Access/Add/{}
        public int Add(Access model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Access_Add";
                cmd.Parameters.Add(new SqlParameter("@Access_Cod", model.Access_Cod));
                cmd.Parameters.Add(new SqlParameter("@Access_Name", model.Access_Name));
                cmd.Parameters.Add(new SqlParameter("@Access_Desc", model.Access_Desc));
                cmd.Parameters.Add(new SqlParameter("@Access_Url", model.Access_Url));
                cmd.Parameters.Add(new SqlParameter("@Access_IconName", model.Access_IconName));
                cmd.Parameters.Add(new SqlParameter("@Module_ID", model.Module_ID));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));

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

        // PUT: api/Access/Update/{}
        public int Update(Access model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Access_Update";
                cmd.Parameters.Add(new SqlParameter("@Access_ID", model.Access_ID));
                cmd.Parameters.Add(new SqlParameter("@Access_Name", model.Access_Name));
                cmd.Parameters.Add(new SqlParameter("@Access_Desc", model.Access_Desc));
                cmd.Parameters.Add(new SqlParameter("@Access_IconName", model.Access_IconName));
                cmd.Parameters.Add(new SqlParameter("@Module_ID", model.Module_ID));
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

    }
}
