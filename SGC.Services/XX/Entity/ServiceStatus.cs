
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.Services.XX.Entity
{
    public class ServiceStatus : IServiceStatus
    {
        private readonly string _context;

        public ServiceStatus(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        private Status MapToStatus(SqlDataReader reader)
        {
            return new Status()
            {
                Status_ID = (int)reader["Status_ID"],
                Status_Cod = reader["Status_Cod"].ToString(),
                Status_Cod2 = reader["Status_Cod2"].ToString(),
                Status_Name = reader["Status_Name"].ToString(),
                Status_Desc = reader["Status_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Status_Status = reader["Status_Status"].ToString(),
            };
        }

        public int Add(Status model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Status_Add";
                cmd.Parameters.Add(new SqlParameter("@Status_Cod", model.Status_Cod));
                cmd.Parameters.Add(new SqlParameter("@Status_Name", model.Status_Name));
                cmd.Parameters.Add(new SqlParameter("@Status_Desc", model.Status_Desc));
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

        // PUT: api/Status/Update/
        public int Update(Status model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Status_Update";
                cmd.Parameters.Add(new SqlParameter("@Status_ID", model.Status_ID));
                cmd.Parameters.Add(new SqlParameter("@Status_Name", model.Status_Name));
                cmd.Parameters.Add(new SqlParameter("@Status_Desc", model.Status_Desc));
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

        public int ChangeStatus(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Status_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@Status_ID", obj["id"].ToObject<int>()));
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

        public async Task<List<Status>> Search(JObject obj)
        {
            var response = new List<Status>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Status_Search";

                cmd.Parameters.Add(new SqlParameter("@Status_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToStatus(reader));
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
