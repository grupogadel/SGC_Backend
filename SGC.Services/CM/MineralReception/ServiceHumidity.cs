using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.CM.Laboratory;
using SGC.InterfaceServices.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.MineralReception
{
    public class ServiceHumidity : IServiceHumidity
    {
        private readonly string _context;

        public ServiceHumidity(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        private SampleHead MapToHumidity(SqlDataReader reader)
        {
            return new SampleHead()
            {
                SampH_ID = (int)reader["SampH_ID"],
                BatchMineral = new BatchMineral { BatchM_PorHumInt = (int)reader["BatchM_PorHumInt"], 
                            Scales = new Scales { Scales_ID = (int)reader["Scales_ID"], Scales_Lote = reader["Scales_Lote"].ToString(), Creation_User = reader["User_Recep"].ToString(), Creation_Date = (DateTime)reader["Date_Recep"] }
                },
                Humidity = new Humidity {
                    Hum_ID = (int)reader["Hum_ID"],
                    Company_ID = (int)reader["Company_ID"],
                    Hum_Cod = reader["Hum_Cod"].ToString(),
                    Hum_FirstWeig = (decimal)reader["Hum_FirstWeig"],
                    Hum_EndWeig = (decimal)reader["Hum_EndWeig"],
                    Hum_PorcH2O = (decimal)reader["Hum_PorcH2O"],
                    Creation_User = reader["Creation_User"].ToString(),
                    Creation_Date = (DateTime)reader["Creation_Date"],
                    Modified_User = reader["Modified_User"].ToString(),
                    Modified_Date = (DateTime)reader["Modified_Date"],
                    Hum_Status = reader["Hum_Status"].ToString(),
                }
            };
        }

        private SampleHead MapToNoHumidity(SqlDataReader reader)
        {
            return new SampleHead()
            {
                SampH_ID = (int)reader["SampH_ID"],
                BatchMineral = new BatchMineral
                {
                    BatchM_PorHumInt = (int)reader["BatchM_PorHumInt"],
                    Scales = new Scales { Scales_ID = (int)reader["Scales_ID"], Scales_Lote = reader["Scales_Lote"].ToString(), Creation_User = reader["User_Recep"].ToString(), Creation_Date = (DateTime)reader["Date_Recep"] }
                }
            };
        }

        // POST: api/Humidity/Add
        public int Add(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                Humidity humidity = new Humidity();
                humidity = obj["humidity"].ToObject<Humidity>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Humidity_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", humidity.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Hum_FirstWeig", humidity.Hum_FirstWeig));
                cmd.Parameters.Add(new SqlParameter("@Hum_EndWeig", humidity.Hum_EndWeig));
                cmd.Parameters.Add(new SqlParameter("@Hum_PorcH2O", humidity.Hum_PorcH2O));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", humidity.Creation_User));
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", obj["sampH_ID"].ToObject<int>()));

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

        // PUT: api/Humidity/Update/
        public int Update(Humidity model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Humidity_Update";
                cmd.Parameters.Add(new SqlParameter("@Hum_ID", model.Hum_ID));
                cmd.Parameters.Add(new SqlParameter("@Hum_FirstWeig", model.Hum_FirstWeig));
                cmd.Parameters.Add(new SqlParameter("@Hum_EndWeig", model.Hum_EndWeig));
                cmd.Parameters.Add(new SqlParameter("@Hum_PorcH2O", model.Hum_PorcH2O));
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

        // DELETE: api/Humidity/Delete/
        public int ChangeStatus(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Humidity_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@Hum_ID", obj["id"].ToObject<int>()));
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


        public async Task<List<SampleHead>> SampleNoHumidity(JObject obj)
        {
            var response = new List<SampleHead>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Sample_No_Humidity";
               
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToNoHumidity(reader));
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


        public async Task<List<SampleHead>> Search(JObject obj)
        {
            var response = new List<SampleHead>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Humidity_Search";
                DateTime fecha = new DateTime();
                bool byMonth = false;
                if (obj["date"].ToObject<string>() != "") fecha = obj["date"].ToObject<DateTime>();
                else { byMonth = true; fecha = DateTime.Now; }

                cmd.Parameters.Add(new SqlParameter("@Fecha", fecha));
                cmd.Parameters.Add(new SqlParameter("@ByMonth", byMonth));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Codigo", obj["codigo"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToHumidity(reader));
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
