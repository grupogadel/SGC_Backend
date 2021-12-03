using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Reports;
using SGC.InterfaceServices.CM.Commercial.Reports;
using SGC.Entities.Entities.CM.Commercial.Liquidation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace SGC.Services.CM.Commercial.Reports
{
    public class ServiceReports : IServiceReports
    {
        private readonly string _context;

        public ServiceReports(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public async Task<List<BatchComProcTime>> SearchTimeProc(JObject obj)
        {
            var response = new List<BatchComProcTime>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[BatchMineral_Search_TimeProc]";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@BatchM_Lote_New", obj["batchM_Lote_New"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["vendor_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToManagementBatchComProcTime(reader));
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

        public async Task<List<MineralBatchLiquidation>> SearchMineralBatchLiiquidation(JObject obj)
        {
            var response = new List<MineralBatchLiquidation>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[MineralBatch_Search_Report]";
                bool rank = false;


                if (obj["period_To"].ToObject<string>() == "" && obj["period_From"].ToObject<string>() == "")
                {
                    rank = false;
                }
                else
                {
                    if (obj["period_From"].ToObject<string>() == "")
                    {
                        obj["period_From"] = obj["period_To"];
                    }
                    rank = true;
                }

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@BatchM_Lote_New", obj["batchM_Lote_New"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Period_To", obj["period_To"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Period_From", obj["period_From"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["vendor_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["collec_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Rank", rank));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToManagementMineralBatch(reader));
                    }
                }
                await conn.CloseAsync();
                return await GetDetailsLiquidationAuAg(response);
            }
            catch (Exception e)
            {
                return response;
                throw e;
            }
        }

        private BatchComProcTime MapToManagementBatchComProcTime(SqlDataReader reader)
        {
            return new BatchComProcTime()
            {
                BatchM_ID = (int)reader["BatchM_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),

                Scales_DateInp = (DateTime)reader["Scales_DateInp"],

                Vendor_ID = (int)reader["Vendor_ID"],
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Vendor_Desc = reader["Vendor_Desc"].ToString(),
                Vendor_LastName = reader["Vendor_LastName"].ToString(),
                Vendor_SurName = reader["Vendor_SurName"].ToString(),

                SampH_Proces_Date = reader["SampH_Proces_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["SampH_Proces_Date"],
                SampD_RecLab_Date = reader["SampD_RecLab_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["SampD_RecLab_Date"],
                SampH_LabFinish_Date = reader["SampH_LabFinish_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["SampH_LabFinish_Date"],
                IntCtrlH_Approved_Date = reader["IntCtrlH_Approved_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["IntCtrlH_Approved_Date"],
                Creation_DateLiq = reader["Creation_DateLiq"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["Creation_DateLiq"],
                LiquiH_AcceptDate = reader["LiquiH_AcceptDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["LiquiH_AcceptDate"],
               
            };
        }

        private MineralBatchLiquidation MapToManagementMineralBatch(SqlDataReader reader)
        {
            return new MineralBatchLiquidation()
            {
                BatchM_ID = (int)reader["BatchM_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
                BatchM_TMSInt = reader["BatchM_TMSInt"] == DBNull.Value ? (decimal?)null : (decimal)reader["BatchM_TMSInt"],
                BatchM_TMHInt = reader["BatchM_TMHInt"] == DBNull.Value ? (decimal?)null : (decimal)reader["BatchM_TMHInt"],
                BatchM_TMSHist = reader["BatchM_TMSHist"] == DBNull.Value ? (decimal?)null : (decimal)reader["BatchM_TMSHist"],

                Ruma_NO = reader["Ruma_NO"].ToString(),

                Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                Scales_NumSacos = (int)reader["Scales_NumSacos"],

                Hum_PorcH2O = reader["Hum_PorcH2O"] == DBNull.Value ? (decimal?)null : (decimal)reader["Hum_PorcH2O"],

                Period_NO = reader["Period_NO"].ToString(),

                Orig_Name = reader["Orig_Name"].ToString(),

                Vendor_ID = (int)reader["Vendor_ID"],
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Vendor_Desc = reader["Vendor_Desc"].ToString(),
                Vendor_LastName = reader["Vendor_LastName"].ToString(),
                Vendor_SurName = reader["Vendor_SurName"].ToString(),

                MinType_Desc = reader["MinType_Desc"].ToString(),

                LiquiH_ID = reader["LiquiH_ID"] == DBNull.Value ? (int?)null : (int)reader["LiquiH_ID"],
                LiquiH_DateProc = reader["LiquiH_DateProc"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["LiquiH_DateProc"],
                LiquiH_Status = reader["LiquiH_Status"].ToString(),
                LiquiH_ExpLabVal = reader["LiquiH_ExpLabVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["LiquiH_ExpLabVal"],

            };
        }

        public async Task<List<MineralBatchLiquidation>> GetDetailsLiquidationAuAg(List<MineralBatchLiquidation> temp)
        {
            var response = new List<MineralBatchLiquidation>();
            try
            {
                foreach (MineralBatchLiquidation element in temp)
                {
                    if (element.LiquiH_ID == null)
                    {
                        element.LiquidationDetailAuReport = new LiquidationDetail();
                        element.LiquidationDetailAgReport = new LiquidationDetail();
                        element.LiquidationDetailAuInt = new LiquidationDetail();
                        element.LiquidationDetailAgInt = new LiquidationDetail();

                    }
                    else
                    {
                        element.LiquidationDetailAuReport = await GetDetailMineral((int)element.LiquiH_ID, "Au", "Com");
                        element.LiquidationDetailAgReport = await GetDetailMineral((int)element.LiquiH_ID, "Ag", "Com");
                        element.LiquidationDetailAuInt = await GetDetailMineral((int)element.LiquiH_ID, "Au", "Int");
                        element.LiquidationDetailAgInt = await GetDetailMineral((int)element.LiquiH_ID, "Ag", "Int");

                        if (element.LiquiH_Status == "51" || element.LiquiH_Status == "52")
                        {
                            element.LiquidationDetailAuReport = await GetDetailMineral((int)element.LiquiH_ID, "Au", "Rein");
                            element.LiquidationDetailAgReport = await GetDetailMineral((int)element.LiquiH_ID, "Ag", "Rein");
                        }
                    }
                }
                response = temp;
                return response;
            }
            catch (Exception e)
            {
                return response;
                throw e;
            }
        }


        public async Task<LiquidationDetail> GetDetailMineral(int liquiH_ID, string mineral, string dataLine)
        {
            var response = new LiquidationDetail();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Liquidation_GetDetailMineral";

                cmd.Parameters.Add(new SqlParameter("@LiquiH_ID", liquiH_ID));
                cmd.Parameters.Add(new SqlParameter("@Mineral", mineral));
                cmd.Parameters.Add(new SqlParameter("@DataLine", dataLine));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToDetailMineral(reader);
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

        private LiquidationDetail MapToDetailMineral(SqlDataReader reader)
        {
            return new LiquidationDetail()
            {
                LiquiD_ID = (int)reader["LiquiD_ID"],
                LiquiH_ID = (int)reader["LiquiH_ID"],
                LiquiD_TMH = (decimal)reader["LiquiD_TMH"],
                LiquiD_PorHum = (decimal)reader["LiquiD_PorHum"],
                LiquiD_TMS = (decimal)reader["LiquiD_TMS"],
                LiquiD_Recov = (decimal)reader["LiquiD_Recov"],
                LiquiD_Ley = (decimal)reader["LiquiD_Ley"],
                LiquiD_PriceInt = (decimal)reader["LiquiD_PriceInt"],
                LiquiD_MarginPI = (decimal)reader["LiquiD_MarginPI"],
                LiquiD_Maquila = (decimal)reader["LiquiD_Maquila"],
                LiquiD_ConsuCN = reader["LiquiD_ConsuCN"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_ConsuCN"],
                LiquiD_ExpAdm = reader["LiquiD_ExpAdm"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_ExpAdm"],
                LiquiD_UnitPrec = (decimal)reader["LiquiD_UnitPrec"],
                LiquiD_TotLiq = (decimal)reader["LiquiD_TotLiq"],
                LiquiD_PorcBrutMarg = reader["LiquiD_PorcBrutMarg"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_PorcBrutMarg"],
                LiquiD_ImpBrutMarg = reader["LiquiD_ImpBrutMarg"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_ImpBrutMarg"],
                LiquiD_Mineral = reader["LiquiD_Mineral"].ToString(),
                LiquiD_DataLine = reader["LiquiD_DataLine"].ToString(),
                LiquiD_TMHInitial = reader["LiquiD_TMHInitial"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_TMHInitial"],
                LiquiD_PorHumInitial = reader["LiquiD_PorHumInitial"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_PorHumInitial"],
                LiquiD_LeyInitial = reader["LiquiD_LeyInitial"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_LeyInitial"],
                LiquiD_RecovInitial = reader["LiquiD_RecovInitial"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_RecovInitial"],
                LiquiD_MarginPIInitial = reader["LiquiD_MarginPIInitial"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_MarginPIInitial"],
                LiquiD_MaquilaInitial = reader["LiquiD_MaquilaInitial"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_MaquilaInitial"],
                LiquiD_ConsuCNInitial = reader["LiquiD_ConsuCNInitial"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_ConsuCNInitial"],
                LiquiD_ExpAdmInitial = reader["LiquiD_ExpAdmInitial"] == DBNull.Value ? new decimal?() : (decimal)reader["LiquiD_ExpAdmInitial"],
                CompPago_ID = reader["CompPago_ID"] == DBNull.Value ? new int?() : (int)reader["CompPago_ID"],
                LiquiD_InvSerie = reader["LiquiD_InvSerie"].ToString(),
                LiquiD_InvNO = reader["LiquiD_InvNO"].ToString(),
                LiquiD_InvDate = reader["LiquiD_InvDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["LiquiD_InvDate"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                LiquiD_Status = reader["LiquiD_Status"].ToString(),
            };
        }

    }
}
