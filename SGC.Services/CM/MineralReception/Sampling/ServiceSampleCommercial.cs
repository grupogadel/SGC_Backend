using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.CM.DataMaster.Commercial;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.CM.MineralReception.Sampling;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.CM.MineralReception.Sampling;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.MineralReception.Sampling
{
    public class ServiceSampleCommercial: IServiceSampleCommercial
    {
        private readonly string _context;
        public ServiceSampleCommercial(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/SampleCommercial/GetAll/1
        public List<SampleHeadCommercial> GetAll(int idCompany)
        {
            var sampleHead = new List<SampleHeadCommercial>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleHeadCommercial_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sampleHead.Add(MapToSampleHeadCommercial(reader));
                    }
                }

                cmd.CommandText = "[CM].SampleDetailsCommercial_GetAll";

                foreach (var sh in sampleHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", sh.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            sh.SampleDetailsCommercials.Add(MapToSampleDetailsCommercial(dr));
                        }
                    }
                }
                conn.Close();

                return sampleHead;
            }
            catch (Exception e)
            {
                return sampleHead;
                throw e;
            }
        }

        private SampleHeadCommercial MapToSampleHeadCommercial(SqlDataReader reader)
        {
            return new SampleHeadCommercial()
            {
                SampH_ID = (int)reader["SampH_ID"],
                BatchM_ID = (int)reader["BatchM_ID"],
                Company_ID = (int)reader["Company_ID"],
                SampH_NO = reader["SampH_NO"].ToString(),
                SampH_Type = reader["SampH_Type"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                BatchMinerals = new BatchMineral {
                    Scales = new Scales {
                        Scales_ID = (int)reader["Scales_ID"],
                        Scales_Lote = reader["Scales_Lote"].ToString(),
                        Scales_TMH = (int)reader["Scales_TMH"],
                        Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                        MinType_ID = (int)reader["MinType_ID"],
                        MineralTypes = new MineralsType { 
                            MinType_Desc = reader["MinType_Desc"].ToString()
                        },
                        Orig_ID = (int)reader["Orig_ID"],
                        Origins = new Origin { 
                            Orig_Name = reader["Orig_Name"].ToString(),
                            Zone_ID = (int)reader["Zone_ID"],
                            Zones = new Zone {
                                Zone_Name = reader["Zone_Name"].ToString()
                            }
                        }
                    }
                },
                SampH_Status_Cod = reader["SampH_Status_Cod"].ToString(),
                SampH_Status = reader["SampH_Status"].ToString()
            };
        }

        private SampleDetailsCommercial MapToSampleDetailsCommercial(SqlDataReader reader)
        {
            return new SampleDetailsCommercial()
            {
                SampD_ID = (int)reader["SampD_ID"],
                SampH_ID = (int)reader["SampH_ID"],
                LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                AnalType_ID = (int)reader["AnalType_ID"],
                SampOrig_ID = (int)reader["SampOrig_ID"],
                MatType_ID = (int)reader["MatType_ID"],
                SampD_Weight = (decimal)reader["SampD_Weight"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                SampD_Status = reader["SampD_Status"].ToString(),
                LabProcessTypes = new LabProcessType { 
                    LabProcTyp_Name = reader["LabProcTyp_Name"].ToString(),
                    LabProcTyp_Desc = reader["LabProcTyp_Desc"].ToString()
                },
                AnalisysTypes = new AnalisysType{
                    AnalType_Desc = reader["AnalType_Desc"].ToString()
                },
                SampleOrigins = new SampleOrigin{
                    SampOrig_AreaDesc = reader["SampOrig_AreaDesc"].ToString(),
                    SampOrig_Desc = reader["SampOrig_Desc"].ToString()
                },
                MaterialTypes = new MaterialType{
                    MatType_Name = reader["MatType_Name"].ToString()
                }
            };
        }

        // POST: api/SampleCommercial/Add
        public int Add(SampleDetailsCommercial model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleCommercial_Add";
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", model.SampH_ID));
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_ID", model.LabProcTyp_ID));
                cmd.Parameters.Add(new SqlParameter("@AnalType_ID", model.AnalType_ID));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_ID", model.SampOrig_ID));
                cmd.Parameters.Add(new SqlParameter("@MatType_ID", model.MatType_ID));
                cmd.Parameters.Add(new SqlParameter("@SampD_Weight", model.SampD_Weight));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));

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

        // PUT: api/SampleCommercial/Update
        public int Update(SampleDetailsCommercial model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleCommercial_Update";
                cmd.Parameters.Add(new SqlParameter("@SampD_ID", model.SampD_ID));
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", model.SampH_ID));
                cmd.Parameters.Add(new SqlParameter("@AnalType_ID", model.AnalType_ID));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_ID", model.SampOrig_ID));
                cmd.Parameters.Add(new SqlParameter("@MatType_ID", model.MatType_ID));
                cmd.Parameters.Add(new SqlParameter("@SampD_Weight", model.SampD_Weight));
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

        // DELETE: api/SampleCommercial/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleCommercial_Delete";
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", obj["id"].ToObject<int>()));
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
    }
}
