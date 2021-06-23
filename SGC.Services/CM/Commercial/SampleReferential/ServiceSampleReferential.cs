using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.SampleReferential;
using SGC.InterfaceServices.CM.Commercial.SampleReferential;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SGC.Services.CM.Commercial.SampleReferential
{
    public class ServiceSampleReferential: IServiceSampleReferential
    {
        private readonly string _context;
        public ServiceSampleReferential(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // POST: api/SampleReferential/GetAll/{}
        public List<SampleHeadReferential> GetAll(JObject obj)
        {
            var sampleHead = new List<SampleHeadReferential>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleHeadReferential_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@UserAcc_ID", obj["idUserAcc"].ToObject<int>()));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sampleHead.Add(MapToSampleHeadReferential(reader));
                    }
                }

                cmd.CommandText = "[CM].SampleDetailsReferential_GetAll";

                foreach (var sh in sampleHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", sh.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            sh.SampleDetailsReferentials.Add(MapToSampleDetailsReferential(dr));
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

        // POST: api/SampleReferential/GetAllByApprover/{}
        public List<SampleHeadReferential> GetAllByApprover(JObject obj)
        {
            var sampleHead = new List<SampleHeadReferential>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleHeadReferential_GetAllByApprover";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sampleHead.Add(MapToSampleHeadReferential(reader));
                    }
                }

                cmd.CommandText = "[CM].SampleDetailsReferential_GetAll";

                foreach (var sh in sampleHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", sh.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            sh.SampleDetailsReferentials.Add(MapToSampleDetailsReferential(dr));
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

        private SampleHeadReferential MapToSampleHeadReferential(SqlDataReader reader)
        {
            return new SampleHeadReferential()
            {
                SampH_ID = (int)reader["SampH_ID"],
                Company_ID = (int)reader["Company_ID"],
                SampH_Current_Detail = (int)reader["SampH_Current_Detail"],
                SampH_NO = reader["SampH_NO"].ToString(),
                SampH_Type = reader["SampH_Type"].ToString(),
                SampH_Desc = reader["SampH_Desc"].ToString(),
                SampH_Refer = reader["SampH_Refer"].ToString(),
                SampH_Recep_Date = (DateTime)reader["SampH_Recep_Date"],
                Collec_ID = (int)reader["Collec_ID"],
                Person_ID = (int)reader["Person_ID"],
                Person_DNI = reader["Person_DNI"].ToString(),
                Person_Name = reader["Person_Name"].ToString(),
                Person_LastName = reader["Person_LastName"].ToString(),
                UserAcc_ID = (int)reader["UserAcc_ID"],
                SampH_ApprUser = reader["SampH_ApprUser"].ToString(),
                SampH_ApprDate = reader["SampH_ApprDate"] == DBNull.Value? (DateTime?)null: (DateTime) reader["SampH_ApprDate"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                SampH_Status_Cod = reader["SampH_Status_Cod"].ToString(),
                SampH_Status = reader["SampH_Status"].ToString()
            };
        }

        private SampleDetailsReferential MapToSampleDetailsReferential(SqlDataReader reader)
        {
            return new SampleDetailsReferential()
            {
                SampD_ID = (int)reader["SampD_ID"],
                SampH_ID = (int)reader["SampH_ID"],
                LeyMH_ID = reader["LeyMH_ID"] == DBNull.Value ? 0 : (int)reader["LeyMH_ID"],
                LeyMH_FinishAu = reader["LeyMH_FinishAu"] == DBNull.Value ? (decimal?)null : (decimal)reader["LeyMH_FinishAu"],
                LeyMH_FinishAg = reader["LeyMH_FinishAg"] == DBNull.Value ? (decimal?)null : (decimal)reader["LeyMH_FinishAg"],
                SampD_NO = reader["SampD_NO"].ToString(),
                LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                LabProcTyp_Name = reader["LabProcTyp_Name"].ToString(),
                LabProcTyp_Desc = reader["LabProcTyp_Desc"].ToString(),
                AnalType_ID = (int)reader["AnalType_ID"],
                AnalType_Desc = reader["AnalType_Desc"].ToString(),
                SampOrig_ID = (int)reader["SampOrig_ID"],
                SampOrig_AreaDesc = reader["SampOrig_AreaDesc"].ToString(),
                SampOrig_Desc = reader["SampOrig_Desc"].ToString(),
                SampOrig_Cod = reader["SampOrig_Cod"].ToString(),
                MatType_ID = (int)reader["MatType_ID"],
                MatType_Cod = reader["MatType_Cod"].ToString(),
                MatType_Name = reader["MatType_Name"].ToString(),
                SampD_Weight = (decimal)reader["SampD_Weight"],
                Orig_ID = (int)reader["Orig_ID"],
                Orig_Name = reader["Orig_Name"].ToString(),
                Zone_ID = (int)reader["Zone_ID"],
                Zone_Name = reader["Zone_Name"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                SampD_Status = reader["SampD_Status"].ToString()
            };
        }

        // POST: api/SampleReferential/Add
        public int Add(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleReferential_Add";
                //Head
                //cmd.Parameters.Add(new SqlParameter("@SampH_ID", obj["SampH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_Desc", obj["sampH_Desc"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_Refer", obj["sampH_Refer"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_Recep_Date", obj["sampH_Recep_Date"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["collec_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@UserAcc_ID", obj["userAcc_ID"].ToObject<int>()));
                //Details
                //cmd.Parameters.Add(new SqlParameter("@LabProcTyp_ID", obj["LabProcTyp_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@AnalType_ID", obj["analType_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_ID", obj["sampOrig_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@MatType_ID", obj["matType_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampD_Weight", obj["sampD_Weight"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", obj["orig_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", obj["creation_User"].ToObject<string>()));

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

        // PUT: api/SampleReferential/Update
        public int Update(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleReferential_Update";
                //Head
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", obj["sampH_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampD_ID", obj["sampD_ID"].ToObject<int>()));
                //cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["Company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_Desc", obj["sampH_Desc"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_Refer", obj["sampH_Refer"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_Recep_Date", obj["sampH_Recep_Date"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["collec_ID"].ToObject<int>()));
                //cmd.Parameters.Add(new SqlParameter("@UserAcc_ID", obj["UserAcc_ID"].ToObject<int>()));
                //Details
                cmd.Parameters.Add(new SqlParameter("@AnalType_ID", obj["analType_ID"].ToObject<int>()));
                //cmd.Parameters.Add(new SqlParameter("@SampOrig_ID", obj["sampOrig_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@MatType_ID", obj["matType_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampD_Weight", obj["sampD_Weight"].ToObject<decimal>()));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", obj["orig_ID"].ToObject<int>()));
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

        // DELETE: api/SampleReferential/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleReferential_Delete";
                cmd.Parameters.Add(new SqlParameter("@SampH_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));
                //cmd.Parameters.Add(new SqlParameter("@SampH_Reason", obj["reason"].ToObject<string>()));
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

        // POST: api/SampleReferential/Search/{}
        public List<SampleHeadReferential> Search(JObject obj)
        {
            var sampleHead = new List<SampleHeadReferential>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleHeadReferential_Search";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@UserAcc_ID", obj["idUserAcc"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["idCollec"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_Refer", obj["refSamp"].ToObject<string>()));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sampleHead.Add(MapToSampleHeadReferential(reader));
                    }
                }

                cmd.CommandText = "[CM].SampleDetailsReferential_GetAll";

                foreach (var sh in sampleHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", sh.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            sh.SampleDetailsReferentials.Add(MapToSampleDetailsReferential(dr));
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

        // POST: api/SampleReferential/SearchByApprover/{}
        public List<SampleHeadReferential> SearchByApprover(JObject obj)
        {
            var sampleHead = new List<SampleHeadReferential>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleHeadReferential_SearchByApprover";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["idCollec"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_Refer", obj["refSamp"].ToObject<string>()));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sampleHead.Add(MapToSampleHeadReferential(reader));
                    }
                }

                cmd.CommandText = "[CM].SampleDetailsReferential_GetAll";

                foreach (var sh in sampleHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@SampH_ID", sh.SampH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            sh.SampleDetailsReferentials.Add(MapToSampleDetailsReferential(dr));
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

        //PUT: api/SampleReferential/Approve/{}
        public int Approve(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].SampleReferential_Approve";
                //Detail
                cmd.Parameters.Add(new SqlParameter("@SampH_ID",obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@SampH_ApprUser", obj["user"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Action", obj["action"].ToObject<string>()));
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
