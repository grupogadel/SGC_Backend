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
    public class ServiceToPayCollector : IServiceToPayCollector
    {
        private readonly string _context;

        public ServiceToPayCollector(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/ToPayCollector/GetAll
        public async Task<List<ToPayCollector>> Search(JObject obj)
        {
            var response = new List<ToPayCollector>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ToPayCollector_Search";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@TPayColl_NO", obj["tPayColl_NO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["collec_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", obj["period_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToToPayCollector(reader));
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

        private ToPayCollector MapToToPayCollector(SqlDataReader reader)
        {
            return new ToPayCollector()
            {
                TPayColl_ID = (int)reader["TPayColl_ID"],
                Company_ID = (int)reader["Company_ID"],
                TPayColl_NO = reader["TPayColl_NO"].ToString(),
                Collec_ID = (int)reader["Collec_ID"],
                Zone_ID = (int)reader["Zone_ID"],
                Period_ID = (int)reader["Period_ID"],
                Currency_ID = (int)reader["Currency_ID"],
                TPayColl_ProcDate = (DateTime)reader["TPayColl_ProcDate"],
                TPayColl_Days = reader["TPayColl_Days"].ToString(),
                TPayColl_Desc = reader["TPayColl_Desc"].ToString(),
                TPayColl_Amount = (decimal)reader["TPayColl_Amount"],
                TPayColl_AmountPaid = reader["TPayColl_AmountPaid"] == DBNull.Value ? new decimal?() : (decimal)reader["TPayColl_AmountPaid"],
                Date_Approved = reader["Date_Approved"] == DBNull.Value ? new DateTime?() : (DateTime)reader["Date_Approved"],
                User_Approved = reader["User_Approved"].ToString(),
                //User_Approved = reader["User_Approved"] == DBNull.Value ? new string?() : (string)reader["User_Approved"],
                TPayColl_StatusProc = reader["TPayColl_StatusProc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                TPayColl_Status = reader["TPayColl_Status"].ToString(),

                Period = new Period
                {
                    Period_Cod = reader["Period_Cod"].ToString(),
                    Period_NO = reader["Period_NO"].ToString()
                },
                Collector = new Collector
                {
                    Collec_TaxID = reader["Person_DNI"].ToString(),
                    Collec_Name = reader["Person_Name"].ToString(),
                    Collec_LastName = reader["Person_LastName"].ToString()
                },
                Currency = new Currency
                {
                    Currency_Cod = reader["Currency_Cod"].ToString(),
                    Currency_Name = reader["Currency_Name"].ToString(),
                },
                Zone = new Zone
                {
                    Zone_Cod = reader["Zone_Cod"].ToString(),
                    Zone_Name = reader["Zone_Name"].ToString(),
                },
            };
        }

        // POST: api/ToPayCollector/Add
        public async Task<int> Add(ToPayCollector model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ToPayCollector_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", model.Period_ID));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID", model.Currency_ID));
                cmd.Parameters.Add(new SqlParameter("@TPayColl_Days", model.TPayColl_Days));
                cmd.Parameters.Add(new SqlParameter("@TPayColl_ProcDate", model.TPayColl_ProcDate));
                cmd.Parameters.Add(new SqlParameter("@TPayColl_Desc", model.TPayColl_Desc));
                cmd.Parameters.Add(new SqlParameter("@TPayColl_Amount", model.TPayColl_Amount));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                await conn.OpenAsync();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                await conn.CloseAsync();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }

        }

        // PUT: api/ToPayCollector/Update/1
        public async Task<int> Update(ToPayCollector model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ToPayCollector_Update";
                cmd.Parameters.Add(new SqlParameter("@TPayColl_ID", model.TPayColl_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", model.Period_ID));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID", model.Currency_ID));
                cmd.Parameters.Add(new SqlParameter("@TPayColl_Days", model.TPayColl_Days));
                cmd.Parameters.Add(new SqlParameter("@TPayColl_ProcDate", model.TPayColl_ProcDate));
                cmd.Parameters.Add(new SqlParameter("@TPayColl_Desc", model.TPayColl_Desc));
                cmd.Parameters.Add(new SqlParameter("@TPayColl_Amount", model.TPayColl_Amount));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));
                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                await conn.OpenAsync();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                await conn.CloseAsync();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }

        // DELETE: api/ToPayCollector/Delete/1
        public async Task<int> ChangeStatus(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ToPayCollector_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@TPayColl_ID", obj["tPayColl_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["modified_User"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Action", obj["action"].ToObject<string>()));

                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                await conn.OpenAsync();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                await conn.CloseAsync();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }

        public async Task<ToPayCollector> Get(int id)
        {
            var response = new ToPayCollector();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[ToPayCollector_Get]";
                cmd.Parameters.Add(new SqlParameter("@TPayColl_ID", id));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToToPayCollector(reader);
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