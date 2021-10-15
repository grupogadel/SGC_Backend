
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.CM.InternalControl;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.CM.InternalControl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;   
using Newtonsoft.Json.Linq;

namespace SGC.Services.CM.InternalControl
{
    public class ServiceSampleHeadOperational : IServiceSampleHeadOperational
    {
        private readonly string _context;

        public ServiceSampleHeadOperational(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int Add(SampleHeadOperational model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleOperational_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@SampH_Refer", model.SampH_Refer));
                cmd.Parameters.Add(new SqlParameter("@SampH_Desc", model.SampH_Desc));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_ID", model.SampleDetailsOperational.SampOrig_ID));
                cmd.Parameters.Add(new SqlParameter("@MatType_ID", model.SampleDetailsOperational.MatType_ID));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_ID", model.SampleDetailsOperational.MinFrom_ID));
                cmd.Parameters.Add(new SqlParameter("@AnalType_ID", model.SampleDetailsOperational.AnalType_ID));
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_ID", model.SampleDetailsOperational.LabProcTyp_ID));
                cmd.Parameters.Add(new SqlParameter("@SampD_NO", model.SampleDetailsOperational.SampD_NO));
                cmd.Parameters.Add(new SqlParameter("@SampD_Weight", model.SampleDetailsOperational.SampD_Weight));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_Module", model.SampOrig_Module));

                cmd.Parameters.Add(new SqlParameter("@Creation_Date", model.Creation_Date));
                cmd.Parameters.Add(new SqlParameter("Creation_User", model.Creation_User));

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

        // PUT: api/SampleHeadOperational/Update/1
        public int Update(SampleHeadOperational model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleOperational_Update";
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", model.SampH_ID));
                cmd.Parameters.Add(new SqlParameter("@SampD_ID", model.SampleDetailsOperational.SampD_ID));
                cmd.Parameters.Add(new SqlParameter("@SampH_Refer", model.SampH_Refer));
                cmd.Parameters.Add(new SqlParameter("@SampH_Desc", model.SampH_Desc));
                cmd.Parameters.Add(new SqlParameter("@MatType_ID", model.SampleDetailsOperational.MatType_ID));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_ID", model.SampleDetailsOperational.MinFrom_ID));
                cmd.Parameters.Add(new SqlParameter("@AnalType_ID", model.SampleDetailsOperational.AnalType_ID));
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_ID", model.SampleDetailsOperational.LabProcTyp_ID));
                cmd.Parameters.Add(new SqlParameter("@SampD_Weight", model.SampleDetailsOperational.SampD_Weight));
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

        public async Task<List<SampleHeadOperational>> Search(JObject obj)
        {
            var response = new List<SampleHeadOperational>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleOperational_Search";

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
                        response.Add(MapToSampleHeadOperational(reader));
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


        public async Task<Code> GetCode(int id)
        {
            var response = new Code();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[SampleOperational_GetCode]";

                cmd.Parameters.Add(new SqlParameter("@SampH_ID", id));
               
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToSampleHeadOperationalCode(reader);
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

        private SampleHeadOperational MapToSampleHeadOperational(SqlDataReader reader)
        {
            return new SampleHeadOperational()
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
                SampH_Status = reader["SampH_Status"].ToString(),
                SampH_Status_Cod = reader["SampH_Status_Cod"].ToString(),

                SampleDetailsOperational = new SampleDetailsOperational {
                    SampD_ID = (int)reader["SampD_ID"],
                    SampH_ID = (int)reader["SampH_ID"],
                    SampD_NO = reader["SampD_NO"].ToString(),
                    LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                    AnalType_ID = (int)reader["AnalType_ID"],
                    SampOrig_ID = (int)reader["SampOrig_ID"],
                    MatType_ID = (int)reader["MatType_ID"],
                    MinFrom_ID = (int)reader["MinFrom_ID"],
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


        private Code MapToSampleHeadOperationalCode(SqlDataReader reader)
        {
            var code = reader["SampH_NO"].ToString();
            return new Code() { Value = reader["SampH_NO"].ToString() };
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


    }

}
