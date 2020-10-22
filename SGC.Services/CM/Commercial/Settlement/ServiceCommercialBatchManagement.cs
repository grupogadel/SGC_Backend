using Microsoft.Extensions.Configuration;
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
    public class ServiceCommercialBatchManagement : IServiceCommercialBatchManagement
    {
        private readonly string _context;

        public ServiceCommercialBatchManagement(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/CommercialBatchManagement/GetAll
        public async Task<List<CommercialBatchManagement>> GetAll(int idCompany)
        {
            var response = new List<CommercialBatchManagement>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ManagementBatchMineral_GetAll2";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCommercialBatchManagement(reader));
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
        private CommercialBatchManagement MapToCommercialBatchManagement(SqlDataReader reader)
        {
            return new CommercialBatchManagement()
            {
                SampH_ID = (int)reader["SampH_ID"],
                BatchM_ID = (int)reader["BatchM_ID"],
                Scales_ID = (int)reader["Scales_ID"],
                Hum_ID = reader["Hum_ID"] == DBNull.Value ? 0 : (int)reader["Hum_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
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
                LeyMH_ID= (int)reader["SampH_ID"],
                RecovH_ID = (int)reader["RecovH_ID"],
                ConsuH_ID = (int)reader["ConsuH_ID"],
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
                Scales = new Scales
                {
                    Scales_ID = (int)reader["Scales_ID"],
                    //Scales_Lote = reader["Scales_Lote"].ToString(),
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
                    //Hum_Cod = reader["Hum_Cod"] == DBNull.Value ? null : reader["Hum_Cod"].ToString(),
                    Hum_PorcH2O = reader["Hum_PorcH2O"] == DBNull.Value ? (decimal?)null : (decimal)reader["Hum_PorcH2O"],
                },

            };
        }
    }
}
