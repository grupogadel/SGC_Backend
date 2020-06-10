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
    public class ServiceMetricSetting : IServiceMetricSetting
    {
        private readonly string _context;

        public ServiceMetricSetting(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/MetricSetting/GetAll
        public async Task<List<MetricSetting>> GetAll(int idCompany)
        {
            var response = new List<MetricSetting>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MetricSetting_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMetricSetting(reader));
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

        private MetricSetting MapToMetricSetting(SqlDataReader reader)
        {
            return new MetricSetting()
            {
                MetSet_ID = (int)reader["MetSet_ID"],
                Company_ID = (int)reader["Company_ID"],
                MetSet_Cod = reader["MetSet_Cod"].ToString(),
                MetSet_Value = (decimal)reader["MetSet_Value"],
                MetSet_Desc = reader["MetSet_Desc"].ToString(),
                MetSet_From = reader["MetSet_From"].ToString(),
                MetSet_To = reader["MetSet_To"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                MetSet_Status = reader["MetSet_Status"].ToString(),
            };
        }
        public int Add(MetricSetting model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MetricSetting_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@MetSet_Cod", model.MetSet_Cod));
                cmd.Parameters.Add(new SqlParameter("@MetSet_Value", model.MetSet_Value));
                cmd.Parameters.Add(new SqlParameter("@MetSet_Desc", model.MetSet_Desc));
                cmd.Parameters.Add(new SqlParameter("@MetSet_From", model.MetSet_From));
                cmd.Parameters.Add(new SqlParameter("@MetSet_To", model.MetSet_To));
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
        public int Update(MetricSetting model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MetricSetting_Update";
                cmd.Parameters.Add(new SqlParameter("@MetSet_ID", model.MetSet_ID));
                //cmd.Parameters.Add(new SqlParameter("@MetSet_Cod", model.MetSet_Cod));
                cmd.Parameters.Add(new SqlParameter("@MetSet_Value ", model.MetSet_Value));
                cmd.Parameters.Add(new SqlParameter("@MetSet_Desc ", model.MetSet_Desc));
                cmd.Parameters.Add(new SqlParameter("@MetSet_From ", model.MetSet_From));
                cmd.Parameters.Add(new SqlParameter("@MetSet_To ", model.MetSet_To));
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
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MetricSetting_Delete";
                cmd.Parameters.Add(new SqlParameter("@MetSet_ID", obj["id"].ToObject<int>()));
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
        public async Task<List<MetricSetting>> Search(JObject obj)
        {
            var response = new List<MetricSetting>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MetricSetting_Search";

                cmd.Parameters.Add(new SqlParameter("@MetSet_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMetricSetting(reader));
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
