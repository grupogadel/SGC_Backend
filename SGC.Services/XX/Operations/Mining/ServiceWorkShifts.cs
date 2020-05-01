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
    public class ServiceWorkShifts : IServiceWorkShifts
    {
        private readonly string _context;

        public ServiceWorkShifts(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public async Task<List<WorkShifts>> GetAll(int id)
        {
            var response = new List<WorkShifts>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].WorkShifts_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", id));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToWorkShifts(reader));
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
        private WorkShifts MapToWorkShifts(SqlDataReader reader)
        {
            return new WorkShifts()
            {
                WrkShi_ID = (int)reader["WrkShi_ID"],
                Company_ID = (int)reader["Company_ID"],
                WrkShi_Cod = reader["WrkShi_Cod"].ToString(),
                WrkShi_Desc = reader["WrkShi_Desc"].ToString(),
                WrkShi_TimeStar = (DateTime)reader["WrkShi_TimeStar"],
                WrkShi_TimeEnd = (DateTime)reader["WrkShi_TimeEnd"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                WrkShi_Status = reader["WrkShi_Status"].ToString(),
            };
        }
        public int Add(WorkShifts model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].WorkShifts_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_Cod", model.WrkShi_Cod));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_Desc", model.WrkShi_Desc));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_TimeStar", model.WrkShi_TimeStar));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_TimeEnd", model.WrkShi_TimeEnd));
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

        public int Update(WorkShifts model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].WorkShifts_Update";
                cmd.Parameters.Add(new SqlParameter("@WrkShi_ID", model.WrkShi_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_Cod", model.WrkShi_Cod));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_Desc", model.WrkShi_Desc));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_TimeStar", model.WrkShi_TimeStar));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_TimeEnd", model.WrkShi_TimeEnd));
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
                cmd.CommandText = "[XX].WorkShifts_Delete";
                cmd.Parameters.Add(new SqlParameter("@WrkShi_ID", obj["id"].ToObject<int>()));
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

        public WorkShifts Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].WorkShifts_Get";
                cmd.Parameters.Add(new SqlParameter("@WrkShi_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                WorkShifts response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToWorkShifts(reader);
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
        public WorkShifts GetCod(string Cod)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].WorkShifts_GetCod";
                cmd.Parameters.Add(new SqlParameter("@WrkShi_Cod", Cod));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                WorkShifts response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToWorkShifts(reader);
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

        public async Task<List<WorkShifts>> Search(JObject obj)
        {
            var response = new List<WorkShifts>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].WorkShifts_Search";

                cmd.Parameters.Add(new SqlParameter("@WrkShi_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToWorkShifts(reader));
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
