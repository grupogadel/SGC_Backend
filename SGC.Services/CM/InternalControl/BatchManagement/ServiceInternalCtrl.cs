using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.InternalControl.BatchManagement;
using SGC.InterfaceServices.CM.InternalControl.BatchManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SGC.Services.CM.InternalControl.BatchManagement
{
    public class ServiceInternalCtrl : IServiceInternalCtrl
    {
        private readonly string _context;
        public ServiceInternalCtrl(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/InternalCtrl/GetAll/1
        public List<InternalCtrlHeadCommercial> GetAll(int idCompany)
        {
            var internalCtrlHead = new List<InternalCtrlHeadCommercial>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrlHeadCommercial_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        internalCtrlHead.Add(MapToInternalCtrlHeadCommercial(reader));
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetails_GetAll";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID", ich.IntCtrlH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailss.Add(MapToInternalCtrlDetails(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsLeyM_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsLeyMs.Add(MapToInternalCtrlDetailsLeyM(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsConsume_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsConsumes.Add(MapToInternalCtrlDetailsConsume(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsRecovery_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsRecoverys.Add(MapToInternalCtrlDetailsRecovery(dr));
                        }
                    }
                }

                conn.Close();

                return internalCtrlHead;
            }
            catch (Exception e)
            {
                return internalCtrlHead;
                throw e;
            }
        }

        private InternalCtrlHeadCommercial MapToInternalCtrlHeadCommercial(SqlDataReader reader)
        {
            return new InternalCtrlHeadCommercial()
            {
                IntCtrlH_ID = (int)reader["IntCtrlH_ID"],
                SampH_ID = (int)reader["BatchM_ID"],
                Company_ID = (int)reader["Company_ID"],
                IntCtrlH_Current_Detail = (int)reader["IntCtrlH_Current_Detail"],
                BatchM_ID = (int)reader["BatchM_ID"],
                SampH_Current_Detail = (int)reader["SampH_Current_Detail"],
                AnalType_ID = (int)reader["AnalType_ID"],
                AnalType_Desc = reader["AnalType_Desc"].ToString(),
                Hum_ID = (int)reader["Hum_ID"],
                Hum_PorcH2O = (decimal)reader["Hum_PorcH2O"],
                Scales_ID = (int)reader["Scales_ID"],
                Scales_Lote = reader["Scales_Lote"].ToString(),
                Scales_TMH = (decimal)reader["Scales_TMH"],
                Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                MinType_ID = (int)reader["MinType_ID"],
                MinType_Desc = reader["MinType_Desc"].ToString(),
                Orig_ID = (int)reader["Orig_ID"],
                Orig_Name = reader["Orig_Name"].ToString(),
                Zone_ID = (int)reader["Zone_ID"],
                Zone_Name = reader["Zone_Name"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                IntCtrlH_Status = reader["IntCtrlH_Status"].ToString(),
		        LeyMH_FinishAu = reader["LeyMH_FinishAu"]==DBNull.Value?(decimal?)null:(decimal)reader["LeyMH_FinishAu"],
		        SampH_Status_Cod = reader["SampH_Status_Cod"].ToString()
            };
        }

        private InternalCtrlDetails MapToInternalCtrlDetails(SqlDataReader reader)
        {
            return new InternalCtrlDetails()
            {
                IntCtrlD_ID = (int)reader["IntCtrlD_ID"],
                IntCtrlH_ID = (int)reader["IntCtrlH_ID"],
                LabExt_ID = reader["LabExt_ID"]==DBNull.Value?0:(int)reader["LabExt_ID"],
                LabExt_Name = reader["LabExt_Name"]==DBNull.Value?null:reader["LabExt_Name"].ToString(),
                IntCtrlD_PolCorp = reader["IntCtrlD_PolCorp"] ==DBNull.Value?(decimal?)null:(decimal)reader["IntCtrlD_PolCorp"],
                LabProcTyp_ID = reader["LabProcTyp_ID"]==DBNull.Value?0:(int)reader["LabProcTyp_ID"],
                LabProcTyp_Name = reader["LabProcTyp_Name"]==DBNull.Value?null:reader["LabProcTyp_Name"].ToString(),
                LabProcTyp_Desc = reader["LabProcTyp_Desc"]==DBNull.Value?null:reader["LabProcTyp_Desc"].ToString(),
                AnalType_ID = reader["AnalType_ID"]==DBNull.Value?0:(int)reader["AnalType_ID"],
                AnalType_Desc = reader["AnalType_Desc"]==DBNull.Value?null:reader["AnalType_Desc"].ToString(),
                SampOrig_ID = reader["SampOrig_ID"]==DBNull.Value?0:(int)reader["SampOrig_ID"],
                SampOrig_Cod = reader["SampOrig_Cod"]==DBNull.Value?null:reader["SampOrig_Cod"].ToString(),
                SampOrig_AreaDesc = reader["SampOrig_AreaDesc"]==DBNull.Value?null:reader["SampOrig_AreaDesc"].ToString(),
                SampOrig_Desc = reader["SampOrig_Desc"]==DBNull.Value?null:reader["SampOrig_Desc"].ToString(),
                IntCtrlD_LoteNew = reader["IntCtrlD_LoteNew"]==DBNull.Value?null:reader["IntCtrlD_LoteNew"].ToString(),
                IntCtrlD_Process_Date = reader["IntCtrlD_Process_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["IntCtrlD_Process_Date"],
                IntCtrlD_SubLoteNew = reader["IntCtrlD_SubLoteNew"]==DBNull.Value?null:reader["IntCtrlD_SubLoteNew"].ToString(),
                IntCtrlD_SampWeig = reader["IntCtrlD_SampWeig"]==DBNull.Value? (decimal?)null : (decimal)reader["IntCtrlD_SampWeig"],
                IntCtrlD_Puruna_Date = reader["IntCtrlD_Puruna_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["IntCtrlD_Puruna_Date"],
                IntCtrlD_LeyAu_Puru = reader["IntCtrlD_LeyAu_Puru"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtrlD_LeyAu_Puru"],
                IntCtrlD_ConsuNaCN_Puru = reader["IntCtrlD_ConsuNaCN_Puru"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtrlD_ConsuNaCN_Puru"],
                IntCtrlD_ConsuNaOH_Puru = reader["IntCtrlD_ConsuNaOH_Puru"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtrlD_ConsuNaOH_Puru"],
                IntCtrlD_Recov_Puru = reader["IntCtrlD_Recov_Puru"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtrlD_Recov_Puru"],
                IntCtrlD_AnalInf_NO = reader["IntCtrlD_AnalInf_NO"] == DBNull.Value ? null : reader["IntCtrlD_AnalInf_NO"].ToString(),
                IntCtrlD_AnalInf_Date = reader["IntCtrlD_AnalInf_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["IntCtrlD_AnalInf_Date"],
                IntCtrlD_AnalType_LExt = reader["IntCtrlD_AnalType_LExt"] == DBNull.Value ? null : reader["IntCtrlD_AnalType_LExt"].ToString(),
                IntCtrlD_LeyAu_LExt = reader["IntCtrlD_LeyAu_LExt"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtrlD_LeyAu_LExt"],
                IntCtrlD_LeyAg_LExt = reader["IntCtrlD_LeyAg_LExt"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtrlD_LeyAg_LExt"],
                IntCtlD_NaCN_LExt = reader["IntCtlD_NaCN_LExt"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtlD_NaCN_LExt"],
                IntCtlD_NaOH_LExt = reader["IntCtlD_NaOH_LExt"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtlD_NaOH_LExt"],
                IntCtrlD_RecovAu_LExt = reader["IntCtrlD_RecovAu_LExt"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtrlD_RecovAu_LExt"],
                IntCtrlD_RecovAg_LExt = reader["IntCtrlD_RecovAg_LExt"] == DBNull.Value ? (decimal?)null : (decimal)reader["IntCtrlD_RecovAg_LExt"],
                IntCtrlD_Status_Var = reader["IntCtrlD_Status_Var"]==DBNull.Value?null:reader["IntCtrlD_Status_Var"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                IntCtrlD_Status = reader["IntCtrlD_Status"].ToString()
            };
        }

        private InternalCtrlDetailsLeyM MapToInternalCtrlDetailsLeyM(SqlDataReader reader)
        {
            return new InternalCtrlDetailsLeyM()
            {
                LeyMH_ID = (int)reader["LeyMH_ID"],
                LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                LeyMH_FinishAu = (decimal)reader["LeyMH_FinishAu"],
                LeyMH_FinishAg = (decimal)reader["LeyMH_FinishAg"],
                Modified_Date = (DateTime)reader["Modified_Date"]
            };
        }

        private InternalCtrlDetailsConsume MapToInternalCtrlDetailsConsume(SqlDataReader reader)
        {
            return new InternalCtrlDetailsConsume()
            {
                ConsuH_ID = (int)reader["ConsuH_ID"],
                LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                ConsuH_ReacNaCN = (decimal)reader["ConsuH_ReacNaCN"],
                ConsuH_ReacNaOH = (decimal)reader["ConsuH_ReacNaOH"],
                ConsuH_CuPorc = (decimal)reader["ConsuH_CuPorc"],
                Modified_Date = (DateTime)reader["Modified_Date"]
            };
        }

        private InternalCtrlDetailsRecovery MapToInternalCtrlDetailsRecovery(SqlDataReader reader)
        {
            return new InternalCtrlDetailsRecovery()
            {
                RecovH_ID = (int)reader["RecovH_ID"],
                LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                RecovH_AuRecovCalc = (decimal)reader["RecovH_AuRecovCalc"],
                RecovH_AuMg48_Tot = (decimal)reader["RecovH_AuMg48_Tot"],
                RecovH_AuMg72_Tot = (decimal)reader["RecovH_AuMg72_Tot"],
                RecovH_AgRecovCalc = (decimal)reader["RecovH_AgRecovCalc"],
                RecovH_AgMg48_Tot = (decimal)reader["RecovH_AgMg48_Tot"],
                RecovH_AgMg72_Tot = (decimal)reader["RecovH_AgMg72_Tot"],
                Modified_Date = (DateTime)reader["Modified_Date"]
            };
        }

        // POST: api/InternalCtrl/AddPuruna
        public int AddPuruna(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrlPuruna_Add";
                
                cmd.Parameters.Add(new SqlParameter("@Option", obj["option"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID", obj["intCtrlH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_SampWeig", obj["intCtrlD_SampWeig"].ToObject<string>().Equals("") ? (object)DBNull.Value: obj["intCtrlD_SampWeig"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_LeyAu_Puru", obj["intCtrlD_LeyAu_Puru"].ToObject<string>().Equals("") ? (object)DBNull.Value: obj["intCtrlD_LeyAu_Puru"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_ConsuNaCN_Puru", obj["intCtrlD_ConsuNaCN_Puru"].ToObject<string>().Equals("")?(object)DBNull.Value: obj["intCtrlD_ConsuNaCN_Puru"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_ConsuNaOH_Puru", obj["intCtrlD_ConsuNaOH_Puru"].ToObject<string>().Equals("") ? (object)DBNull.Value : obj["intCtrlD_ConsuNaOH_Puru"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_Recov_Puru", obj["intCtrlD_Recov_Puru"].ToObject<string>().Equals("") ? (object)DBNull.Value : obj["intCtrlD_Recov_Puru"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@User", obj["user"].ToObject<string>()));

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

        // POST: api/InternalCtrl/AddReq
        public int AddReq(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrlReq_Add";

                cmd.Parameters.Add(new SqlParameter("@Option", obj["option"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@AnalType_ID", obj["analType_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_ID", obj["sampOrig_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID", obj["intCtrlH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@User", obj["user"].ToObject<string>()));

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

        // POST: api/InternalCtrl/AddLabExt
        public int AddLabExt(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrlLabExt_Add";

                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID", obj["intCtrlH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@LabExt_ID", obj["labExt_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_AnalInf_NO", obj["intCtrlD_AnalInf_NO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_AnalType_LExt", obj["intCtrlD_AnalType_LExt"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_LeyAu_LExt", obj["intCtrlD_LeyAu_LExt"].ToObject<string>().Equals("") ? (object)DBNull.Value : obj["intCtrlD_LeyAu_LExt"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_LeyAg_LExt", obj["intCtrlD_LeyAg_LExt"].ToObject<string>().Equals("") ? (object)DBNull.Value : obj["intCtrlD_LeyAg_LExt"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtlD_NaCN_LExt", obj["intCtlD_NaCN_LExt"].ToObject<string>().Equals("") ? (object)DBNull.Value : obj["intCtlD_NaCN_LExt"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtlD_NaOH_LExt", obj["intCtlD_NaOH_LExt"].ToObject<string>().Equals("") ? (object)DBNull.Value : obj["intCtlD_NaOH_LExt"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_RecovAu_LExt", obj["intCtrlD_RecovAu_LExt"].ToObject<string>().Equals("") ? (object)DBNull.Value : obj["intCtrlD_RecovAu_LExt"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlD_RecovAg_LExt", obj["intCtrlD_RecovAg_LExt"].ToObject<string>().Equals("") ? (object)DBNull.Value : obj["intCtrlD_RecovAg_LExt"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@User", obj["user"].ToObject<string>()));

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
		
	    // DELETE: api/InternalCtrl/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrl_Delete";
                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID", obj["id"].ToObject<int>()));
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
		
	    // POST: api/InternalCtrl/SearchCommercial/{}
        public List<InternalCtrlHeadCommercial> SearchCommercial(JObject obj)
        {
            var internalCtrlHead = new List<InternalCtrlHeadCommercial>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrlHeadCommercial_Search";
				
		        cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
		        cmd.Parameters.Add(new SqlParameter("@Scales_Lote", obj["numero"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["dateFrom"].ToObject<DateTime>()));
		        cmd.Parameters.Add(new SqlParameter("@Date_To", obj["dateTo"].ToObject<DateTime>()));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        internalCtrlHead.Add(MapToInternalCtrlHeadCommercial(reader));
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetails_GetAll";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID", ich.IntCtrlH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailss.Add(MapToInternalCtrlDetails(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsLeyM_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsLeyMs.Add(MapToInternalCtrlDetailsLeyM(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsConsume_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsConsumes.Add(MapToInternalCtrlDetailsConsume(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsRecovery_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsRecoverys.Add(MapToInternalCtrlDetailsRecovery(dr));
                        }
                    }
                }

                conn.Close();

                return internalCtrlHead;
            }
            catch (Exception e)
            {
                return internalCtrlHead;
                throw e;
            }
        }

        // POST: api/InternalCtrl/SearchCommercialInt/{}
        public List<InternalCtrlHeadCommercial> SearchCommercialInt(JObject obj)
        {
            var internalCtrlHead = new List<InternalCtrlHeadCommercial>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrlHeadCommercial_SearchInt";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_LoteInt", obj["loteInt"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_LabProcTyp", obj["typeAn"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["dateFrom"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["dateTo"].ToObject<DateTime>()));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        internalCtrlHead.Add(MapToInternalCtrlHeadCommercial(reader));
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetails_GetAll";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID", ich.IntCtrlH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailss.Add(MapToInternalCtrlDetails(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsLeyM_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsLeyMs.Add(MapToInternalCtrlDetailsLeyM(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsConsume_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsConsumes.Add(MapToInternalCtrlDetailsConsume(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsRecovery_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsRecoverys.Add(MapToInternalCtrlDetailsRecovery(dr));
                        }
                    }
                }

                conn.Close();

                return internalCtrlHead;
            }
            catch (Exception e)
            {
                return internalCtrlHead;
                throw e;
            }
        }

        // POST: api/InternalCtrl/SearchOperational/{}
        public List<InternalCtrlHeadOperational> SearchOperational(JObject obj)
        {
            var internalCtrlHead = new List<InternalCtrlHeadOperational>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrlHeadOperational_Search";
				
		        cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
		        cmd.Parameters.Add(new SqlParameter("@SampH_NO", obj["numero"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["dateFrom"].ToObject<DateTime>()));
		        cmd.Parameters.Add(new SqlParameter("@Date_To", obj["dateTo"].ToObject<DateTime>()));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        internalCtrlHead.Add(MapToInternalCtrlHeadOperational(reader));
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetails_GetAll";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID", ich.IntCtrlH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailss.Add(MapToInternalCtrlDetails(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsLeyM_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsLeyMs.Add(MapToInternalCtrlDetailsLeyM(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsConsume_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsConsumes.Add(MapToInternalCtrlDetailsConsume(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsRecovery_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsRecoverys.Add(MapToInternalCtrlDetailsRecovery(dr));
                        }
                    }
                }

                conn.Close();

                return internalCtrlHead;
            }
            catch (Exception e)
            {
                return internalCtrlHead;
                throw e;
            }
        }

        // POST: api/InternalCtrl/SearchOperationalInt/{}
        public List<InternalCtrlHeadOperational> SearchOperationalInt(JObject obj)
        {
            var internalCtrlHead = new List<InternalCtrlHeadOperational>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrlHeadOperational_SearchInt";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_LoteInt", obj["loteInt"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_LabProcTyp", obj["typeAn"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["dateFrom"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["dateTo"].ToObject<DateTime>()));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        internalCtrlHead.Add(MapToInternalCtrlHeadOperational(reader));
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetails_GetAll";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID", ich.IntCtrlH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailss.Add(MapToInternalCtrlDetails(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsLeyM_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsLeyMs.Add(MapToInternalCtrlDetailsLeyM(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsConsume_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsConsumes.Add(MapToInternalCtrlDetailsConsume(dr));
                        }
                    }
                }

                cmd.CommandText = "[CM].InternalCtrlDetailsRecovery_Get";

                foreach (var ich in internalCtrlHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", ich.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ich.InternalCtrlDetailsRecoverys.Add(MapToInternalCtrlDetailsRecovery(dr));
                        }
                    }
                }

                conn.Close();

                return internalCtrlHead;
            }
            catch (Exception e)
            {
                return internalCtrlHead;
                throw e;
            }
        }

        private InternalCtrlHeadOperational MapToInternalCtrlHeadOperational(SqlDataReader reader)
        {
            return new InternalCtrlHeadOperational()
            {
                IntCtrlH_ID = (int)reader["IntCtrlH_ID"],
                SampH_ID = (int)reader["SampH_ID"],
                Company_ID = (int)reader["Company_ID"],
                IntCtrlH_Current_Detail = (int)reader["IntCtrlH_Current_Detail"],
                SampH_Current_Detail = (int)reader["SampH_Current_Detail"],
		        SampH_NO = reader["SampH_NO"].ToString(),
		        SampH_Refer = reader["SampH_Refer"].ToString(),
		        SampH_Desc = reader["SampH_Desc"].ToString(),
		        SampOrig_ID = (int)reader["SampOrig_ID"],
                SampOrig_Desc = reader["SampOrig_Desc"].ToString(),
		        SampOrig_AreaDesc = reader["SampOrig_AreaDesc"].ToString(),
                AnalType_ID = (int)reader["AnalType_ID"],
                AnalType_Desc = reader["AnalType_Desc"].ToString(),
		        LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                LabProcTyp_Name = reader["LabProcTyp_Name"].ToString(),
		        MatType_ID = (int)reader["MatType_ID"],
                MatType_Name = reader["MatType_Name"].ToString(),
		        SampD_Weight = (decimal)reader["SampD_Weight"],
                SampD_Date = (DateTime)reader["SampD_Date"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                IntCtrlH_Status = reader["IntCtrlH_Status"].ToString(),
		        LeyMH_FinishAu = reader["LeyMH_FinishAu"]==DBNull.Value?(decimal?)null:(decimal)reader["LeyMH_FinishAu"],
		        SampH_Status_Cod = reader["SampH_Status_Cod"].ToString()
            };
        }

        //PUT: api/InternalCtrl/Approve/{}
        public int Approve(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].InternalCtrl_Approve";
                //Detail
                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ID",obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@IntCtrlH_ApprUser", obj["user"].ToObject<string>()));
                //cmd.Parameters.Add(new SqlParameter("@Action", obj["action"].ToObject<string>()));
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
