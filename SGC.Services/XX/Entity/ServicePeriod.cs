
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.XX.Entity
{
    public class ServicePeriod : IServicePeriod
    {
        private readonly string _context;

        public ServicePeriod(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Period/GetAll
        public async Task<List<Period>> GetAll(int idCompany)
        {
            var response = new List<Period>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Period_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPeriod(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return new List<Period>();//[]
                throw e;
            }
        }

        private Period MapToPeriod(SqlDataReader reader)
        {
            return new Period()
            {
                Period_ID = (int)reader["Period_ID"],
                Period_Cod = reader["Period_Cod"].ToString(),
                Period_NO = reader["Period_NO"].ToString(),
                Company_ID = (int)reader["Company_ID"],
                Period_Year = reader["Period_Year"].ToString(),
                Period_Date_Start = (DateTime)reader["Period_Date_Start"],
                Period_Date_End = (DateTime)reader["Period_Date_End"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Period_Status = reader["Period_Status"].ToString(),

                MPeriod = new MPeriod { MPeriod_ID = (int)reader["MPeriod_ID"],
                    MPeriod_Name = reader["MPeriod_Name"].ToString(),
                    MPeriod_Name2 = reader["MPeriod_Name2"].ToString(),
                    MPeriod_Desc = reader["MPeriod_Desc"].ToString(),
                    MPeriod_Month = reader["MPeriod_Month"].ToString(),
                }
            };
        }

        // POST: api/Period/Add
        public int Add(Period model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Period_Add";
                cmd.Parameters.Add(new SqlParameter("@Period_Cod", model.Period_Cod));
                cmd.Parameters.Add(new SqlParameter("@Period_NO", model.Period_NO));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_Year", model.Period_Year));
                cmd.Parameters.Add(new SqlParameter("@Period_Date_Start", model.Period_Date_Start));
                cmd.Parameters.Add(new SqlParameter("@Period_Date_End", model.Period_Date_End));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                //var resul = (int)cmd.Parameters["@Resultado"].Value;
                conn.Close();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }

        }

        // PUT: api/Period/Update/1
        public int Update(Period model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Period_Update";
                cmd.Parameters.Add(new SqlParameter("@Period_ID", model.Period_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_Cod", model.Period_Cod));
                cmd.Parameters.Add(new SqlParameter("@Period_NO", model.Period_NO));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_Year", model.Period_Year));
                cmd.Parameters.Add(new SqlParameter("@Period_Date_Start", model.Period_Date_Start));
                cmd.Parameters.Add(new SqlParameter("@Period_Date_End", model.Period_Date_End));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));

                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                //var resul = (int)cmd.Parameters["@Resultado"].Value;
                conn.Close();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }

        // DELETE: api/Period/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Period_Delete";
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));
                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                
                conn.Close();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }

        // GET api/Period/Get/
        public Period Get(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Period_Get";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                Period response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToPeriod(reader);
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

    }

}
