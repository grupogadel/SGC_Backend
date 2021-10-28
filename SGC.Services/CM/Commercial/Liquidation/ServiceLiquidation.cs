using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Liquidation;
using SGC.Entities.Entities.CM.Commercial;
using SGC.InterfaceServices.CM.Commercial.Liquidation;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace SGC.Services.CM.Commercial.Liquidation
{
    public class ServiceLiquidation : IServiceLiquidation
    {
        private readonly string _context;

        public ServiceLiquidation(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public async Task<List<ManagementLiquidation>> Search(JObject obj)
        {
            var response = new List<ManagementLiquidation>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[Liquidation_Search_Batches]";

                bool rank = false;
                DateTime dateTime;

                if (!DateTime.TryParse(obj["date_From"].ToObject<string>(), out dateTime) && !DateTime.TryParse(obj["date_To"].ToObject<string>(), out dateTime))
                {
                    obj["date_To"] = DateTime.Now;
                    obj["date_From"] = obj["date_To"];
                    rank = false;
                }
                else
                {
                    if (!DateTime.TryParse(obj["date_From"].ToObject<string>(), out dateTime))
                    {
                        obj["date_From"] = obj["date_To"];
                    }
                    rank = true;
                }

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@BatchM_Lote_New", obj["batchM_Lote_New"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["date_To"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["date_From"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_Status", obj["liquiH_Status"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["vendor_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Rank", rank));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToManagementLiquidation(reader));
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

        public async Task<List<ManagementLiquidation>> GetDetailsLiquidationAuAg (List<ManagementLiquidation> temp)
        {
            var response = new List<ManagementLiquidation>();
            try
            {
                foreach (ManagementLiquidation element in temp){
                    if (element.LiquidationHead.LiquiH_ID == null) {
                        element.LiquidationHead.LiquidationDetailAg = new LiquidationDetail();
                        element.LiquidationHead.LiquidationDetailAu = new LiquidationDetail();
                        element.LiquidationHead.LiquidationDetailAuInt = new LiquidationDetail();
                        element.LiquidationHead.LiquidationDetailAgInt = new LiquidationDetail();
                        element.LiquidationHead.LiquidationDetailAuReint = new LiquidationDetail();
                        element.LiquidationHead.LiquidationDetailAgReint = new LiquidationDetail();
                        //element.LiquidationHead.PriceInternational = await PriceInternationalGetDay(DateTime.Now);
                    } else {
                        element.LiquidationHead.LiquidationDetailAg = await GetDetailMineral((int)element.LiquidationHead.LiquiH_ID, "Ag", "Com");
                        element.LiquidationHead.LiquidationDetailAu = await GetDetailMineral((int)element.LiquidationHead.LiquiH_ID, "Au", "Com");
                        element.LiquidationHead.LiquidationDetailAuInt = await GetDetailMineral((int)element.LiquidationHead.LiquiH_ID, "Au", "Int");
                        element.LiquidationHead.LiquidationDetailAgInt = await GetDetailMineral((int)element.LiquidationHead.LiquiH_ID, "Ag", "Int");
                        element.LiquidationHead.PriceInternational = await PriceInternationalGetID((int)element.LiquidationHead.Price_ID);

                        if (element.LiquidationHead.LiquiH_Status == "51" || element.LiquidationHead.LiquiH_Status == "52")
                        {
                            element.LiquidationHead.LiquidationDetailAuReint = await GetDetailMineral((int)element.LiquidationHead.LiquiH_ID, "Au", "Rein");
                            element.LiquidationHead.LiquidationDetailAgReint = await GetDetailMineral((int)element.LiquidationHead.LiquiH_ID, "Ag", "Rein");
                        }
                        else
                        {
                            element.LiquidationHead.LiquidationDetailAuReint = new LiquidationDetail();
                            element.LiquidationHead.LiquidationDetailAgReint = new LiquidationDetail();
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

        public async Task<LiquidationDetail> GetDetailMineral(int liquiH_ID, string mineral, string dataLine )
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

        public async Task<PriceInternational> PriceInternationalGetDay(JObject obj)
        {
            var response = new PriceInternational();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].PriceInternational_GetDay";

                cmd.Parameters.Add(new SqlParameter("@Date", obj["date"].ToObject<DateTime>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToPriceInternational(reader);
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

        public async Task<PriceInternational> PriceInternationalGetID(int price_ID)
        {
            var response = new PriceInternational();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].PriceInternational_GetID";

                cmd.Parameters.Add(new SqlParameter("@Price_ID", price_ID));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToPriceInternational(reader);
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

        public int ChangeStatus(JObject obj)
        {
            try
            { 
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Liquidation_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@BatchM_ID", obj["id"].ToObject<int>()));
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

        private ManagementLiquidation MapToManagementLiquidation(SqlDataReader reader)
        {
            return new ManagementLiquidation(){

                BatchM_ID = (int)reader["BatchM_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
                BatchM_TMHInt = reader["BatchM_TMHInt"] == DBNull.Value ? 0 : (decimal)reader["BatchM_TMHInt"],
                BatchM_TMSHist = reader["BatchM_TMSHist"] == DBNull.Value ? 0 : (decimal)reader["BatchM_TMSHist"],
                BatchM_PorHumInt = reader["BatchM_PorHumInt"] == DBNull.Value ? 0 : (decimal)reader["BatchM_PorHumInt"],
                BatchM_TMSInt = reader["BatchM_TMSInt"] == DBNull.Value ? 0 : (decimal)reader["BatchM_TMSInt"],
                BatchM_LeyAuInt = reader["BatchM_LeyAuInt"] == DBNull.Value ? 0 : (decimal)reader["BatchM_LeyAuInt"],
                BatchM_LeyAgInt = reader["BatchM_LeyAgInt"] == DBNull.Value ? 0 : (decimal)reader["BatchM_LeyAgInt"],
                BatchM_LiquidBlock = reader["BatchM_LiquidBlock"].ToString(),
                
                Scales_ID = (int)reader["Scales_ID"],
                Scales_TMH_Hist = reader["Scales_TMH_Hist"] == DBNull.Value ? 0 : (decimal)reader["Scales_TMH_Hist"],
                Scales_DateInp = (DateTime)reader["Scales_DateInp"],

                Hum_PorcH2O = reader["Hum_PorcH2O"] == DBNull.Value ? 0 : (decimal)reader["Hum_PorcH2O"],

                LeyMH_FinishAu = reader["LeyMH_FinishAu"] == DBNull.Value ? 0 : (decimal)reader["LeyMH_FinishAu"],
                LeyMH_FinishAg = reader["LeyMH_FinishAg"] == DBNull.Value ? 0 : (decimal)reader["LeyMH_FinishAg"],

                Vendor_ID = (int)reader["Vendor_ID"],
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Vendor_Desc = reader["Vendor_Desc"].ToString(),
                Vendor_LastName = reader["Vendor_LastName"].ToString(),
                Vendor_SurName = reader["Vendor_SurName"].ToString(),

                Collec_ID = (int)reader["Collec_ID"],
                Collec_Name = reader["Person_Name"].ToString(),
                Collec_LastName = reader["Person_LastName"].ToString(),
                Collec_DNI = reader["Person_DNI"].ToString(),

                Orig_ID = (int)reader["Orig_ID"],
                Orig_Name = reader["Orig_Name"].ToString(),
                Orig_Desc = reader["Orig_Desc"].ToString(),

                Zone_ID = (int)reader["Zone_ID"],
                Zone_Name = reader["Zone_Name"].ToString(),

                MinType_ID = (int)reader["MinType_ID"],
                MinType_Desc = reader["MinType_Desc"].ToString(),
             
                LiquidationHead = new LiquidationHead
                {
                    LiquiH_ID = reader["LiquiH_ID"] == DBNull.Value ? new int?() : (int)reader["LiquiH_ID"],
                    Cond_ID = reader["Cond_ID"] == DBNull.Value ? new int?() : (int)reader["Cond_ID"],
                    CorpP_ID = reader["CorpP_ID"] == DBNull.Value ? new int?() : (int)reader["CorpP_ID"],
                    Price_ID = reader["Price_ID"] == DBNull.Value ? new int?() : (int)reader["Price_ID"],
                    Company_ID = reader["Company_ID"] == DBNull.Value ? new int?() : (int)reader["Company_ID"],
                    LiquiH_NO = reader["LiquiH_NO"].ToString(),
                    LiquiH_DateProc = reader["LiquiH_DateProc"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["LiquiH_DateProc"],
                    LiquiH_UserApro = reader["LiquiH_UserApro"].ToString(),
                    LiquiH_DateApro = reader["LiquiH_DateApro"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["LiquiH_DateApro"],
                    LiquiH_ExpLabVal = reader["LiquiH_ExpLabVal"] == DBNull.Value ? 0 : (decimal)reader["LiquiH_ExpLabVal"],
                    LiquiH_ExpLabValInitial = reader["LiquiH_ExpLabValInitial"] == DBNull.Value ? 0 : (decimal)reader["LiquiH_ExpLabValInitial"],
                    LiquiH_DateDoc = reader["LiquiH_DateDoc"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["LiquiH_DateDoc"],
                    LiquiH_NODoc = reader["LiquiH_NODoc"].ToString(),
                    LabExt_ID = reader["LabExt_ID"] == DBNull.Value ? new int?() : (int)reader["LabExt_ID"],
                    AnalType_ID = reader["AnalType_ID"] == DBNull.Value ? new int?() : (int)reader["AnalType_ID"],
                    Creation_User = reader["Creation_User"].ToString(),
                    Creation_Date = reader["Creation_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["Creation_Date"],
                    Modified_User = reader["Modified_User"].ToString(),
                    Modified_Date = reader["Modified_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["Modified_Date"],
                    LiquiH_Status = reader["LiquiH_Status"].ToString(),

                    AnalisysType = new AnalisysType
                    {
                        AnalType_ID = reader["AnalType_ID"] == DBNull.Value ? new int?() : (int)reader["AnalType_ID"],
                        AnalType_Cod = reader["AnalType_Cod"].ToString(),
                        AnalType_Desc = reader["AnalType_Desc"].ToString(),
                    },

                    LabExternal = new LabExternal
                    {
                        LabExt_ID = reader["LabExt_ID"] == DBNull.Value ? new int?() : (int)reader["LabExt_ID"],
                        LabExt_Cod = reader["LabExt_Cod"] == DBNull.Value ? new int?() : (int)reader["LabExt_Cod"],
                        LabExt_Name = reader["LabExt_Name"].ToString(),
                        LabExt_City = reader["LabExt_City"].ToString(),
                    },

                },
            };
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

        public async Task<int> Add(ManagementLiquidation model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[Liquidation_Add]";

                List<LiquidationDetail> liquidationDetail = new List<LiquidationDetail>();
                model.LiquidationHead.LiquidationDetailAu.LiquiD_Mineral = "Au";
                model.LiquidationHead.LiquidationDetailAg.LiquiD_Mineral = "Ag";
                model.LiquidationHead.LiquidationDetailAu.LiquiD_DataLine = "Com";
                model.LiquidationHead.LiquidationDetailAg.LiquiD_DataLine = "Com";
                model.LiquidationHead.LiquidationDetailAuInt.LiquiD_Mineral = "Au";
                model.LiquidationHead.LiquidationDetailAgInt.LiquiD_Mineral = "Ag";
                model.LiquidationHead.LiquidationDetailAuInt.LiquiD_DataLine = "Int";
                model.LiquidationHead.LiquidationDetailAgInt.LiquiD_DataLine = "Int";
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAu);
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAg);
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAgInt);
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAuInt);

                //Head
                cmd.Parameters.Add(new SqlParameter("@Cond_ID", model.LiquidationHead.Cond_ID));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ID", model.LiquidationHead.CorpP_ID));
                cmd.Parameters.Add(new SqlParameter("@Price_ID", model.LiquidationHead.Price_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.LiquidationHead.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@BatchM_ID", model.BatchM_ID));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_ExpLabVal", model.LiquidationHead.LiquiH_ExpLabVal));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_ExpLabValInitial", model.LiquidationHead.LiquiH_ExpLabValInitial));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_DateProc", model.LiquidationHead.LiquiH_DateProc));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.LiquidationHead.Creation_User));
                //Details
                SqlParameter parGetLiquidationDetail = GetLiquidationDetail("tabLiquidationDetail", liquidationDetail);
                cmd.Parameters.Add(parGetLiquidationDetail);
                //Output
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

        public async Task<int> Update(ManagementLiquidation model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[Liquidation_Update]";

                List<LiquidationDetail> liquidationDetail = new List<LiquidationDetail>();
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAu);
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAg);
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAgInt);
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAuInt);

                //Head
                cmd.Parameters.Add(new SqlParameter("@LiquiH_ID", model.LiquidationHead.LiquiH_ID));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_ExpLabVal", model.LiquidationHead.LiquiH_ExpLabVal));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.LiquidationHead.Modified_User));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_Status", model.LiquidationHead.LiquiH_Status));
                //Details
                SqlParameter parGetLiquidationDetail = GetLiquidationDetail("tabLiquidationDetail", liquidationDetail);
                cmd.Parameters.Add(parGetLiquidationDetail);
                //Output
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

        public async Task<int> AddRefund(ManagementLiquidation model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[Liquidation_AddRefund]";

                List<LiquidationDetail> liquidationDetail = new List<LiquidationDetail>();
                model.LiquidationHead.LiquidationDetailAuReint.LiquiD_DataLine = "Rein";
                model.LiquidationHead.LiquidationDetailAgReint.LiquiD_DataLine = "Rein";
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAuReint);
                liquidationDetail.Add(model.LiquidationHead.LiquidationDetailAgReint);

                //Head
                cmd.Parameters.Add(new SqlParameter("@LiquiH_ID", model.LiquidationHead.LiquiH_ID));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_ExpLabVal", model.LiquidationHead.LiquiH_ExpLabVal));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_DateDoc", model.LiquidationHead.LiquiH_DateDoc));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_NODoc", model.LiquidationHead.LiquiH_NODoc));
                cmd.Parameters.Add(new SqlParameter("@LabExt_ID", model.LiquidationHead.LabExt_ID));
                cmd.Parameters.Add(new SqlParameter("@AnalType_ID", model.LiquidationHead.AnalType_ID));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.LiquidationHead.Modified_User));
                cmd.Parameters.Add(new SqlParameter("@LiquiH_Status", model.LiquidationHead.LiquiH_Status));
                //Details
                SqlParameter parGetLiquidationDetail = GetLiquidationDetail("tabLiquidationDetail", liquidationDetail);
                cmd.Parameters.Add(parGetLiquidationDetail);
                //Output
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

        public SqlParameter GetLiquidationDetail(string name, List<LiquidationDetail> liquidationDetail)
        {
            try
            {
                DataTable table = new DataTable("dbo.tabLiquidationDetail");
                table.Columns.Add("LiquiD_ID", typeof(int));
                table.Columns.Add("LiquiD_TMH", typeof(decimal));
                table.Columns.Add("LiquiD_PorHum", typeof(decimal));
                table.Columns.Add("LiquiD_TMS", typeof(decimal));
                table.Columns.Add("LiquiD_Recov", typeof(decimal));
                table.Columns.Add("LiquiD_Ley", typeof(decimal));
                table.Columns.Add("LiquiD_PriceInt", typeof(decimal));
                table.Columns.Add("LiquiD_MarginPI", typeof(decimal));
                table.Columns.Add("LiquiD_Maquila", typeof(decimal));
                table.Columns.Add("LiquiD_ConsuCN", typeof(decimal));
                table.Columns.Add("LiquiD_ExpAdm", typeof(decimal));
                table.Columns.Add("LiquiD_UnitPrec", typeof(decimal));
                table.Columns.Add("LiquiD_TotLiq", typeof(decimal));
                table.Columns.Add("LiquiD_PorcBrutMarg", typeof(decimal));
                table.Columns.Add("LiquiD_ImpBrutMarg", typeof(decimal));
                table.Columns.Add("LiquiD_Mineral", typeof(string));
                table.Columns.Add("LiquiD_DataLine", typeof(string));
                table.Columns.Add("LiquiD_TMHInitial", typeof(decimal));
                table.Columns.Add("LiquiD_PorHumInitial", typeof(decimal));
                table.Columns.Add("LiquiD_LeyInitial", typeof(decimal));
                table.Columns.Add("LiquiD_RecovInitial", typeof(decimal));
                table.Columns.Add("LiquiD_MarginPIInitial", typeof(decimal));
                table.Columns.Add("LiquiD_MaquilaInitial", typeof(decimal));
                table.Columns.Add("LiquiD_ConsuCNInitial", typeof(decimal));
                table.Columns.Add("LiquiD_ExpAdmInitial", typeof(decimal));

                foreach (LiquidationDetail LiquidDetail in liquidationDetail)
                    table.Rows.Add(new object[] {   LiquidDetail.LiquiD_ID,
                                                    LiquidDetail.LiquiD_TMH,
                                                    LiquidDetail.LiquiD_PorHum,
                                                    LiquidDetail.LiquiD_TMS,
                                                    LiquidDetail.LiquiD_Recov,
                                                    LiquidDetail.LiquiD_Ley,
                                                    LiquidDetail.LiquiD_PriceInt,
                                                    LiquidDetail.LiquiD_MarginPI,
                                                    LiquidDetail.LiquiD_Maquila,
                                                    LiquidDetail.LiquiD_ConsuCN,
                                                    LiquidDetail.LiquiD_ExpAdm,
                                                    LiquidDetail.LiquiD_UnitPrec,
                                                    LiquidDetail.LiquiD_TotLiq,
                                                    LiquidDetail.LiquiD_PorcBrutMarg,
                                                    LiquidDetail.LiquiD_ImpBrutMarg,
                                                    LiquidDetail.LiquiD_Mineral,
                                                    LiquidDetail.LiquiD_DataLine,
                                                    LiquidDetail.LiquiD_TMHInitial,
                                                    LiquidDetail.LiquiD_PorHumInitial,
                                                    LiquidDetail.LiquiD_LeyInitial,
                                                    LiquidDetail.LiquiD_RecovInitial,
                                                    LiquidDetail.LiquiD_MarginPIInitial,
                                                    LiquidDetail.LiquiD_MaquilaInitial,
                                                    LiquidDetail.LiquiD_ConsuCNInitial,
                                                    LiquidDetail.LiquiD_ExpAdmInitial
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.tabLiquidationDetail";

                return parameter;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }


    }
}
