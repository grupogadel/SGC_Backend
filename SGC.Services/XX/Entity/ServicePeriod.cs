
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

        private Period MapToPeriodAll(SqlDataReader reader)
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
                Period_Status = reader["Period_Status"].ToString()
               
            };
        }

        public async Task<int> AddAllPeriods(JObject obj)
        {
            try
            {
                List<MPeriod> mPeriods = new List<MPeriod>();
                Period period = new Period();
                var confirmationAdd = -1;
                    
                mPeriods = await this.GetAllPeriods();
                
                foreach (MPeriod mPeriod in mPeriods)
                {
                    period.Period_Cod = mPeriod.MPeriod_Cod;
                    period.Company_ID = obj["company_ID"].ToObject<int>();
                    period.Period_Year = obj["year"].ToObject<string>();
                    period.Period_Date_Start = new DateTime(obj["year"].ToObject<int>(), Convert.ToInt32(mPeriod.MPeriod_Month), 1);
                    period.Period_Date_End = period.Period_Date_Start.AddMonths(1).AddDays(-1);
                    period.Creation_User = obj["creation_User"].ToObject<string>();
                    confirmationAdd =  this.Add(period);
                    if (confirmationAdd == -1) break;
                }
                return confirmationAdd;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }

        }

        public int Add(Period model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Period_Add";
                cmd.Parameters.Add(new SqlParameter("@Period_Cod", model.Period_Cod));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_Year", model.Period_Year));
                cmd.Parameters.Add(new SqlParameter("@Period_Date_Start", model.Period_Date_Start));
                cmd.Parameters.Add(new SqlParameter("@Period_Date_End", model.Period_Date_End));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));

                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

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
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_Year", model.Period_Year));
                cmd.Parameters.Add(new SqlParameter("@Period_Date_Start", model.Period_Date_Start));
                cmd.Parameters.Add(new SqlParameter("@Period_Date_End", model.Period_Date_End));
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
                cmd.CommandText = "[XX].Period_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@Period_ID", obj["id"].ToObject<int>()));
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

        public async Task<List<Period>> Search(JObject obj)
        {
            var response = new List<Period>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Period_Search";

                cmd.Parameters.Add(new SqlParameter("@Period_Year", obj["year"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<string>()));

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
                return response;// 
                throw e;
            }
        }

        public async Task<List<Period>> SearchAll(JObject obj)
        {
            var response = new List<Period>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Period_SearchAll";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPeriodAll(reader));
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

        public async Task<List<MPeriod>> GetAllPeriods()
        {
            var response = new List<MPeriod>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MPeriod_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMPeriod(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return new List<MPeriod>();
                throw e;
            }
        }

        private MPeriod MapToMPeriod(SqlDataReader reader)
        {
            return new MPeriod()
            {
                MPeriod_ID = (int)reader["MPeriod_ID"],
                MPeriod_Cod = reader["MPeriod_Cod"].ToString(),
                MPeriod_Name = reader["MPeriod_Name"].ToString(),
                MPeriod_Name2 = reader["MPeriod_Name2"].ToString(),
                MPeriod_Desc = reader["MPeriod_Desc"].ToString(),
                MPeriod_Month = reader["MPeriod_Month"].ToString(),
                MPeriod_Status = reader["MPeriod_Status"].ToString(),
            };
        }


    }

}
