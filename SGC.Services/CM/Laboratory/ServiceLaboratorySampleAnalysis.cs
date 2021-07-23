
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.CM.Laboratory;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;   
using Newtonsoft.Json.Linq;
using SGC.InterfaceServices.CM.Laboratory;
using System.Data;

namespace SGC.Services.CM.Laboratory
{
    public class ServiceLaboratorySampleAnalysis : IServiceLaboratorySampleAnalysis
    {
        private readonly string _context;

        public ServiceLaboratorySampleAnalysis(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int ChangeStatus(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleOperational_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", obj["sampH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampD_ID", obj["sampD_ID"].ToObject<int>()));
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

        public async Task<List<SampleHead>> Search(JObject obj)
        {
            var response = new List<SampleHead>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Sample_Search";
                bool rank = false;
                DateTime dateTime;

                if (!DateTime.TryParse(obj["date_From"].ToObject<string>(), out dateTime)  && !DateTime.TryParse(obj["date_To"].ToObject<string>(), out dateTime))
                {
                    obj["date_To"] = DateTime.Now;
                    obj["date_From"] = obj["date_To"];
                    rank = false;
                }

                if (obj["date_To"].ToObject<DateTime>() == obj["date_From"].ToObject<DateTime>()) rank = false;
                else rank = true;

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_NO", obj["sampH_NO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["date_To"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["date_From"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_AreaCod", obj["sampOrig_AreaCod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Rank", rank));


                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToSampleHead(reader));
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

        public async Task<int> Add(JObject obj)
        {
            try
            {
                LeyMineralHead model = new LeyMineralHead();
                model = obj["leyMineral"].ToObject<LeyMineralHead>();
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[LeyMineral_Add]";
                //SampleDetail
                cmd.Parameters.Add(new SqlParameter("@SampD_ID", obj["sampD_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@LabS_ID", obj["labS_ID"].ToObject<int>()));
                //Head
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@LeyMH_FinishAu", model.LeyMH_FinishAu));
                cmd.Parameters.Add(new SqlParameter("@LeyMH_FinishAg", model.LeyMH_FinishAg));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                SqlParameter parLeyMineralDetail = GetLeyMineralDetail("tabLeyMineralDetail", model.LeyMineralDetail);
                cmd.Parameters.Add(parLeyMineralDetail);
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

        public async Task<int> UpdateResults(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].LeyMineral_UpdatResults";
                cmd.Parameters.Add(new SqlParameter("@LeyMH_FinishAu", obj["leyMH_FinishAu"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@LeyMH_FinishAg", obj["leyMH_FinishAg"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Id", obj["id"].ToObject<int>()));
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

        public async Task<int> AddDetails(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[LeyMineral_AddDetails]";
                cmd.Parameters.Add(new SqlParameter("@LeyMH_ID", obj["leyMH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", obj["creation_User"].ToObject<string>()));
                SqlParameter parLeyMineralDetail = GetLeyMineralDetail("tabLeyMineralDetail", obj["leyMineralDetail"].ToObject<List<LeyMineralDetail>>());
                cmd.Parameters.Add(parLeyMineralDetail); 
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

        public LeyMineralHead Get(int id)
        {
            try
            {
                var response = new LeyMineralHead();
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].LeyMineral_Get";
                cmd.Parameters.Add(new SqlParameter("@LeyMH_ID", id));

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToLeyMineralHead(reader);
                    }
                }
                conn.Close();
                response.LeyMineralDetail = GetDetails(id);
                return response;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        public  List<LeyMineralDetail> GetDetails(int leyMH_ID)
        {
            var response = new List<LeyMineralDetail>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].LeyMineral_GetDetails";

                cmd.Parameters.Add(new SqlParameter("@LeyMH_ID", leyMH_ID));

                conn.Open();
                using (var reader =  cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Add(MapToLeyMineralDetail(reader));
                    }
                }
                conn.Close();
                return response;
            }
            catch (Exception e)
            {
                return response;
                throw e;
            }
        }

        public int RemoveItem(JObject obj)
        {
            try
            {
                var detailsRemoved = new List<LeyMineralDetail>();
                detailsRemoved = obj["detailsRemoved"].ToObject<List<LeyMineralDetail>>();
                for (int i = 0; i < detailsRemoved.Count; i++)
                {
                    if (detailsRemoved[i].LeyMD_ID != 0)
                       Remove(detailsRemoved[i].LeyMD_ID, obj["user"].ToObject<string>());
                }
                return 0;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
            
        private LeyMineralHead MapToLeyMineralHead(SqlDataReader reader)
        {
            return new LeyMineralHead()
            {
                LeyMH_ID = (int)reader["LeyMH_ID"],
                Company_ID = (int)reader["Company_ID"],
                LeyMH_FinishAu = (decimal)reader["LeyMH_FinishAu"],
                LeyMH_FinishAg = (decimal)reader["LeyMH_FinishAg"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                LeyMH_Status = reader["LeyMH_Status"].ToString(),
            };
        }

        private ConsumeHead MapToConsumeHead(SqlDataReader reader)
        {
            return new ConsumeHead()
            {
                ConsuH_ID = (int)reader["ConsuH_ID"],
                Company_ID = (int)reader["Company_ID"],
                ConsuH_ReacNaCN = (decimal)reader["ConsuH_ReacNaCN"],
                ConsuH_ReacNaOH = (decimal)reader["ConsuH_ReacNaOH"],
                ConsuH_Status = reader["ConsuH_Status"].ToString(),

                ConsumeDetail = new ConsumeDetail {

                    ConsuD_ID = (int)reader["ConsuD_ID"],
                    LabS_ID = (int)reader["LabS_ID"],
                    ConsuD_CNLixHrs0 = (decimal)reader["ConsuD_CNLixHrs0"],
                    ConsuD_CNLixHrs2 = (decimal)reader["ConsuD_CNLixHrs2"],
                    ConsuD_CNLixHrs4 = (decimal)reader["ConsuD_CNLixHrs4"],
                    ConsuD_CNLixHrs8 = (decimal)reader["ConsuD_CNLixHrs8"],
                    ConsuD_CNLixHrs12 = (decimal)reader["ConsuD_CNLixHrs12"],
                    ConsuD_CNLixHrs24 = (decimal)reader["ConsuD_CNLixHrs24"],
                    ConsuD_CNLixHrs48 = (decimal)reader["ConsuD_CNLixHrs48"],
                    ConsuD_CNLixHrs72 = (decimal)reader["ConsuD_CNLixHrs72"],
                    ConsuD_PHLixHrs0 = (decimal)reader["ConsuD_PHLixHrs0"],
                    ConsuD_PHLixHrs2 = (decimal)reader["ConsuD_PHLixHrs2"],
                    ConsuD_PHLixHrs4 = (decimal)reader["ConsuD_PHLixHrs4"],
                    ConsuD_PHLixHrs8 = (decimal)reader["ConsuD_PHLixHrs8"],
                    ConsuD_PHLixHrs12 = (decimal)reader["ConsuD_PHLixHrs12"],
                    ConsuD_PHLixHrs24 = (decimal)reader["ConsuD_PHLixHrs24"],
                    ConsuD_PHLixHrs48 = (decimal)reader["ConsuD_PHLixHrs48"],
                    ConsuD_PHLixHrs72 = (decimal)reader["ConsuD_PHLixHrs72"],
                    ConsuD_OHLixReacAgr0 = (decimal)reader["ConsuD_OHLixReacAgr0"],
                    ConsuD_OHLixReacAgr2 = (decimal)reader["ConsuD_OHLixReacAgr2"],
                    ConsuD_OHLixReacAgr4 = (decimal)reader["ConsuD_OHLixReacAgr4"],
                    ConsuD_OHLixReacAgr8 = (decimal)reader["ConsuD_OHLixReacAgr8"],
                    ConsuD_OHLixReacAgr12 = (decimal)reader["ConsuD_OHLixReacAgr12"],
                    ConsuD_OHLixReacAgr24 = (decimal)reader["ConsuD_OHLixReacAgr24"],
                    ConsuD_OHLixReacAgr48 = (decimal)reader["ConsuD_OHLixReacAgr48"],
                    ConsuD_OHLixReacAgr72 = (decimal)reader["ConsuD_OHLixReacAgr72"],
                    ConsuD_CNLLixReacAgr0 = (decimal)reader["ConsuD_CNLLixReacAgr0"],
                    ConsuD_CNLLixReacAgr2 = (decimal)reader["ConsuD_CNLLixReacAgr2"],
                    ConsuD_CNLLixReacAgr4 = (decimal)reader["ConsuD_CNLLixReacAgr4"],
                    ConsuD_CNLLixReacAgr8 = (decimal)reader["ConsuD_CNLLixReacAgr8"],
                    ConsuD_CNLLixReacAgr12 = (decimal)reader["ConsuD_CNLLixReacAgr12"],
                    ConsuD_CNLLixReacAgr24 = (decimal)reader["ConsuD_CNLLixReacAgr24"],
                    ConsuD_CNLLixReacAgr48 = (decimal)reader["ConsuD_CNLLixReacAgr48"],
                    ConsuD_CNLLixReacAgr72 = (decimal)reader["ConsuD_CNLLixReacAgr72"],
                    ConsuD_Status = reader["ConsuD_Status"].ToString(),
                }
            };
        }

        private LeyMineralDetail MapToLeyMineralDetail(SqlDataReader reader)
        {
            return new LeyMineralDetail()
            {
                LeyMD_ID = (int)reader["LeyMD_ID"],
                LeyMH_ID = (int)reader["LeyMH_ID"],
                LeyMD_BK = (decimal)reader["LeyMD_BK"],
                LeyMD_PMFino = (decimal)reader["LeyMD_PMFino"],
                LeyMD_PMGrueso = (decimal)reader["LeyMD_PMGrueso"],
                LeyMD_PesoAu_Ag = (decimal)reader["LeyMD_PesoAu_Ag"],
                LeyMD_AuFino1 = (decimal)reader["LeyMD_AuFino1"],
                LeyMD_AuFino2 = (decimal)reader["LeyMD_AuFino2"],
                LeyMD_AuGrueso = (decimal)reader["LeyMD_AuGrueso"],
                LeyMD_OzTcAuFino = (decimal)reader["LeyMD_OzTcAuFino"],
                LeyMD_OzTcAuGrueso = (decimal)reader["LeyMD_OzTcAuGrueso"],
                LeyMD_OzTcAuFinal = (decimal)reader["LeyMD_OzTcAuFinal"],
                LeyMD_OzTcAgFinal = (decimal)reader["LeyMD_OzTcAgFinal"],
                LeyMD_GrTnAuFinal = reader["LeyMD_GrTnAuFinal"] == DBNull.Value ? new decimal?() : (decimal)reader["LeyMD_GrTnAuFinal"],
                LeyMD_GrTnAgFinal = reader["LeyMD_GrTnAgFinal"] == DBNull.Value ? new decimal?() : (decimal)reader["LeyMD_GrTnAgFinal"],
                LeyMD_PorcAuFino = (decimal)reader["LeyMD_PorcAuFino"],
                LeyMD_PorcAuGrueso = (decimal)reader["LeyMD_PorcAuGrueso"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                LeyMD_Status = reader["LeyMD_Status"].ToString(),
            };
        }

        public SqlParameter GetLeyMineralDetail(string name, List<LeyMineralDetail> listLeyMinerlaDetails)
        {
            try
            {
                DataTable table = new DataTable("dbo.tabLeyMineralDetail");
                table.Columns.Add("LeyMD_BK", typeof(decimal));
                table.Columns.Add("LeyMD_PMFino", typeof(decimal));
                table.Columns.Add("LeyMD_PMGrueso", typeof(decimal));
                table.Columns.Add("LeyMD_PesoAu_Ag", typeof(decimal));
                table.Columns.Add("LeyMD_AuFino1", typeof(decimal));
                table.Columns.Add("LeyMD_AuFino2", typeof(decimal));
                table.Columns.Add("LeyMD_AuGrueso", typeof(decimal));
                table.Columns.Add("LeyMD_OzTcAuFino", typeof(decimal));
                table.Columns.Add("LeyMD_OzTcAuGrueso", typeof(decimal));
                table.Columns.Add("LeyMD_OzTcAuFinal", typeof(decimal));
                table.Columns.Add("LeyMD_OzTcAgFinal", typeof(decimal));
                table.Columns.Add("LeyMD_PorcAuFino", typeof(decimal));
                table.Columns.Add("LeyMD_PorcAuGrueso", typeof(decimal));
              

                foreach (LeyMineralDetail leyDet in listLeyMinerlaDetails)
                    table.Rows.Add(new object[] {   leyDet.LeyMD_BK,
                                                    leyDet.LeyMD_PMFino,
                                                    leyDet.LeyMD_PMGrueso,
                                                    leyDet.LeyMD_PesoAu_Ag,
                                                    leyDet.LeyMD_AuFino1,
                                                    leyDet.LeyMD_AuFino2,
                                                    leyDet.LeyMD_AuGrueso,
                                                    leyDet.LeyMD_OzTcAuFino,
                                                    leyDet.LeyMD_OzTcAuGrueso,
                                                    leyDet.LeyMD_OzTcAuFinal,
                                                    leyDet.LeyMD_OzTcAgFinal,
                                                    leyDet.LeyMD_PorcAuFino,
                                                    leyDet.LeyMD_PorcAuGrueso
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.tabLeyMineralDetail";

                return parameter;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        private SampleHead MapToSampleHead(SqlDataReader reader)
        {
            return new SampleHead()
            {
                SampH_ID = (int)reader["SampH_ID"],
                Company_ID = (int)reader["Company_ID"],
                SampH_NO = reader["SampH_NO"].ToString(),
                SampH_Type = reader["SampH_Type"].ToString(),
                SampH_Desc = reader["SampH_Desc"].ToString(),
                SampH_Refer = reader["SampH_Refer"].ToString(),
                SampOrig_Module = reader["SampOrig_Module"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                SampH_Status_Cod = reader["SampH_Status_Cod"].ToString(),
                SampH_Status = reader["SampH_Status"].ToString(),

                SampleDetails = new SampleDetails {
                    SampD_ID = (int)reader["SampD_ID"],
                    SampH_ID = (int)reader["SampH_ID"],
                    LeyMH_ID = reader["LeyMH_ID"] == DBNull.Value ? new int?() : (int)reader["LeyMH_ID"],
                    ConsuH_ID = reader["ConsuH_ID"] == DBNull.Value ? new int?() : (int)reader["ConsuH_ID"],
                    RecovH_ID = reader["RecovH_ID"] == DBNull.Value ? new int?() : (int)reader["RecovH_ID"],
                    LabS_ID = reader["LabS_ID"] == DBNull.Value ? new int?() : (int)reader["LabS_ID"],
                    MetSet_ID = reader["MetSet_ID"] == DBNull.Value ? new int?() : (int)reader["MetSet_ID"],
                    SampD_NO = reader["SampD_NO"].ToString(),
                    LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                    AnalType_ID = (int)reader["AnalType_ID"],
                    SampOrig_ID = (int)reader["SampOrig_ID"],
                    MatType_ID = (int)reader["MatType_ID"],
                    MinFrom_ID = (int)reader["MinFrom_ID"],
                    SampD_RecLab_Date = (DateTime)reader["SampD_RecLab_Date"],
                    SampD_Weight = (decimal)reader["SampD_Weight"],
                    Creation_User = reader["Creation_User"].ToString(),
                    Creation_Date = (DateTime)reader["Creation_Date"],
                    Modified_User = reader["Modified_User"].ToString(),
                    Modified_Date = (DateTime)reader["Modified_Date"],

                    LabProcessType = new LabProcessType {
                        LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                        LabProcTyp_Cod = reader["LabProcTyp_Cod"].ToString(),
                        LabProcTyp_Name = reader["LabProcTyp_Name"].ToString(),
                        LabProcTyp_Desc = reader["LabProcTyp_Desc"].ToString(),
                    },

                    AnalisysType = new AnalisysType {
                        AnalType_ID = (int)reader["AnalType_ID"],
                        AnalType_Cod = reader["AnalType_Cod"].ToString(),
                        AnalType_Desc = reader["AnalType_Desc"].ToString(),
                    },

                    SampleOrigin = new SampleOrigin {
                        SampOrig_ID = (int)reader["SampOrig_ID"],
                        SampOrig_AreaCod = reader["SampOrig_AreaCod"].ToString(),
                        SampOrig_Cod = reader["SampOrig_Cod"].ToString(),
                        SampOrig_Module = reader["SampOrig_Module"].ToString(),
                        SampOrig_AreaDesc = reader["SampOrig_AreaDesc"].ToString(),
                        SampOrig_Desc = reader["SampOrig_Desc"].ToString(),
                        SampOrig_ExgTab = (bool)reader[ "SampOrig_ExgTab"],
                    },

                    MaterialType = new MaterialType {
                        MatType_ID = (int)reader["MatType_ID"],
                        MatType_Cod = reader["MatType_Cod"].ToString(),
                        MatType_Name = reader["MatType_Name"].ToString(),
                        MatType_Desc = reader["MatType_Desc"].ToString(),
                    },

                    MineralFrom = new MineralFrom {
                        MinFrom_ID = (int)reader["MinFrom_ID"],
                        MinFrom_Cod = reader["MinFrom_Cod"].ToString(),
                        MinFrom_Name = reader["MinFrom_Name"].ToString(),
                        MinFrom_Desc = reader["MinFrom_Desc"].ToString(),
                    }
                }

            };
        }


        public void Remove(int leyMD_ID, string user)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].LeyMineral_RemoveDetails";
                cmd.Parameters.Add(new SqlParameter("@LeyMD_ID", leyMD_ID));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", user));

                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                conn.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ConsumeHead> GetConsume(int id)
        {
            try
            {
                var response = new ConsumeHead();
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Consume_Get";
                cmd.Parameters.Add(new SqlParameter("@ConsuH_ID", id));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToConsumeHead(reader);
                        //response.Add(MapToSampleHead(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        public async Task<int> AddConsume(JObject obj)
        {
            try
            {
                ConsumeHead model = new ConsumeHead();
                model = obj["consumeHerad"].ToObject<ConsumeHead>();
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Consume_Add";

                cmd.Parameters.Add(new SqlParameter("@SampD_ID", obj["sampD_ID"].ToObject<int>()));

                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@ConsuH_ReacNaCN", model.ConsuH_ReacNaCN));
                cmd.Parameters.Add(new SqlParameter("@ConsuH_ReacNaOH", model.ConsuH_ReacNaOH));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));

                cmd.Parameters.Add(new SqlParameter("@LabS_ID", model.ConsumeDetail.LabS_ID));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs0", model.ConsumeDetail.ConsuD_CNLixHrs0));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs2", model.ConsumeDetail.ConsuD_CNLixHrs2));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs4", model.ConsumeDetail.ConsuD_CNLixHrs4));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs8", model.ConsumeDetail.ConsuD_CNLixHrs8));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs12", model.ConsumeDetail.ConsuD_CNLixHrs12));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs24", model.ConsumeDetail.ConsuD_CNLixHrs24));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs48", model.ConsumeDetail.ConsuD_CNLixHrs48));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs72", model.ConsumeDetail.ConsuD_CNLixHrs72));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs0", model.ConsumeDetail.ConsuD_PHLixHrs0));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs2", model.ConsumeDetail.ConsuD_PHLixHrs2));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs4", model.ConsumeDetail.ConsuD_PHLixHrs4));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs8", model.ConsumeDetail.ConsuD_PHLixHrs8));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs12", model.ConsumeDetail.ConsuD_PHLixHrs12));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs24", model.ConsumeDetail.ConsuD_PHLixHrs24));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs48", model.ConsumeDetail.ConsuD_PHLixHrs48));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs72", model.ConsumeDetail.ConsuD_PHLixHrs72));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr0", model.ConsumeDetail.ConsuD_OHLixReacAgr0));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr2", model.ConsumeDetail.ConsuD_OHLixReacAgr2));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr4", model.ConsumeDetail.ConsuD_OHLixReacAgr4));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr8", model.ConsumeDetail.ConsuD_OHLixReacAgr8));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr12", model.ConsumeDetail.ConsuD_OHLixReacAgr12));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr24", model.ConsumeDetail.ConsuD_OHLixReacAgr24));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr48", model.ConsumeDetail.ConsuD_OHLixReacAgr48));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr72", model.ConsumeDetail.ConsuD_OHLixReacAgr72));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr0", model.ConsumeDetail.ConsuD_CNLLixReacAgr0));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr2", model.ConsumeDetail.ConsuD_CNLLixReacAgr2));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr4", model.ConsumeDetail.ConsuD_CNLLixReacAgr4));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr8", model.ConsumeDetail.ConsuD_CNLLixReacAgr8));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr12", model.ConsumeDetail.ConsuD_CNLLixReacAgr12));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr24", model.ConsumeDetail.ConsuD_CNLLixReacAgr24));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr48", model.ConsumeDetail.ConsuD_CNLLixReacAgr48));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr72", model.ConsumeDetail.ConsuD_CNLLixReacAgr72));


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

        public async Task<int> UpdateConsume(ConsumeHead model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Consume_Update";
                cmd.Parameters.Add(new SqlParameter("@ConsuH_ID", model.ConsuH_ID));
                cmd.Parameters.Add(new SqlParameter("@ConsuH_ReacNaCN", model.ConsuH_ReacNaCN));
                cmd.Parameters.Add(new SqlParameter("@ConsuH_ReacNaOH", model.ConsuH_ReacNaOH));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));

                cmd.Parameters.Add(new SqlParameter("@ConsuD_ID", model.ConsumeDetail.ConsuD_ID));
                cmd.Parameters.Add(new SqlParameter("@LabS_ID", model.ConsumeDetail.LabS_ID));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs0", model.ConsumeDetail.ConsuD_CNLixHrs0));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs2", model.ConsumeDetail.ConsuD_CNLixHrs2));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs4", model.ConsumeDetail.ConsuD_CNLixHrs4));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs8", model.ConsumeDetail.ConsuD_CNLixHrs8));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs12", model.ConsumeDetail.ConsuD_CNLixHrs12));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs24", model.ConsumeDetail.ConsuD_CNLixHrs24));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs48", model.ConsumeDetail.ConsuD_CNLixHrs48));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLixHrs72", model.ConsumeDetail.ConsuD_CNLixHrs72));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs0", model.ConsumeDetail.ConsuD_PHLixHrs0));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs2", model.ConsumeDetail.ConsuD_PHLixHrs2));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs4", model.ConsumeDetail.ConsuD_PHLixHrs4));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs8", model.ConsumeDetail.ConsuD_PHLixHrs8));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs12", model.ConsumeDetail.ConsuD_PHLixHrs12));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs24", model.ConsumeDetail.ConsuD_PHLixHrs24));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs48", model.ConsumeDetail.ConsuD_PHLixHrs48));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_PHLixHrs72", model.ConsumeDetail.ConsuD_PHLixHrs72));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr0", model.ConsumeDetail.ConsuD_OHLixReacAgr0));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr2", model.ConsumeDetail.ConsuD_OHLixReacAgr2));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr4", model.ConsumeDetail.ConsuD_OHLixReacAgr4));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr8", model.ConsumeDetail.ConsuD_OHLixReacAgr8));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr12", model.ConsumeDetail.ConsuD_OHLixReacAgr12));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr24", model.ConsumeDetail.ConsuD_OHLixReacAgr24));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr48", model.ConsumeDetail.ConsuD_OHLixReacAgr48));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_OHLixReacAgr72", model.ConsumeDetail.ConsuD_OHLixReacAgr72));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr0", model.ConsumeDetail.ConsuD_CNLLixReacAgr0));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr2", model.ConsumeDetail.ConsuD_CNLLixReacAgr2));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr4", model.ConsumeDetail.ConsuD_CNLLixReacAgr4));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr8", model.ConsumeDetail.ConsuD_CNLLixReacAgr8));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr12", model.ConsumeDetail.ConsuD_CNLLixReacAgr12));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr24", model.ConsumeDetail.ConsuD_CNLLixReacAgr24));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr48", model.ConsumeDetail.ConsuD_CNLLixReacAgr48));
                cmd.Parameters.Add(new SqlParameter("@ConsuD_CNLLixReacAgr72", model.ConsumeDetail.ConsuD_CNLLixReacAgr72));

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

        public async Task<int> AddRecovery(JObject obj)
        {
            try
            {
                RecoveryHead model = new RecoveryHead();
                model = obj["recovery"].ToObject<RecoveryHead>();
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[Recovery_Add]";

                cmd.Parameters.Add(new SqlParameter("@SampD_ID", obj["sampD_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", obj["sampH_ID"].ToObject<int>()));
                //Head
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("RecovH_LeyAuRipio", model.RecovH_LeyAuRipio));
                cmd.Parameters.Add(new SqlParameter("RecovH_LeyAgRipio", model.RecovH_LeyAgRipio));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuHeadTest", model.RecovH_AuHeadTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuTailTest", model.RecovH_AuTailTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuHeadCalc", model.RecovH_AuHeadCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuRecovTest", model.RecovH_AuRecovTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuRecovCalc", model.RecovH_AuRecovCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuHeadMet", model.RecovH_AuHeadMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuSoluMet", model.RecovH_AuSoluMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuTailMet", model.RecovH_AuTailMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgHeadTest", model.RecovH_AgHeadTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgTailTest", model.RecovH_AgTailTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgHeadCalc", model.RecovH_AgHeadCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgRecovTest", model.RecovH_AgRecovTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgRecovCalc", model.RecovH_AgRecovCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgHeadMet", model.RecovH_AgHeadMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgSoluMet", model.RecovH_AgSoluMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgTailMet", model.RecovH_AgTailMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuRecovArtif", model.RecovH_AuRecovArtif));
                cmd.Parameters.Add(new SqlParameter("RecovH_CuRecovCalc", model.RecovH_CuRecovCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuREEDrive", model.RecovH_AuREEDrive));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuHrsAgita", model.RecovH_AuHrsAgita));
                cmd.Parameters.Add(new SqlParameter("RecovH_CuPpm48", model.RecovH_CuPpm48));
                cmd.Parameters.Add(new SqlParameter("RecovH_CuPpm72", model.RecovH_CuPpm72));
                cmd.Parameters.Add(new SqlParameter("RecovH_CuPpm90", model.RecovH_CuPpm90));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                SqlParameter parRecoveryDetail = GetRecoveryDetail("tabRecoveryDetail", model.RecoveryDetail);
                cmd.Parameters.Add(parRecoveryDetail);
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

        public SqlParameter GetRecoveryDetail(string name, List<RecoveryDetail> listRecoveryDetails)
        {
            try
            {
                DataTable table = new DataTable("dbo.tabRecoveryDetail");
                table.Columns.Add("RecovD_ID", typeof(int));
                table.Columns.Add("RecovD_Row", typeof(int));
                table.Columns.Add("RecovD_Type", typeof(string));
                table.Columns.Add("RecovD_Solution_Ppn", typeof(decimal));
                table.Columns.Add("RecovD_Solution_Mg", typeof(decimal));
                table.Columns.Add("RecovD_Desc_Accumul", typeof(decimal));
                table.Columns.Add("RecovD_W3", typeof(decimal));
                table.Columns.Add("RecovD_Total", typeof(decimal));


                foreach (RecoveryDetail Recov in listRecoveryDetails)
                    table.Rows.Add(new object[] {   Recov.RecovD_ID,
                                                    Recov.RecovD_Row,
                                                    Recov.RecovD_Type,
                                                    Recov.RecovD_Solution_Ppn,
                                                    Recov.RecovD_Solution_Mg,
                                                    Recov.RecovD_Desc_Accumul,
                                                    Recov.RecovD_W3,
                                                    Recov.RecovD_Total
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.tabRecoveryDetail";

                return parameter;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        public async Task<RecoveryHead> GetRecovery(int id)
        {
            try
            {
                var  response = new RecoveryHead();
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Recovery_Get";
                cmd.Parameters.Add(new SqlParameter("@RecovH_ID", id));
                

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToRecoveryHead(reader);
                    }
                }
                await conn.CloseAsync();

                response.RecoveryDetail = await GetDetailsRecovery(id);
                return response;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        private RecoveryHead MapToRecoveryHead(SqlDataReader reader)
        {
            return new RecoveryHead()
            {

                RecovH_ID = (int)reader["RecovH_ID"],
                Company_ID = (int)reader["Company_ID"],

                RecovH_LeyAuRipio = (decimal)reader["RecovH_LeyAuRipio"],
                RecovH_LeyAgRipio = (decimal)reader["RecovH_LeyAgRipio"],

                RecovH_AuHeadTest = (decimal)reader["RecovH_AuHeadTest"],
                RecovH_AuTailTest = (decimal)reader["RecovH_AuTailTest"],
                RecovH_AuHeadCalc = (decimal)reader["RecovH_AuHeadCalc"],
                RecovH_AuRecovTest = (decimal)reader["RecovH_AuRecovTest"],
                RecovH_AuRecovCalc = (decimal)reader["RecovH_AuRecovCalc"],
                RecovH_AuHeadMet = (decimal)reader["RecovH_AuHeadMet"],
                RecovH_AuSoluMet = (decimal)reader["RecovH_AuSoluMet"],
                RecovH_AuTailMet = (decimal)reader["RecovH_AuTailMet"],

                RecovH_AgHeadTest = (decimal)reader["RecovH_AgHeadTest"],
                RecovH_AgTailTest = (decimal)reader["RecovH_AgTailTest"],
                RecovH_AgHeadCalc = (decimal)reader["RecovH_AgHeadCalc"],
                RecovH_AgRecovTest = (decimal)reader["RecovH_AgRecovTest"],
                RecovH_AgRecovCalc = (decimal)reader["RecovH_AgRecovCalc"],
                RecovH_AgHeadMet = (decimal)reader["RecovH_AgHeadMet"],
                RecovH_AgSoluMet = (decimal)reader["RecovH_AgSoluMet"],
                RecovH_AgTailMet = (decimal)reader["RecovH_AgTailMet"],

                RecovH_AuRecovArtif = (decimal)reader["RecovH_AuRecovArtif"],
                RecovH_CuRecovCalc = (decimal)reader["RecovH_CuRecovCalc"],
                RecovH_AuREEDrive = (decimal)reader["RecovH_AuREEDrive"],
                RecovH_AuHrsAgita = (decimal)reader["RecovH_AuHrsAgita"],

                RecovH_CuPpm48 = (decimal)reader["RecovH_CuPpm48"],
                RecovH_CuPpm72 = (decimal)reader["RecovH_CuPpm72"],
                RecovH_CuPpm90 = (decimal)reader["RecovH_CuPpm90"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                RecovH_Status = reader["RecovH_Status"].ToString(),
            };
        }
        public async Task<List<RecoveryDetail>> GetDetailsRecovery(int RecovH_ID)
        {
            var response = new List<RecoveryDetail>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Recovery_GetDetails";

                cmd.Parameters.Add(new SqlParameter("@RecovH_ID", RecovH_ID));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToRecoveryDetail(reader));
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

        private RecoveryDetail MapToRecoveryDetail(SqlDataReader reader)
        {
            return new RecoveryDetail()
            {
                RecovD_ID = (int)reader["RecovD_ID"],
                RecovH_ID = (int)reader["RecovH_ID"],
                RecovD_Row = (int)reader["RecovD_Row"],
                RecovD_Type = reader["RecovD_Type"].ToString(),
                RecovD_Solution_Ppn = (decimal)reader["RecovD_Solution_Ppn"],
                RecovD_Solution_Mg = (decimal)reader["RecovD_Solution_Mg"],
                RecovD_Desc_Accumul = (decimal)reader["RecovD_Desc_Accumul"],
                RecovD_W3 = (decimal)reader["RecovD_W3"],
                RecovD_Total = (decimal)reader["RecovD_Total"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                RecovD_Status = reader["RecovD_Status"].ToString(),
            };
        }

        public async Task<int> UpdateRecovery(RecoveryHead model)
        {
            try
            {
               
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[Recovery_Update]";
                //Head
                cmd.Parameters.Add(new SqlParameter("RecovH_ID", model.RecovH_ID));
                cmd.Parameters.Add(new SqlParameter("RecovH_LeyAuRipio", model.RecovH_LeyAuRipio));
                cmd.Parameters.Add(new SqlParameter("RecovH_LeyAgRipio", model.RecovH_LeyAgRipio));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuHeadTest", model.RecovH_AuHeadTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuTailTest", model.RecovH_AuTailTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuHeadCalc", model.RecovH_AuHeadCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuRecovTest", model.RecovH_AuRecovTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuRecovCalc", model.RecovH_AuRecovCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuHeadMet", model.RecovH_AuHeadMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuSoluMet", model.RecovH_AuSoluMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuTailMet", model.RecovH_AuTailMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgHeadTest", model.RecovH_AgHeadTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgTailTest", model.RecovH_AgTailTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgHeadCalc", model.RecovH_AgHeadCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgRecovTest", model.RecovH_AgRecovTest));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgRecovCalc", model.RecovH_AgRecovCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgHeadMet", model.RecovH_AgHeadMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgSoluMet", model.RecovH_AgSoluMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AgTailMet", model.RecovH_AgTailMet));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuRecovArtif", model.RecovH_AuRecovArtif));
                cmd.Parameters.Add(new SqlParameter("RecovH_CuRecovCalc", model.RecovH_CuRecovCalc));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuREEDrive", model.RecovH_AuREEDrive));
                cmd.Parameters.Add(new SqlParameter("RecovH_AuHrsAgita", model.RecovH_AuHrsAgita));
                cmd.Parameters.Add(new SqlParameter("RecovH_CuPpm48", model.RecovH_CuPpm48));
                cmd.Parameters.Add(new SqlParameter("RecovH_CuPpm72", model.RecovH_CuPpm72));
                cmd.Parameters.Add(new SqlParameter("RecovH_CuPpm90", model.RecovH_CuPpm90));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));
                //Details
                SqlParameter parRecoveryDetail = GetRecoveryDetail("tabRecoveryDetail", model.RecoveryDetail);
                cmd.Parameters.Add(parRecoveryDetail);
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

        public int LeyMineralEnd(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].LeyMineral_End";
                cmd.Parameters.Add(new SqlParameter("@LeyMD_ID", obj["leyMD_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["modified_User"].ToObject<string>()));

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

        public int ConsumeEnd (JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Consume_End";
                cmd.Parameters.Add(new SqlParameter("@ConsuH_ID", obj["consuH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["modified_User"].ToObject<string>()));

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

        public int RecoveryEnd(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Recovery_End";
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", obj["sampH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@RecovH_ID", obj["recovH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["modified_User"].ToObject<string>()));

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
