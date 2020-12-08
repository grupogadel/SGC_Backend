using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;
using SGC.Entities.Entities.CM.CollectorControl;
using SGC.InterfaceServices.CM.CollectorControl;

namespace SGC.Services.CM.CollectorControl
{
    public class ServiceExpHead : IServiceExpHead
    {
        private readonly string _context;

        public ServiceExpHead(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }


        private ExpHead MapToExpHead(SqlDataReader reader)
        {
            return new ExpHead()
            {
                ExpH_ID = (int)reader["ExpH_ID"],
                Company_ID = (int)reader["Company_ID"],
                Zone_ID = (int)reader["Zone_ID"],
                Period_ID = (int)reader["Period_ID"],
                ExpH_Cod = reader["ExpH_Cod"].ToString(),
                Collec_ID = (int)reader["Collec_ID"],
                Currency_ID = (int)reader["Currency_ID"],
                ExpH_Desc = reader["ExpH_Desc"].ToString(),
                ExpH_DaysRender = (int)reader["ExpH_DaysRender"],
                ExpH_TotAmount = (decimal)reader["ExpH_TotAmount"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                ExpH_Status = reader["ExpH_Status"].ToString(),

                Period = new Period
                {
                    Period_ID = (int)reader["Period_ID"],
                    Period_Cod = reader["Period_Cod"].ToString(),
                    Period_NO = reader["Period_NO"].ToString(),
                    Period_Year = reader["Period_Year"].ToString(),
                    Period_Date_Start = (DateTime)reader["Period_Date_Start"],
                    Period_Date_End = (DateTime)reader["Period_Date_End"],
                },
                Collector = new Collector
                {
                    Collec_ID = (int)reader["Collec_ID"],
                    Collec_TaxID = reader["Collec_TaxID"].ToString(),
                    Collec_Name = reader["Collec_Name"].ToString(),
                    Collec_LastName = reader["Collec_LastName"].ToString()
                },
                Zone = new Zone
                {
                    Zone_ID = (int)reader["Zone_ID"],
                    Zone_Cod = reader["Zone_Cod"].ToString(),
                    Zone_Name = reader["Zone_Name"].ToString(),
                    Zone_Desc = reader["Zone_Desc"].ToString(),
                },
                Currency = new Currency
                { 
                    Currency_ID = (int)reader["Currency_ID"],
                    Currency_Cod = reader["Currency_Cod"].ToString(),
                    Currency_Name = reader["Currency_Name"].ToString(),
                }
            };
        }

        // POST: api/ExpHead/Add
        public int Add(ExpHead model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpHead_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", model.Period_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID", model.Currency_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@ExpH_Desc", model.ExpH_Desc));
                cmd.Parameters.Add(new SqlParameter("@ExpH_DaysRender", model.ExpH_DaysRender));
                cmd.Parameters.Add(new SqlParameter("@ExpH_TotAmount", model.ExpH_TotAmount));
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

        // PUT: api/ExpHead/Update/1
        public int Update(ExpHead model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpHead_Update";
                cmd.Parameters.Add(new SqlParameter("@ExpHead_ID", model.ExpH_ID));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID", model.Currency_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@ExpH_Desc", model.ExpH_Desc));
                cmd.Parameters.Add(new SqlParameter("@ExpH_DaysRender", model.ExpH_DaysRender));
                cmd.Parameters.Add(new SqlParameter("@ExpH_TotAmount", model.ExpH_TotAmount));
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

        // DELETE: api/ExpHead/Delete/1
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpHead_Delete";
                cmd.Parameters.Add(new SqlParameter("@ExpHead_ID", obj["id"].ToObject<int>()));
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

        // GET api/ExpHead/Get/1
        public ExpHead Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpHead_Get";
                cmd.Parameters.Add(new SqlParameter("@ExpH_ID", id));

                ExpHead response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToExpHead(reader);
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

        public async Task<List<ExpHead>> Search(JObject obj)
        {
            var response = new List<ExpHead>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpHead_Search";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@ExpH_Cod", obj["expH_Cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["collec_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", obj["period_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToExpHead(reader));
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
