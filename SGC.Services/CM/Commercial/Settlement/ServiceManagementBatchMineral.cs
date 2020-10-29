using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Settlement;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.CM.DataMaster.Commercial;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.InterfaceServices.CM.Commercial.Settlement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.Commercial.Settlement
{
    public class ServiceManagementBatchMineral : IServiceManagementBatchMineral
    {
        private readonly string _context;

        public ServiceManagementBatchMineral(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int Delete(JObject obj)
        {
            throw new NotImplementedException();
        }

        // GET: api/ManagementBatchMineral/GetAll
        public async Task<List<ManagementBatchMineral>> GetAll(int idCompany)
        {
            var response = new List<ManagementBatchMineral>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ManagementBatchMineral_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToManagementBatchMineral(reader));
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

        public ManagementBatchMineral Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ManagementBatchMineral_Search";
                cmd.Parameters.Add(new SqlParameter("@BatchM_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                ManagementBatchMineral response = new ManagementBatchMineral();

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToManagementBatchMineral(reader);
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
        public ManagementSettlement GetS(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ManagementBatchMineral_Search";
                cmd.Parameters.Add(new SqlParameter("@BatchM_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                ManagementSettlement response = new ManagementSettlement();

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToManagementSettlement(reader);
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
        public List<ManagementBatchMineral> Search(JObject obj)
        {
            throw new NotImplementedException();
        }

        private ManagementBatchMineral MapToManagementBatchMineral(SqlDataReader reader)
        {
            return new ManagementBatchMineral()
            {
                BatchM_ID = (int)reader["BatchM_ID"],
                Scales_ID = (int)reader["Scales_ID"],
                Hum_ID = reader["Hum_ID"] == DBNull.Value ? 0 : (int)reader["Hum_ID"],
                //Ruma_ID = (int)reader["Ruma_ID"],
                //Quota_ID = (int)reader["Quota_ID"],
                //LeyMH_ID = (int)reader["LeyMH_ID"],
                Company_ID = (int)reader["Company_ID"],
                Period_ID = (int)reader["Period_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
                BatchM_SubLote = reader["BatchM_SubLote"].ToString(),
                //BatchM_Retired_Date = (DateTime)reader["BatchM_Retired_Date"],
                //BatchM_TMHInt = (int)reader["BatchM_TMHInt"],
                //BatchM_PorHumInt = (int)reader["BatchM_PorHumInt"],
                BatchM_TMSHist = reader["BatchM_TMSHist"] == DBNull.Value ? (decimal?)null : (decimal)reader["BatchM_TMSHist"],
                //BatchM_TMSInt = (int)reader["BatchM_TMSInt"],
                //BatchM_LeyInt = (int)reader["BatchM_LeyInt"],
                //BatchM_RecovInt = (int)reader["BatchM_RecovInt"],
                //BatchM_MaquilaInt = (int)reader["BatchM_MaquilaInt"],
                //BatchM_ConsumeInt = (int)reader["BatchM_ConsumeInt"],
                //BatchM_ExpAdmInt = (int)reader["BatchM_ExpAdmInt"],
                //BatchM_ExpLabInt = (int)reader["BatchM_ExpLabInt"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                BatchM_Status = reader["BatchM_Status"].ToString(),
                Scales = new Scales
                {
                    Scales_ID = (int)reader["Scales_ID"],
                    Scales_Lote = reader["Scales_Lote"].ToString(),
                    Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                    Scales_TMH = (decimal)reader["Scales_TMH"],
                    Origins = new Origin
                    {
                        Orig_ID = (int)reader["Orig_ID"],
                        Orig_Name = reader["Orig_Name"].ToString(),
                    },
                    Vendors = new Vendor
                    {
                        Vendor_ID = (int)reader["Vendor_ID"],
                        Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                    },
                    Collectors = new Collector
                    {
                        Collec_ID = (int)reader["Collec_ID"],
                        Collec_Name = reader["Collec_Name"].ToString(),
                    },
                },
                Humiditys = new Humidity
                {
                    Hum_ID = reader["Hum_ID"] == DBNull.Value ? 0 : (int)reader["Hum_ID"],
                    Hum_Cod = reader["Hum_Cod"] == DBNull.Value ? null : reader["Hum_Cod"].ToString(),
                    Hum_PorcH2O = reader["Hum_PorcH2O"] == DBNull.Value ? (decimal?)null : (decimal)reader["Hum_PorcH2O"],
                },
                //LeyMineralHeads = new LeyMineralHead
                //{
                //    LeyMH_ID = (int)reader["LeyMH_ID"],
                //    LeyMineralDetails = new LeyMineralDetail
                //    {
                //        LeyMD_ID = (int)reader["LeyMD_ID"],
                //        LeyMD_FinalAu = (decimal)reader["LeyMD_FinalAu"],
                //        LeyMD_FinalAg = (decimal)reader["LeyMD_FinalAg"],
                //    }
                //}
            };
        }

        private ManagementSettlement MapToManagementSettlement(SqlDataReader reader)
        {
            return new ManagementSettlement()
            {
                SampH_ID = (int)reader["SampH_ID"],
                BatchM_ID = (int)reader["BatchM_ID"],
                Scales_ID = (int)reader["Scales_ID"],
                Hum_ID = (int)reader["Hum_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
                //BatchM_TMHInt = (decimal)reader["BatchM_TMHInt"],
                BatchM_PorHumInt = (decimal)reader["BatchM_PorHumInt"],
                BatchM_TMSHist = (decimal)reader["BatchM_TMSHist"],
                //BatchM_TMSInt = (decimal)reader["BatchM_TMSInt"],
                //BatchM_LeyInt = (decimal)reader["BatchM_LeyInt"],
                BatchM_RecovInt = (decimal)reader["BatchM_RecovInt"],
                //BatchM_MaquilaInt = (decimal)reader["BatchM_MaquilaInt"],
                //BatchM_ConsumeInt = (decimal)reader["BatchM_ConsumeInt"],
                //BatchM_ExpAdmInt = (decimal)reader["BatchM_ExpAdmInt"],
                //BatchM_ExpLabInt = (decimal)reader["BatchM_ExpLabInt"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                BatchM_Status = reader["BatchM_Status"].ToString(),
                LeyMH_ID = (int)reader["LeyMH_ID"],
                RecovH_ID = (int)reader["RecovH_ID"],
                ConsuH_ID = (int)reader["ConsuH_ID"],
                Scales_TMH = (decimal)reader["Scales_TMH"],
                Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                Orig_ID = (int)reader["Orig_ID"],
                Orig_Name = reader["Orig_Name"].ToString(),
                Vendor_ID = (int)reader["Vendor_ID"],
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Collec_ID = (int)reader["Collec_ID"],
                Collec_Name = reader["Collec_Name"].ToString(),
                Hum_PorcH2O = (decimal)reader["Hum_PorcH2O"],
                LeyMH_FinishAu = (decimal)reader["LeyMH_FinishAu"],
                LeyMH_FinishAg = (decimal)reader["LeyMH_FinishAg"],
                ConsuH_ReacNaCN = (decimal)reader["ConsuH_ReacNaCN"],
                ConsuH_ReacNaOH = (decimal)reader["ConsuH_ReacNaOH"],
                //ConsuH_CuPorc = (decimal)reader["ConsuH_CuPorc"],
                RecovH_AuRecovCalc = (decimal)reader["RecovH_AuRecovCalc"],
                RecovH_AgRecovCalc = (decimal)reader["RecovH_AgRecovCalc"],
                CommP_WeigAuPor = (decimal)reader["CommP_WeigAuPor"],
                CommP_LeyAuQuan = (decimal)reader["CommP_LeyAuQuan"],
                CommP_LeyAgQuan = (decimal)reader["CommP_LeyAgQuan"],
                CommP_HumiAuPor = (decimal)reader["CommP_HumiAuPor"],
                CommP_HumiAgPor = (decimal)reader["CommP_HumiAgPor"],
                CommP_RecovAuMin = (decimal)reader["CommP_RecovAuMin"],
                CommP_RecovAuMax = (decimal)reader["CommP_RecovAuMax"],
                CommP_MaquilaMin = (decimal)reader["CommP_MaquilaMin"],
                CommP_MaquilaMax = (decimal)reader["CommP_MaquilaMax"],
                CommP_ConsuMin = (decimal)reader["CommP_ConsuMin"],
                CommP_ConsuMax = (decimal)reader["CommP_ConsuMax"],
                CommP_ExpAdm = (decimal)reader["CommP_ExpAdm"],
                Cond_RecovAu_Estim = (decimal)reader["Cond_RecovAu_Estim"],
                Cond_MaquilaAu_Estim = (decimal)reader["Cond_MaquilaAu_Estim"],
                Cond_ConsuAu_Estim = (decimal)reader["Cond_ConsuAu_Estim"],
                Cond_ExpAdmin_Estim = (decimal)reader["Cond_ExpAdmin_Estim"],
                Cond_ExpLab = (decimal)reader["Cond_ExpLab"],
                Cond_MaquilaAg = (decimal)reader["Cond_MaquilaAg"],
            };
        }
    }
}
