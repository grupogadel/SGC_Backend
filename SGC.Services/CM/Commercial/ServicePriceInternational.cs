using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial;
using SGC.InterfaceServices.CM.Commercial;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.Commercial
{
    public class ServicePriceInternational : IServicePriceInternational
    {
        private readonly string _context;

        public ServicePriceInternational(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        private PriceInternational MapToPriceInternational(SqlDataReader reader)
        {
            return new PriceInternational()
            {
                Price_ID = (int)reader["Price_ID"],
                Price_DatePrice = (DateTime)reader["Price_DatePrice"],
                Price_GoldAM = (decimal)reader["Price_GoldAM"],
                Price_GoldPM = (decimal)reader["Price_GoldPM"],
                Price_Silver = (decimal)reader["Price_Silver"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Price_Status = reader["Price_Status"].ToString(),


            };
        }

        // POST: api/PriceInternational/Add
        public int Add(PriceInternational model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].PriceInternational_Add";
                cmd.Parameters.Add(new SqlParameter("@Price_DatePrice", model.Price_DatePrice));
                cmd.Parameters.Add(new SqlParameter("@Price_GoldAM", model.Price_GoldAM));
                cmd.Parameters.Add(new SqlParameter("@Price_GoldPM", model.Price_GoldPM));
                cmd.Parameters.Add(new SqlParameter("@Price_Silver", model.Price_Silver));
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

        // PUT: api/PriceInternational/Update/1
        public int Update(PriceInternational model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].PriceInternational_Update";
                cmd.Parameters.Add(new SqlParameter("@Price_ID", model.Price_ID));
                cmd.Parameters.Add(new SqlParameter("@Price_DatePrice", model.Price_DatePrice));
                cmd.Parameters.Add(new SqlParameter("@Price_GoldAM", model.Price_GoldAM));
                cmd.Parameters.Add(new SqlParameter("@Price_GoldPM", model.Price_GoldPM));
                cmd.Parameters.Add(new SqlParameter("@Price_Silver", model.Price_Silver));
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

        // DELETE: api/PriceInternational/Delete/1
        public int ChangeStatus(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].PriceInternational_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@Price_ID", obj["id"].ToObject<int>()));
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

        // GET api/PriceInternational/Get/1
        public PriceInternational Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].PriceInternational_Get";
                cmd.Parameters.Add(new SqlParameter("@Price_ID", id));

                PriceInternational response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToPriceInternational(reader);
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

        public async Task<List<PriceInternational>> Search(JObject obj)
        {
            var response = new List<PriceInternational>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].PriceInternational_Search";
                DateTime fecha = new DateTime();
                bool byMonth = false;
                if (obj["date"].ToObject<string>() != "") fecha = obj["date"].ToObject<DateTime>();
                else { byMonth = true; fecha = DateTime.Now; }

                cmd.Parameters.Add(new SqlParameter("@Fecha", fecha));
                cmd.Parameters.Add(new SqlParameter("@ByMonth", byMonth));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPriceInternational(reader));
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
