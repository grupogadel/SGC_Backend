using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.FI.DataMaster;
using SGC.InterfaceServices.FI.DataMaster;
using SGC.Entities.Entities.XX.Finance;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.FI.DataMaster
{
    public class ServiceExchangeRate : IServiceExchangeRate
    {
        private readonly string _context;

        public ServiceExchangeRate(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/ExchangeRate/GetAll
        public async Task<List<ExchangeRate>> GetAll()
        {
            var response = new List<ExchangeRate>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[FI].ExchangeRate_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToExchangeRate(reader));
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

        private ExchangeRate MapToExchangeRate(SqlDataReader reader)
        {
            return new ExchangeRate()
            {
                ExchRate_ID = (int)reader["ExchRate_ID"],
                ExchRate_Date = (DateTime)reader["ExchRate_Date"],
                ExchRate_From_Cod = reader["ExchRate_From_Cod"].ToString(),
                ExchRate_To_Cod = reader["ExchRate_To_Cod"].ToString(),
                ExchRate_Buy = (decimal)reader["ExchRate_Buy"],
                ExchRate_Sale = (decimal)reader["ExchRate_Sale"],
                ExchRate_Agrem = (decimal)reader["ExchRate_Agrem"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                ExchRate_Status = reader["ExchRate_Status"].ToString(),

                Currency_From = new Currency { Currency_ID = (int)reader["Currency_From_ID"], Currency_Country = reader["Currency_From_Country"].ToString(), Currency_Cod = reader["Currency_From_Cod"].ToString(), Currency_Name = reader["Currency_From_Name"].ToString() },
                Currency_To = new Currency { Currency_ID = (int)reader["Currency_To_ID"], Currency_Country = reader["Currency_To_Country"].ToString(), Currency_Cod = reader["Currency_To_Cod"].ToString(), Currency_Name = reader["Currency_To_Name"].ToString() },


            };
        }

        // POST: api/ExchangeRate/Add
        public int Add(ExchangeRate model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[FI].ExchangeRate_Add";
                cmd.Parameters.Add(new SqlParameter("@ExchRate_Date", model.ExchRate_Date));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_From_Cod", model.ExchRate_From_Cod));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_To_Cod", model.ExchRate_To_Cod));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_Buy", model.ExchRate_Buy));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_Sale", model.ExchRate_Sale));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_Agrem", model.ExchRate_Agrem));
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

        // PUT: api/ExchangeRate/Update/1
        public int Update(ExchangeRate model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[FI].ExchangeRate_Update";
                cmd.Parameters.Add(new SqlParameter("@ExchRate_ID", model.ExchRate_ID));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_Date", model.ExchRate_Date));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_From_Cod", model.ExchRate_From_Cod));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_To_Cod", model.ExchRate_To_Cod));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_Buy", model.ExchRate_Buy));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_Sale", model.ExchRate_Sale));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_Agrem", model.ExchRate_Agrem));
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

        // DELETE: api/ExchangeRate/Delete/1
        public int ChangeStatus(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[FI].ExchangeRate_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@ExchRate_ID", obj["id"].ToObject<int>()));
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

        // GET api/ExchangeRate/Get/1
        public ExchangeRate Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[FI].ExchangeRate_Get";
                cmd.Parameters.Add(new SqlParameter("@ExchangeRate_ID", id));

                ExchangeRate response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToExchangeRate(reader);
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

        public async Task<List<ExchangeRate>> Search(JObject obj)
        {
            var response = new List<ExchangeRate>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[FI].ExchangeRate_Search";
                DateTime fecha = new DateTime();
                bool byMonth = false;
                if (obj["date"].ToObject<string>() != "") fecha = obj["date"].ToObject<DateTime>();
                else { byMonth = true; fecha = DateTime.Now; }

                cmd.Parameters.Add(new SqlParameter("@ExchRate_Date", fecha));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_From_Cod", obj["from"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@ExchRate_To_Cod", obj["to"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@ByMonth", byMonth));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToExchangeRate(reader));
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
