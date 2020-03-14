using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Collect;
using SGC.InterfaceServices.CM.Collect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Services.CM.Collect
{
    public class ServiceQuota : IServiceQuota
    {
        private readonly string _context;

        public ServiceQuota(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Quota/GetAll
        public async Task<List<Quota>> GetAll(int idCompany)
        {
            var response = new List<Quota>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Quota_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToQuota(reader));
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

        private Quota MapToQuota(SqlDataReader reader)
        {
            return new Quota()
            {
                Quota_ID = (int)reader["Quota_ID"],
                Company_ID = (int)reader["Company_ID"],
                Period_ID = (int)reader["Period_ID"],
                Collec_ID = (int)reader["Collec_ID"],
                Zone_ID = (int)reader["Zone_ID"],
                UM_Cod = reader["UM_Cod"].ToString(),
                Quota_TM_Est = (decimal)reader["Quota_TM_Est"],
                Quota_LeyAver = (decimal)reader["Quota_LeyAver"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Quota_Status = reader["Quota_Status"].ToString(),

                Period = new Period
                {
                    Period_Cod = reader["Period_Cod"].ToString(),
                    Period_NO = reader["Period_NO"].ToString(),
                    Period_Year = reader["Period_Year"].ToString(),
                    Period_Date_Start = (DateTime)reader["Period_Date_Start"],
                    Period_Date_End = (DateTime)reader["Period_Date_End"],
                    MPeriod = new MPeriod {
                        MPeriod_Cod = reader["MPeriod_Cod"].ToString(),
                        MPeriod_Name = reader["MPeriod_Name"].ToString(),
                        MPeriod_Month = reader["MPeriod_Month"].ToString(),
                    }
                },
                Collector = new Collector
                {
                    Zone_ID = (int)reader["Zona_ID_Collector"],
                    Collec_Cod = reader["Collec_Cod"].ToString(),
                    Collec_TaxID = reader["Collec_TaxID"].ToString(),
                    Collec_Name = reader["Collec_Name"].ToString(),
                    Collec_LastName = reader["Collec_LastName"].ToString()
                },
                Zone = new Zone
                { 
                    Zone_Name = reader["Zone_Name"].ToString(),
                },
                UnitMeasuare = new UnitMeasuare
                { 
                    UM_Cod = reader["UM_Cod"].ToString(),
                }
            };
        }

        // POST: api/Quota/Add
        public int Add(Quota model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Quota_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", model.Period_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@UM_Cod", model.UM_Cod));
                cmd.Parameters.Add(new SqlParameter("@Quota_TM_Est", model.Quota_TM_Est));
                cmd.Parameters.Add(new SqlParameter("@Quota_LeyAver", model.Quota_LeyAver));
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

        // PUT: api/Quota/Update/1
        public int Update(Quota model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Quota_Update";
                cmd.Parameters.Add(new SqlParameter("@Quota_ID", model.Quota_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", model.Period_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@UM_Cod", model.UM_Cod));
                cmd.Parameters.Add(new SqlParameter("@Quota_TM_Est", model.Quota_TM_Est));
                cmd.Parameters.Add(new SqlParameter("@Quota_LeyAver", model.Quota_LeyAver));
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

        // DELETE: api/Quota/Delete/1
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Quota_Delete";
                cmd.Parameters.Add(new SqlParameter("@Quota_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));

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

        // GET api/Quota/Get/1
        public Quota Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Quota_Get";
                cmd.Parameters.Add(new SqlParameter("@Quota_ID", id));

                Quota response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToQuota(reader);
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

        public async Task<List<Quota>> Search(JObject obj)
        {
            var response = new List<Quota>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Quota_Search";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Period_Year", obj["year"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["idCollec"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", obj["idZone"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToQuota(reader));
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
