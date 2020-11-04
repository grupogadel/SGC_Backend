using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.CM.DataMaster.Commercial;
using SGC.Entities.Entities.CM.Laboratory;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.CM.Laboratory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.Laboratory
{
    public class ServiceSampleLaboratory : IServiceSampleLaboratory
    {
        private readonly string _context;
 
        public ServiceSampleLaboratory(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        public async Task<List<LaboratoryRecep>> Search(JObject obj)
        {
            var response = new List<LaboratoryRecep>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].LaboratoryRecep_Search";
                bool rank = false;
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
                        response.Add(MapToSampleLaboratory2(reader));
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
        public static string GetNullableString(SqlDataReader reader, string fieldName)
        {
            if (reader[fieldName] == DBNull.Value)
            {
                return "";
            }
            return reader[fieldName].ToString();
        }

        public static int? GetNullableInt(SqlDataReader reader, string fieldName)
        {
            if (reader[fieldName] == DBNull.Value)
            {
                return 0;
            }
            return (int)reader[fieldName];
        }

        private SampleHeadLaboratory MapToSampleLaboratory(SqlDataReader reader)
        {
            return new SampleHeadLaboratory()
            {
                SampH_ID = (int)reader["SampH_ID"],
                BatchM_ID = GetNullableInt(reader, "BatchM_ID"),
                //BatchM_ID = (int)reader["BatchM_ID"],
                Company_ID = (int)reader["Company_ID"],
                SampH_NO = reader["SampH_NO"].ToString(),
                SampH_Type = reader["SampH_Type"].ToString(),
                SampH_Desc = reader["SampH_Desc"].ToString(),
                SampH_Refer = reader["SampH_Refer"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                SampH_Status_Cod= reader["SampH_Status_Cod"].ToString(),
                SampH_Status = reader["SampH_Status"].ToString(),
                BatchMinerals = new BatchMineral
                {
                    BatchM_ID= (int)reader["BatchM_ID"],
                    BatchM_Lote_New= reader["BatchM_Lote_New"].ToString()
                },
                SampleDetailsLaboratorys = new SampleDetailsLaboratory
                {
                    SampD_ID = (int)reader["SampD_ID"],
                    SampH_ID = (int)reader["SampH_ID"],
                    SampD_NO = reader["SampD_NO"].ToString(),
                    LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                    AnalType_ID = (int)reader["AnalType_ID"],
                    SampOrig_ID = (int)reader["SampOrig_ID"],
                    MatType_ID = (int)reader["MatType_ID"],
                    MinFrom_ID = (int)reader["MinFrom_ID"],
                    Creation_User = reader["Creation_User"].ToString(),
                    Creation_Date = (DateTime)reader["Creation_Date"],
                    Modified_User = reader["Modified_User"].ToString(),
                    Modified_Date = (DateTime)reader["Modified_Date"],

                    LabProcessType = new LabProcessType
                    {
                        LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                        LabProcTyp_Cod = reader["LabProcTyp_Cod"].ToString(),
                        LabProcTyp_Name = reader["LabProcTyp_Name"].ToString(),
                        LabProcTyp_Desc = reader["LabProcTyp_Desc"].ToString(),
                    },

                    AnalisysType = new AnalisysType
                    {
                        AnalType_ID = (int)reader["AnalType_ID"],
                        AnalType_Cod = reader["AnalType_Cod"].ToString(),
                        AnalType_Desc = reader["AnalType_Desc"].ToString(),
                    },

                    SampleOrigin = new SampleOrigin
                    {
                        SampOrig_ID = (int)reader["SampOrig_ID"],
                        SampOrig_AreaCod = reader["SampOrig_AreaCod"].ToString(),
                        SampOrig_Cod = reader["SampOrig_Cod"].ToString(),
                        SampOrig_Module = reader["SampOrig_Module"].ToString(),
                        SampOrig_AreaDesc = reader["SampOrig_AreaDesc"].ToString(),
                        SampOrig_Desc = reader["SampOrig_Desc"].ToString(),
                        SampOrig_ExgTab = (bool)reader["SampOrig_ExgTab"],
                    },

                    MaterialType = new MaterialType
                    {
                        MatType_ID = (int)reader["MatType_ID"],
                        MatType_Cod = reader["MatType_Cod"].ToString(),
                        MatType_Name = reader["MatType_Name"].ToString(),
                        MatType_Desc = reader["MatType_Desc"].ToString(),
                    },

                    MineralFrom = new MineralFrom
                    {
                        MinFrom_ID = (int)reader["MinFrom_ID"],
                        MinFrom_Cod = reader["MinFrom_Cod"].ToString(),
                        MinFrom_Name = reader["MinFrom_Name"].ToString(),
                        MinFrom_Desc = reader["MinFrom_Desc"].ToString(),
                    }
                }

            };
        }



        public async Task<List<SampleOriginArea>> GetAllArea(int idCompany)
        {
            var response = new List<SampleOriginArea>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].SampleOriginArea_GetAll";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToSampleOriginArea(reader));
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

        private SampleOriginArea MapToSampleOriginArea(SqlDataReader reader)
        {
            return new SampleOriginArea()
            {
                SampOrig_AreaCod = reader["SampOrig_AreaCod"].ToString(),
                SampOrig_Area = reader["SampOrig_AreaDesc"].ToString(),

            };
        }

        public async Task<List<SampleHeadLaboratory>> GetAll(int id)
        {
            var response = new List<SampleHeadLaboratory>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleHeadLaboratory_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", id));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToSampleLaboratory(reader));
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

        public int Add(LaboratoryRecepcion model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].LaboratoryRecep_Add";
                cmd.Parameters.Add(new SqlParameter("@SampD_RecLab_Date", model.SampD_RecLab_Date));
                cmd.Parameters.Add(new SqlParameter("@SampD_RecLab_Oper", model.SampD_RecLab_Oper));
                //Details
                var param = new SqlParameter("@lstSamples", SqlDbType.Structured);
                param.TypeName = "dbo.RecepLab";
                param.Value = GetSamples(model.LstSamples);
                cmd.Parameters.Add(param);

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

        private DataTable GetSamples(List<int> lstSamples)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Sample_Id", typeof(int));
            foreach (int idSample in lstSamples)
                dt.Rows.Add(idSample);
            return dt;
        }

        public int Update(SampleDetailsLaboratory model)
        {
            throw new NotImplementedException();
        }

        public int Delete(JObject obj)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LaboratoryRecep>> GetAll2(int id)
        {
            var response = new List<LaboratoryRecep>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleHeadLaboratory_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", id));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToSampleLaboratory2(reader));
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

        private LaboratoryRecep MapToSampleLaboratory2(SqlDataReader reader)
        {
            return new LaboratoryRecep()
            {
                SampH_ID = (int)reader["SampH_ID"],
                Company_ID = (int)reader["Company_ID"],
                BatchM_ID = GetNullableInt(reader, "BatchM_ID"),
                SampH_Current_Detail = (int)reader["SampH_Current_Detail"],
                SampH_NO = GetNullableString(reader, "SampH_NO"),
                SampH_Type = reader["SampH_Type"].ToString(),
                SampH_Desc = GetNullableString(reader, "SampH_Desc"),
                SampH_Refer = GetNullableString(reader, "SampH_Refer"),
                SampH_Status_Cod = GetNullableString(reader, "SampH_Status_Cod"),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Creation_Date"],
                SampH_Status = reader["SampH_Status"].ToString(),

                SampD_ID = (int)reader["SampD_ID"],
                SampD_NO = GetNullableString(reader, "SampD_NO"),
                //LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                LabProcTyp_ID = GetNullableInt(reader, "LabProcTyp_ID"),
                //AnalType_ID = (int)reader["AnalType_ID"],
                AnalType_ID = GetNullableInt(reader, "AnalType_ID"),
                //SampOrig_ID = (int)reader["SampOrig_ID"],
                SampOrig_ID = GetNullableInt(reader, "SampOrig_ID"),
                //MatType_ID = (int)reader["MatType_ID"],
                MatType_ID = GetNullableInt(reader, "MatType_ID"),
                //MinFrom_ID = (int)reader["MinFrom_ID"],
                MinFrom_ID = GetNullableInt(reader,"MinFrom_ID"),
                //LabProcTyp_Cod = reader["LabProcTyp_Cod"].ToString(),
                Modified_DateDet = (DateTime)reader["Modified_DateDet"],

                LabProcTyp_Cod = GetNullableString(reader, "LabProcTyp_Cod"),
                LabProcTyp_Name = GetNullableString(reader, "LabProcTyp_Name"),
                LabProcTyp_Desc = GetNullableString(reader, "LabProcTyp_Desc"),
                AnalType_Cod = GetNullableString(reader, "AnalType_Cod"),
                AnalType_Desc = GetNullableString(reader, "AnalType_Desc"),
                MinFrom_Cod = GetNullableString(reader, "MinFrom_Cod"),
                MinFrom_Name = GetNullableString(reader, "MinFrom_Name"),
                MinFrom_Desc = GetNullableString(reader, "MinFrom_Desc"),
                MatType_Cod = GetNullableString(reader, "MatType_Cod"),
                MatType_Name = GetNullableString(reader, "MatType_Name"),
                MatType_Desc = GetNullableString(reader, "MatType_Desc"),
                SampOrig_AreaCod = GetNullableString(reader, "SampOrig_AreaCod"),
                SampOrig_AreaDesc = GetNullableString(reader, "SampOrig_AreaDesc"),
                SampOrig_Cod = GetNullableString(reader, "SampOrig_Cod"),
                SampOrig_Module = GetNullableString(reader, "SampOrig_Module"),
                SampOrig_Desc = GetNullableString(reader, "SampOrig_Desc"),
                SampD_RecLab_Date = reader["SampD_RecLab_Date"] == DBNull.Value ? default(DateTime?) : (DateTime)reader["SampD_RecLab_Date"],
                SampD_RecLab_Oper= GetNullableString(reader, "SampD_RecLab_Oper"),
                //BatchM_TMSHist = reader["BatchM_TMSHist"] == DBNull.Value ? (decimal?)null : (decimal)reader["BatchM_TMSHist"],
                //SampD_RecLab_Date = (DateTime)reader["SampD_RecLab_Date"],
                SampD_Status = reader["SampD_Status"].ToString(),
                BatchM_Lote_New = GetNullableString(reader, "BatchM_Lote_New"),
                Scales_ID = GetNullableInt(reader, "Scales_ID"),
                AnalReq_ID = GetNullableInt(reader, "AnalReq_ID"),
                AnalReq_Desc = GetNullableString(reader, "AnalReq_Desc"),
            };
        }

    }
}
