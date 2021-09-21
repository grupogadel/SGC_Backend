using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster.Commercial;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.InterfaceServices.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.MineralReception
{
    public class ServiceBatchMineral : IServiceBatchMineral
    {
        private readonly string _context;

        public ServiceBatchMineral(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int Add(BatchMineral model)
        {
            throw new NotImplementedException();
        }

        public int Delete(JObject obj)
        {
            throw new NotImplementedException();
        }

        public BatchMineral Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BatchMineral>> GetAll(int idCompany)
        {
            var response = new List<BatchMineral>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].BatchMineral_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToBatchMineral(reader));
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

        public async Task<List<BatchMineral>> GetAllNoHumidity(int idCompany)
        {
            var response = new List<BatchMineral>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].BatchMineral_GetAllNoHumidity";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToBatchMineral(reader));
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

        public async Task<List<BatchMineral>> Search(JObject obj)
        {
            var response = new List<BatchMineral>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].BatchMineral_Search";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@BatchM_Lote_New", obj["codLote"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["dateFrom"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["dateTo"].ToObject<DateTime>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToBatchMineral(reader));
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
        public async Task<List<BatchMineral>> SearchByRuma(JObject obj)
        {
            var response = new List<BatchMineral>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].BatchMineral_SearchByRuma";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Ruma_ID", obj["ruma_ID"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToBatchMineralByRuma(reader));
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

        public int Update(BatchMineral model)
        {
            throw new NotImplementedException();
        }

        private BatchMineral MapToBatchMineral(SqlDataReader reader)
        {
            return new BatchMineral()
            {
                BatchM_ID = (int)reader["BatchM_ID"],
                Scales_ID = (int)reader["Scales_ID"],
                Hum_ID = reader["Hum_ID"]==DBNull.Value?0:(int)reader["Hum_ID"],
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
                BatchM_TMSHist = reader["BatchM_TMSHist"]==DBNull.Value? (decimal?)null : (decimal)reader["BatchM_TMSHist"],
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
                Zone_Name = reader["Zone_Name"].ToString(),
                Scales = new Scales
                {
                    Scales_ID = (int)reader["Scales_ID"],
                    Scales_Lote = reader["Scales_Lote"].ToString(),
                    Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                    Origins= new Origin
                    {
                        Orig_ID= (int)reader["Orig_ID"],
                        Orig_Name = reader["Orig_Name"].ToString(),
                    }
                },
                Humiditys = new Humidity
                {
                    Hum_ID = reader["Hum_ID"]==DBNull.Value?0:(int)reader["Hum_ID"],
                    //Hum_Cod = reader["Hum_Cod"]==DBNull.Value?null:reader["Hum_Cod"].ToString(),
                    Hum_PorcH2O = reader["Hum_PorcH2O"]==DBNull.Value? (decimal?)null : (decimal)reader["Hum_PorcH2O"],
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

        private BatchMineral MapToBatchMineralByRuma(SqlDataReader reader)
        {
            return new BatchMineral()
            {
                BatchM_ID = (int)reader["BatchM_ID"],
                Scales_ID = (int)reader["Scales_ID"],
                Hum_ID = (int)reader["Hum_ID"],
                Ruma_ID = (int)reader["Ruma_ID"],
                //Quota_ID = (int)reader["Quota_ID"],
                LeyMH_ID = (int)reader["LeyMH_ID"],
                Company_ID = (int)reader["Company_ID"],
                Period_ID = (int)reader["Period_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
                BatchM_SubLote = reader["BatchM_SubLote"].ToString(),
                //BatchM_Retired_Date = (DateTime)reader["BatchM_Retired_Date"],
                //BatchM_TMHInt = (int)reader["BatchM_TMHInt"],
                //BatchM_PorHumInt = (int)reader["BatchM_PorHumInt"],
                BatchM_TMSHist = (decimal)reader["BatchM_TMSHist"],
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
                    Origins = new Origin
                    {
                        Orig_ID = (int)reader["Orig_ID"],
                        Orig_Name = reader["Orig_Name"].ToString(),
                    }
                },
                Humiditys = new Humidity
                {
                    Hum_ID = (int)reader["Hum_ID"],
                    Hum_Cod = reader["Hum_Cod"].ToString(),
                    Hum_PorcH2O = (decimal)reader["Hum_PorcH2O"]
                },
                LeyMineralHeads = new LeyMineralHead
                {
                    LeyMH_ID = (int)reader["LeyMH_ID"],
                    LeyMineralDetails = new LeyMineralDetail
                    {
                        LeyMD_ID = (int)reader["LeyMD_ID"],
                        LeyMD_FinalAu = (decimal)reader["LeyMD_FinalAu"],
                        LeyMD_FinalAg = (decimal)reader["LeyMD_FinalAg"],
                    }
                }
            };
        }

        public async Task<List<ModelBatchMineral>> SearchByDocApprob(JObject obj)
        {
            var modelBatch = new List<ModelBatchMineral>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].BatchMineral_SearchByDocApprob";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Period_NO", obj["periodNO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Scales_Lote", obj["loteNO"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        modelBatch.Add(MapToScalesDocument(reader));
                    }
                }
                await conn.CloseAsync();
                return modelBatch;
            }
            catch (Exception e)
            {
                return modelBatch;// 
                throw e;
            }
        }

        private ModelBatchMineral MapToScalesDocument(SqlDataReader reader)
        {
            return new ModelBatchMineral()
            {
                BatchM_ID = (int)reader["BatchM_ID"],
                BatchM_ApprovedDoc = reader["BatchM_ApprovedDoc"].ToString(),
                BatchM_DateDoc = reader["BatchM_DateDoc"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["BatchM_DateDoc"],
                BatchM_UserDoc = reader["BatchM_UserDoc"].ToString(),
                BatchM_Status = reader["BatchM_Status"].ToString(),
                Scales_ID = (int)reader["Scales_ID"],
                Scales_Lote = reader["Scales_Lote"].ToString(),
                Scales_NumSacos = (int)reader["Scales_NumSacos"],
                Scales_SubLote = reader["Scales_SubLote"].ToString(),
                Scales_TMH = (decimal)reader["Scales_TMH"],
                Scales_TMH_Hist = (decimal)reader["Scales_TMH_Hist"],
                Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                Scales_DateOut = (DateTime)reader["Scales_DateOut"],
                Scales_GuiRemRe_TaxID = reader["Scales_GuiRemRe_TaxID"].ToString(),
                Scales_GuiRemRe_Serie = reader["Scales_GuiRemRe_Serie"].ToString(),
                Scales_GuiRemRe_Num = reader["Scales_GuiRemRe_Num"].ToString(),
                Scales_GuiRemRe_Date = (DateTime)reader["Scales_GuiRemRe_Date"],
                Scales_Conces_NO = reader["Scales_Conces_NO"].ToString(),
                Scales_Conces_Name = reader["Scales_Conces_Name"].ToString(),
                Scales_Commit_NO = reader["Scales_Commit_NO"].ToString(),
                Scales_Patente = reader["Scales_Patente"].ToString(),
                Scales_DriverRUC = reader["Scales_DriverRUC"].ToString(),
                Scales_DriverName = reader["Scales_DriverName"].ToString(),
                Scales_GRDriv_Serie = reader["Scales_GRDriv_Serie"].ToString(),
                Scales_GRDriv_Num = reader["Scales_GRDriv_Num"].ToString(),
                Scales_GRDriv_Date = (DateTime)reader["Scales_GRDriv_Date"],
                Scales_MinOwner = reader["Scales_MinOwner"].ToString(),
                Scales_Operator = reader["Scales_Operator"].ToString(),
                MinType_ID = (int)reader["MinType_ID"],
                MinType_Desc = reader["MinType_Desc"].ToString(),
                MinFrom_ID = (int)reader["MinFrom_ID"],
                MinFrom_Name = reader["MinFrom_Name"].ToString(),
                Period_ID = (int)reader["Period_ID"],
                Period_NO = reader["Period_NO"].ToString(),
                Orig_ID = (int)reader["Orig_ID"],
                Orig_Name = reader["Orig_Name"].ToString(),
                Zone_ID = (int)reader["Zone_ID"],
                Zone_Name = reader["Zone_Name"].ToString(),
                Vendor_ID = (int)reader["Vendor_ID"],
                Vendor_CatPers = reader["Vendor_CatPers"].ToString(),
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Vendor_Desc = reader["Vendor_Desc"].ToString(),
                Vendor_SurName = reader["Vendor_SurName"].ToString(),
                Vendor_LastName = reader["Vendor_LastName"].ToString(),
                Person_ID = (int)reader["Person_ID"],
                Person_DNI = reader["Person_DNI"].ToString(),
                Person_Name = reader["Person_Name"].ToString(),
                Person_LastName = reader["Person_LastName"].ToString(),
                AnalReq_ID = (int)reader["AnalReq_ID"],
                AnalReq_Desc = reader["AnalReq_Desc"].ToString(),
                WrkShi_ID = (int)reader["WrkShi_ID"],
                WrkShi_Desc = reader["WrkShi_Desc"].ToString()

            };
        }

        public int ApproveDoc(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].BatchMineral_ApproveDoc";
                //Detail
                cmd.Parameters.Add(new SqlParameter("@BatchM_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Batch_ApprUser", obj["user"].ToObject<string>()));
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


    }
}
