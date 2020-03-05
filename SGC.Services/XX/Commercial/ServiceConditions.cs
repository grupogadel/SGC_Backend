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
    //1: Zone 2: Origin 3: Vendor
    public class ServiceConditions : IServiceConditions
    {
        private readonly string _context;

        public ServiceConditions(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Conditions/GetAllByZones/1
        public async Task<List<Conditions>> GetAllByZones(int idCompany)
        {
            var response = new List<Conditions>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_GetAllByZones";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToConditions(reader,1));
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

        // POST: api/Conditions/AddByZones
        public int AddByZones(Conditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_AddByZones";
                //Head
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_Humi_Sec", model.Cond_Humi_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                SqlParameter parMaquilasCommercials = ServiceMaquilaCommercial.GetMaquilaCommercial("tabMaquilaCommercial", model.MaquilasCommercials);
                cmd.Parameters.Add(parMaquilasCommercials);
                //Output
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

        private Conditions MapToConditions(SqlDataReader reader, int opc)
        {
            return new Conditions()
            {
                Cond_ID = (int)reader["Cond_ID"],
                VendorOrig_ID = (int)reader["VendorOrig_ID"],
                VendorOrig_VendorFullName = opc == 3 ? ((string)reader["Vendor_Name"]+ " "+(string)reader["Vendor_LastName"]) : null,
                VendorOrig_OrigName = opc ==3 ? (string)reader["Orig_Name"] : null,
                Orig_ID = (int)reader["Orig_ID"],
                Orig_Name = opc == 2 ?(string)reader["Orig_Name"]: null,
                Zone_ID = (int)reader["Zone_ID"],
                Zone_Name = opc == 1 ? (string) reader["Zone_Name"]: null,
                Company_ID = (int)reader["Company_ID"],
                Cond_Cod = (string)reader["Cond_Cod"],
                Cond_Desc = (string) reader["Cond_Desc"],
                Cond_DateStart = (DateTime)reader["Cond_DateStart"],
                Cond_DateEnd = (DateTime)reader["Cond_DateEnd"],
                Cond_WeigPor_Sec = (decimal)reader["Cond_WeigPor_Sec"],
                Cond_LeyAuPor_Sec = (decimal)reader["Cond_LeyAuPor_Sec"],
                Cond_LeyAgPor_Sec = (decimal)reader["Cond_LeyAgPor_Sec"],
                Cond_Humi_Sec = (decimal)reader["Cond_Humi_Sec"],
                Cond_RecovAg_Sec = (decimal)reader["Cond_RecovAg_Sec"],
                Cond_ConsuAg_Sec = (decimal)reader["Cond_ConsuAg_Sec"],
                Cond_OzMinAg = (decimal)reader["Cond_OzMinAg"],
                Cond_MaquilaAg = (decimal)reader["Cond_MaquilaAg"],
                Cond_ExpLab = (decimal)reader["Cond_ExpLab"],
                Cond_ExpAdmin_Estim = (decimal)reader["Cond_ExpAdmin_Estim"],
                Cond_RecovAu_Estim = (decimal)reader["Cond_RecovAu_Estim"],
                Cond_MaquilaAu_Estim = (decimal)reader["Cond_MaquilaAu_Estim"],
                Cond_ConsuAu_Estim = (decimal)reader["Cond_ConsuAu_Estim"],
                Creation_User = (string)reader["Creation_User"],
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = (string)reader["Modified_User"],
                Modified_Date = (DateTime)reader["Modified_Date"],
                Cond_Status = (string)reader["Cond_Status"]
            };
        }

        // PUT: api/Conditions/UpdateByZones/1
        public int UpdateByZones(Conditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_UpdateByZones";

                cmd.Parameters.Add(new SqlParameter("@Cond_ID", model.Cond_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_Humi_Sec", model.Cond_Humi_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
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

        // GET: api/Conditions/GetAllByOrigins/1
        public async Task<List<Conditions>> GetAllByOrigins(int idCompany)
        {
            var response = new List<Conditions>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_GetAllByOrigins";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToConditions(reader,2));
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

        // POST: api/Conditions/AddByOrigins
        public int AddByOrigins(Conditions model)
        {
            //logger.InfoFormat("Servicio, Condicion por Rol:   PutRol(RolModel objRol=: <strDescripcion=:{0}, strUsuarioCrea=:{1}>)", objRol.strDescripcion, objRol.strUsuarioCrea);

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_AddByOrigins";

                //Head
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_Humi_Sec", model.Cond_Humi_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                SqlParameter parMaquilasCommercials = ServiceMaquilaCommercial.GetMaquilaCommercial("tabMaquilaCommercial", model.MaquilasCommercials);
                cmd.Parameters.Add(parMaquilasCommercials);
                //Output
                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                conn.Close();

                return resul;
            }
            catch (Exception e)
            {
                //logger.ErrorFormat("Servicio, Rol:  Error en el metodo PutRol(RolModel objRol=: <strDescripcion=:{0}, strUsuarioCrea=:{1}>)", objRol.strDescripcion, objRol.strUsuarioCrea);
                //logger.ErrorFormat("Exception - {0}", e);
                return -1;
                throw e;
            }
        }

        // PUT: api/Conditions/UpdateByOrigins/1
        public int UpdateByOrigins(Conditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_UpdateByOrigins";

                cmd.Parameters.Add(new SqlParameter("@Cond_ID", model.Cond_ID));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_Humi_Sec", model.Cond_Humi_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
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

        // GET: api/Conditions/GetAllByVendors/1
        public async Task<List<Conditions>> GetAllByVendors(int idCompany)
        {
            var response = new List<Conditions>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_GetAllByVendors";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToConditions(reader, 3));
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

        // POST: api/Conditions/AddByVendors
        public int AddByVendors(Conditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_AddByVendors";
                //Head
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@VendorOrig_ID", model.VendorOrig_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_Humi_Sec", model.Cond_Humi_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                SqlParameter parMaquilasCommercials = ServiceMaquilaCommercial.GetMaquilaCommercial("tabMaquilaCommercial", model.MaquilasCommercials);
                cmd.Parameters.Add(parMaquilasCommercials);
                //Output
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

        // PUT: api/Conditions/UpdateByVendors/1
        public int UpdateByVendors(Conditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Conditions_UpdateByVendors";

                cmd.Parameters.Add(new SqlParameter("@Cond_ID", model.Cond_ID));
                cmd.Parameters.Add(new SqlParameter("@VendorOrig_ID", model.VendorOrig_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_Humi_Sec", model.Cond_Humi_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
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

        /*
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
        }*/

    }
}
