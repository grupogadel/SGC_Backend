using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.CommercialCondition;
using SGC.InterfaceServices.CM.Commercial.CommercialCondition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.CM.Commercial.CommercialCondition
{
    //1: Zone 2: Origin 3: Vendor
    public class ServiceCommercialConditions : IServiceCommercialConditions
    {
        private readonly string _context;

        public ServiceCommercialConditions(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/CommercialConditions/GetAllByZones/1
        public async Task<List<CommercialConditions>> GetAllByZones(int idCompany)
        {
            var response = new List<CommercialConditions>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_GetAllByZones";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCommercialConditions(reader,1));
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

        // POST: api/CommercialConditions/AddByZones
        public int AddByZones(CommercialConditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_AddByZones";
                //Head
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
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
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Sec", model.Cond_MarginPIAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPI_Estim", model.Cond_MarginPI_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg_Estim", model.Cond_MaquilaAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Estim", model.Cond_RecovAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Estim", model.Cond_MarginPIAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Estim", model.Cond_ConsuAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                SqlParameter parMaquilasCommercials = GetMaquilaCommercial("tabMaquilaCommercial", model.MaquilasCommercials);
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

        private CommercialConditions MapToCommercialConditions(SqlDataReader reader, int opc)
        {

            return new CommercialConditions()
            {
                Cond_ID = (int)reader["Cond_ID"],
                Vendor_ID = (int)reader["Vendor_ID"],
                Vendor_FullName = opc == 3 ? (reader["Vendor_CatPers"].ToString().Equals("01"))? ((string)reader["Vendor_Name"]+ " "+(string)reader["Vendor_LastName"]) : (string)reader["Vendor_Desc"]: null,
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
                Cond_MarginPIAg_Sec = (decimal)reader["Cond_MarginPIAg_Sec"],
                Cond_OzMinAg = (decimal)reader["Cond_OzMinAg"],
                Cond_MaquilaAg = (decimal)reader["Cond_MaquilaAg"],
                Cond_ExpLab = (decimal)reader["Cond_ExpLab"],
                Cond_ExpAdmin_Estim = (decimal)reader["Cond_ExpAdmin_Estim"],
                Cond_RecovAu_Estim = (decimal)reader["Cond_RecovAu_Estim"],
                Cond_MaquilaAu_Estim = (decimal)reader["Cond_MaquilaAu_Estim"],
                Cond_MarginPI_Estim = (decimal)reader["Cond_MarginPI_Estim"],
                Cond_ConsuAu_Estim = (decimal)reader["Cond_ConsuAu_Estim"],
                Cond_MaquilaAg_Estim = (decimal)reader["Cond_MaquilaAg_Estim"],
                Cond_RecovAg_Estim = (decimal)reader["Cond_RecovAg_Estim"],
                Cond_MarginPIAg_Estim = (decimal)reader["Cond_MarginPIAg_Estim"],
                Cond_ConsuAg_Estim = (decimal)reader["Cond_ConsuAg_Estim"],
                Creation_User = (string)reader["Creation_User"],
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = (string)reader["Modified_User"],
                Modified_Date = (DateTime)reader["Modified_Date"],
                Cond_Status = (string)reader["Cond_Status"]
            };
        }

        // PUT: api/CommercialConditions/UpdateByZones/1
        public int UpdateByZones(CommercialConditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_UpdateByZones";

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
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Sec", model.Cond_MarginPIAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPI_Estim", model.Cond_MarginPI_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg_Estim", model.Cond_MaquilaAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Estim", model.Cond_RecovAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Estim", model.Cond_MarginPIAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Estim", model.Cond_ConsuAg_Estim));
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

        // DELETE: api/CommercialConditions/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_Delete";
                cmd.Parameters.Add(new SqlParameter("@Cond_ID", obj["id"].ToObject<int>()));
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

        // GET: api/CommercialConditions/GetAllByOrigins/1
        public async Task<List<CommercialConditions>> GetAllByOrigins(int idCompany)
        {
            var response = new List<CommercialConditions>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_GetAllByOrigins";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCommercialConditions(reader,2));
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

        // POST: api/CommercialConditions/AddByOrigins
        public int AddByOrigins(CommercialConditions model)
        {
            //logger.InfoFormat("Servicio, Condicion por Rol:   PutRol(RolModel objRol=: <strDescripcion=:{0}, strUsuarioCrea=:{1}>)", objRol.strDescripcion, objRol.strUsuarioCrea);

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_AddByOrigins";

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
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Sec", model.Cond_MarginPIAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPI_Estim", model.Cond_MarginPI_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg_Estim", model.Cond_MaquilaAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Estim", model.Cond_RecovAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Estim", model.Cond_MarginPIAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Estim", model.Cond_ConsuAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                SqlParameter parMaquilasCommercials = GetMaquilaCommercial("tabMaquilaCommercial", model.MaquilasCommercials);
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

        // PUT: api/CommercialConditions/UpdateByOrigins/1
        public int UpdateByOrigins(CommercialConditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_UpdateByOrigins";

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
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Sec", model.Cond_MarginPIAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPI_Estim", model.Cond_MarginPI_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg_Estim", model.Cond_MaquilaAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Estim", model.Cond_RecovAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Estim", model.Cond_MarginPIAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Estim", model.Cond_ConsuAg_Estim));
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

        // GET: api/CommercialConditions/GetAllByVendors/1
        public async Task<List<CommercialConditions>> GetAllByVendors(int idCompany)
        {
            var response = new List<CommercialConditions>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_GetAllByVendors";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCommercialConditions(reader, 3));
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

        // POST: api/CommercialConditions/AddByVendors
        public int AddByVendors(CommercialConditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_AddByVendors";
                //Head
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", model.Vendor_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_Humi_Sec", model.Cond_Humi_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Sec", model.Cond_MarginPIAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPI_Estim", model.Cond_MarginPI_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg_Estim", model.Cond_MaquilaAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Estim", model.Cond_RecovAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Estim", model.Cond_MarginPIAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Estim", model.Cond_ConsuAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                SqlParameter parMaquilasCommercials = GetMaquilaCommercial("tabMaquilaCommercial", model.MaquilasCommercials);
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

        // PUT: api/CommercialConditions/UpdateByVendors/1
        public int UpdateByVendors(CommercialConditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_UpdateByVendors";

                cmd.Parameters.Add(new SqlParameter("@Cond_ID", model.Cond_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", model.Vendor_ID));
                cmd.Parameters.Add(new SqlParameter("@Cond_Desc", model.Cond_Desc));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateStart", model.Cond_DateStart));
                cmd.Parameters.Add(new SqlParameter("@Cond_DateEnd", model.Cond_DateEnd));
                cmd.Parameters.Add(new SqlParameter("@Cond_WeigPor_Sec", model.Cond_WeigPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAuPor_Sec", model.Cond_LeyAuPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_LeyAgPor_Sec", model.Cond_LeyAgPor_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_Humi_Sec", model.Cond_Humi_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Sec", model.Cond_RecovAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Sec", model.Cond_ConsuAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Sec", model.Cond_MarginPIAg_Sec));
                cmd.Parameters.Add(new SqlParameter("@Cond_OzMinAg", model.Cond_OzMinAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg", model.Cond_MaquilaAg));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpLab", model.Cond_ExpLab));
                cmd.Parameters.Add(new SqlParameter("@Cond_ExpAdmin_Estim", model.Cond_ExpAdmin_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAu_Estim", model.Cond_RecovAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAu_Estim", model.Cond_MaquilaAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPI_Estim", model.Cond_MarginPI_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAu_Estim", model.Cond_ConsuAu_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MaquilaAg_Estim", model.Cond_MaquilaAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_RecovAg_Estim", model.Cond_RecovAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_MarginPIAg_Estim", model.Cond_MarginPIAg_Estim));
                cmd.Parameters.Add(new SqlParameter("@Cond_ConsuAg_Estim", model.Cond_ConsuAg_Estim));
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

        // PUT: api/CommercialConditions/UpdateByMaquilas/
        public int UpdateByMaquilas(CommercialConditions model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialConditions_UpdateByMaquilas";
                //Head
                cmd.Parameters.Add(new SqlParameter("@Cond_ID", model.Cond_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@CreaModi_User", model.Modified_User));
                //Detail
                SqlParameter parMaquilasCommercials = GetMaquilaCommercial("tabMaquilaCommercial", model.MaquilasCommercials);
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
		
	    public SqlParameter GetMaquilaCommercial(string name, List<MaquilaCommercial> listMaquilaCommercial)
        {
            //logger.InfoFormat("Servicio, Rol:   GetAccesos(string name=:{0}, List<AccesoModel> lstListaAcc)", name);

            try
            {
                DataTable table = new DataTable("dbo.tabMaquilaCommercial");
                table.Columns.Add("MaqComm_ID", typeof(int));
                table.Columns.Add("MaqComm_LeyFrom", typeof(decimal));
                table.Columns.Add("MaqComm_LeyTo", typeof(decimal));
                table.Columns.Add("MaqComm_Maquila", typeof(decimal));
                table.Columns.Add("MaqComm_Recov", typeof(decimal));
                table.Columns.Add("MaqComm_MarginPI", typeof(decimal));
                table.Columns.Add("MaqComm_Consu", typeof(decimal));
                table.Columns.Add("MaqComm_ExpAdm", typeof(decimal));
                table.Columns.Add("MaqComm_Status", typeof(string));

                foreach (MaquilaCommercial maqCom in listMaquilaCommercial)
                    table.Rows.Add(new object[] { maqCom.MaqComm_ID,
                                                  maqCom.MaqComm_LeyFrom,
                                                  maqCom.MaqComm_LeyTo,
                                                  maqCom.MaqComm_Maquila,
                                                  maqCom.MaqComm_Recov,
                                                  maqCom.MaqComm_MarginPI,
                                                  maqCom.MaqComm_Consu,
                                                  maqCom.MaqComm_ExpAdm,
                                                  maqCom.MaqComm_Status
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.tabMaquilaCommercial";

                return parameter;
            }
            catch (Exception e)
            {
                //logger.ErrorFormat("Servicio, Rol:  Error en el metodo GetAccesos(string name=:{0}, List<AccesoModel> lstListaAcc)", name);
                //logger.ErrorFormat("Exception - {0}", e);
                return null;
                throw e;
            }
        }


        public async Task<CommercialConditions> LiquidationCommercialConditionsSearch(JObject obj)
        {
            var response = new CommercialConditions();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Liquidation_CommercialConditionsSearch";
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["vendor_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", obj["orig_ID"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", obj["zone_ID"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToCommercialConditionsLiquidation(reader);
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
        private CommercialConditions MapToCommercialConditionsLiquidation(SqlDataReader reader)
        {
            return new CommercialConditions()
            {
                Cond_ID = (int)reader["Cond_ID"],
                Vendor_ID = (int)reader["Vendor_ID"],
                Orig_ID = (int)reader["Orig_ID"],
                Zone_ID = (int)reader["Zone_ID"],
                Company_ID = (int)reader["Company_ID"],
                Cond_Cod = (string)reader["Cond_Cod"],
                Cond_Desc = (string)reader["Cond_Desc"],
                Cond_DateStart = (DateTime)reader["Cond_DateStart"],
                Cond_DateEnd = (DateTime)reader["Cond_DateEnd"],
                Cond_WeigPor_Sec = (decimal)reader["Cond_WeigPor_Sec"],
                Cond_LeyAuPor_Sec = (decimal)reader["Cond_LeyAuPor_Sec"],
                Cond_LeyAgPor_Sec = (decimal)reader["Cond_LeyAgPor_Sec"],
                Cond_Humi_Sec = (decimal)reader["Cond_Humi_Sec"],
                Cond_RecovAg_Sec = (decimal)reader["Cond_RecovAg_Sec"],
                Cond_ConsuAg_Sec = (decimal)reader["Cond_ConsuAg_Sec"],
                Cond_MarginPIAg_Sec = (decimal)reader["Cond_MarginPIAg_Sec"],
                Cond_OzMinAg = (decimal)reader["Cond_OzMinAg"],
                Cond_MaquilaAg = (decimal)reader["Cond_MaquilaAg"],
                Cond_ExpLab = (decimal)reader["Cond_ExpLab"],
                Cond_ExpAdmin_Estim = (decimal)reader["Cond_ExpAdmin_Estim"],
                Cond_RecovAu_Estim = (decimal)reader["Cond_RecovAu_Estim"],
                Cond_MaquilaAu_Estim = (decimal)reader["Cond_MaquilaAu_Estim"],
                Cond_MarginPI_Estim = (decimal)reader["Cond_MarginPI_Estim"],
                Cond_ConsuAu_Estim = (decimal)reader["Cond_ConsuAu_Estim"],
                Cond_MaquilaAg_Estim = (decimal)reader["Cond_MaquilaAg_Estim"],
                Cond_RecovAg_Estim = (decimal)reader["Cond_RecovAg_Estim"],
                Cond_MarginPIAg_Estim = (decimal)reader["Cond_MarginPIAg_Estim"],
                Cond_ConsuAg_Estim = (decimal)reader["Cond_ConsuAg_Estim"],
                Creation_User = (string)reader["Creation_User"],
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = (string)reader["Modified_User"],
                Modified_Date = (DateTime)reader["Modified_Date"],
                Cond_Status = (string)reader["Cond_Status"]
            };
        }

    }
}
