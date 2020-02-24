using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using SGC.InterfaceServices.XX.Commercial;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.XX.Commercial
{
    public class ServiceConditions : IServiceConditions
    {
        private readonly string _context;

        public ServiceConditions(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Conditions/GetAll
        public async Task<List<Conditions>> GetAll(int idCompany)
        {
            var response = new List<Conditions>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToConditions(reader));
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

        private Conditions MapToConditions(SqlDataReader reader)
        {
            return new Conditions()
            {
                Cond_ID = (int)reader["Cond_ID"],
                Company_ID = (int)reader["Company_ID"],
                Vendor_ID = (int)reader["Vendor_ID"],
                Orig_ID = (int)reader["Orig_ID"],
                Zone_ID = (int)reader["Zone_ID"],
                Cond_Cod = reader["Cond_Cod"].ToString(),
                Cond_Desc = reader["Cond_Desc"].ToString(),
                Cond_DateStart = (DateTime)reader["Cond_DateStart"],
                Cond_DateEnd = (DateTime)reader["Cond_DateEnd"],
                Cond_WeigPor_Sec = (decimal)reader["Cond_WeigPor_Sec"],
                Cond_LeyAuPor_Sec = (decimal)reader["Cond_LeyAuPor_Sec"],
                Cond_LeyAgPor_Sec = (decimal)reader["Cond_LeyAgPor_Sec"],
                Cond_HumiAu_Sec = (decimal)reader["Cond_HumiAu_Sec"],
                Cond_HumiAg_Sec = (decimal)reader["Cond_HumiAg_Sec"],
                Cond_RecovAu_Sec = (decimal)reader["Cond_RecovAu_Sec"],
                Cond_RecovAg_Sec = (decimal)reader["Cond_RecovAg_Sec"],
                Cond_ConsuAu_Sec = (decimal)reader["Cond_ConsuAu_Sec"],
                Cond_ConsuAg_Sec = (decimal)reader["Cond_ConsuAg_Sec"],
                Cond_MarginPI = (decimal)reader["Cond_MarginPI"],
                Cond_Maquila = (decimal)reader["Cond_Maquila"],
                Cond_ExpLab = (decimal)reader["Cond_ExpLab"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Cond_Status = reader["Cond_Status"].ToString()
            };
        }

        // POST: api/Conditions/Add
        public int Add(Conditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", model.Vendor_ID));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID ", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Cod", model.Cond_Cod));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_HumiAu_Sec", model.Cond_HumiAu_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_HumiAg_Sec", model.Cond_HumiAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Sec", model.Cond_RecovAu_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Sec", model.Cond_ConsuAu_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPI", model.Cond_MarginPI));
                cmd.Parameters.Add(new SqlParameter("@Cond_Maquila", model.Cond_Maquila));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));

                //cmd.Parameters.Add("@Resultado",System.Data.SqlDbType.Int).Direction=System.Data.ParameterDirection.ReturnValue;

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

        // PUT: api/Conditions/Update/1
        public int Update(Conditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_Update";

                cmd.Parameters.Add(new SqlParameter("@Cond_ID", model.Cond_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", model.Vendor_ID));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID ", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Cod", model.Cond_Cod));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_HumiAu_Sec", model.Cond_HumiAu_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_HumiAg_Sec", model.Cond_HumiAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Sec", model.Cond_RecovAu_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Sec", model.Cond_ConsuAu_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPI", model.Cond_MarginPI));
                cmd.Parameters.Add(new SqlParameter("@Cond_Maquila", model.Cond_Maquila));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

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

        // DELETE: api/Conditions/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_Delete";
                cmd.Parameters.Add(new SqlParameter("@Cond_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

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

        // GET api/Conditions/Get/1
        public Conditions Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_Get";
                cmd.Parameters.Add(new SqlParameter("@Cond_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                Conditions response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToConditions(reader);
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
