using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.InterfaceServices.XX.Commercial.Laboratory;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Commercial.Laboratory
{
    public class ServiceLaboratorySetting : IServiceLaboratorySetting
    {
        private readonly string _context;

        public ServiceLaboratorySetting(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/LaboratorySetting/GetAll/1
        public async Task<List<LaboratorySetting>> GetAll(int idCompany)
        {
            var response = new List<LaboratorySetting>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LaboratorySetting_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToLaboratorySetting(reader));
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
        private LaboratorySetting MapToLaboratorySetting(SqlDataReader reader)
        {
            return new LaboratorySetting()
            {
                LabS_ID = (int)reader["LabS_ID"],
                Company_ID = (int)reader["Company_ID"],
                LabS_Cod = reader["LabS_Cod"].ToString(),
                LabS_Desc = reader["LabS_Desc"].ToString(),
                LabS_GravEsP1 = (decimal)reader["LabS_GravEsP1"],
                LabS_GravEsP2 = (decimal)reader["LabS_GravEsP2"],
                LabS_GravEsP3 = (decimal)reader["LabS_GravEsP3"],
                LabS_GravEsP4 = (decimal)reader["LabS_GravEsP4"],
                LabS_GravEsR = (decimal)reader["LabS_GravEsR"],
                LabS_GravEsP = (decimal)reader["LabS_GravEsP"],
                LabS_ParLixDens = (decimal)reader["LabS_ParLixDens"],
                LabS_ParLixK = (decimal)reader["LabS_ParLixK"],
                LabS_ParLixPorSol = (decimal)reader["LabS_ParLixPorSol"],
                LabS_ParLixPorLiq = (decimal)reader["LabS_ParLixPorLiq"],
                LabS_ParLixDilucion = (decimal)reader["LabS_ParLixDilucion"],
                LabS_ParLixMalla200 = (decimal)reader["LabS_ParLixMalla200"],
                LabS_ParSamWeight = (decimal)reader["LabS_ParSamWeight"],
                LabS_SamH2OMml = (decimal)reader["LabS_SamH2OMml"],
                LabS_SamTot = (decimal)reader["LabS_SamTot"],
                LabS_VolumDesech2 = (decimal)reader["LabS_VolumDesech2"],
                LabS_VolumDesech4 = (decimal)reader["LabS_VolumDesech4"],
                LabS_VolumDesech8 = (decimal)reader["LabS_VolumDesech8"],
                LabS_VolumDesech12 = (decimal)reader["LabS_VolumDesech12"],
                LabS_VolumDesech24 = (decimal)reader["LabS_VolumDesech24"],
                LabS_VolumDesech48 = (decimal)reader["LabS_VolumDesech48"],
                LabS_VolumDesech72 = (decimal)reader["LabS_VolumDesech72"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                LabS_Status = reader["LabS_Status"].ToString(),
            };
        }
        public int Add(LaboratorySetting model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LaboratorySetting_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@LabS_Cod", model.LabS_Cod));
                cmd.Parameters.Add(new SqlParameter("@LabS_Desc", model.LabS_Desc));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP1", model.LabS_GravEsP1));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP2", model.LabS_GravEsP2));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP3", model.LabS_GravEsP3));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP4", model.LabS_GravEsP4));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsR", model.LabS_GravEsR));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP", model.LabS_GravEsP));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixDens", model.LabS_ParLixDens));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixK", model.LabS_ParLixK));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixPorSol", model.LabS_ParLixPorSol));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixPorLiq", model.LabS_ParLixPorLiq));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixDilucion", model.LabS_ParLixDilucion));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixMalla200", model.LabS_ParLixMalla200));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParSamWeight", model.LabS_ParSamWeight));
                cmd.Parameters.Add(new SqlParameter("@LabS_SamH2OMml", model.LabS_SamH2OMml));
                cmd.Parameters.Add(new SqlParameter("@LabS_SamTot", model.LabS_SamTot));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech2", model.LabS_VolumDesech2));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech4", model.LabS_VolumDesech4));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech8", model.LabS_VolumDesech8));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech12", model.LabS_VolumDesech12));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech24", model.LabS_VolumDesech24));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech48", model.LabS_VolumDesech48));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech72", model.LabS_VolumDesech72));
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
        public int Update(LaboratorySetting model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LaboratorySetting_Update";
                cmd.Parameters.Add(new SqlParameter("@LabS_ID", model.LabS_ID));
                //cmd.Parameters.Add(new SqlParameter("@MinType_Cod", model.MinType_Cod));
                cmd.Parameters.Add(new SqlParameter("@LabS_Desc", model.LabS_Desc));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP1", model.LabS_GravEsP1));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP2", model.LabS_GravEsP2));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP3", model.LabS_GravEsP3));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP4", model.LabS_GravEsP4));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsR", model.LabS_GravEsR));
                cmd.Parameters.Add(new SqlParameter("@LabS_GravEsP", model.LabS_GravEsP));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixDens", model.LabS_ParLixDens));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixK", model.LabS_ParLixK));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixPorSol", model.LabS_ParLixPorSol));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixPorLiq", model.LabS_ParLixPorLiq));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixDilucion", model.LabS_ParLixDilucion));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParLixMalla200", model.LabS_ParLixMalla200));
                cmd.Parameters.Add(new SqlParameter("@LabS_ParSamWeight", model.LabS_ParSamWeight));
                cmd.Parameters.Add(new SqlParameter("@LabS_SamH2OMml", model.LabS_SamH2OMml));
                cmd.Parameters.Add(new SqlParameter("@LabS_SamTot", model.LabS_SamTot));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech2", model.LabS_VolumDesech2));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech4", model.LabS_VolumDesech4));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech8", model.LabS_VolumDesech8));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech12", model.LabS_VolumDesech12));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech24", model.LabS_VolumDesech24));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech48", model.LabS_VolumDesech48));
                cmd.Parameters.Add(new SqlParameter("@LabS_VolumDesech72", model.LabS_VolumDesech72));
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
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LaboratorySetting_Delete";
                cmd.Parameters.Add(new SqlParameter("@LabS_ID", obj["id"].ToObject<int>()));
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
        public async Task<List<LaboratorySetting>> Search(JObject obj)
        {
            var response = new List<LaboratorySetting>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LaboratorySetting_Search";

                cmd.Parameters.Add(new SqlParameter("@LabS_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToLaboratorySetting(reader));
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

        public LaboratorySetting Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LaboratorySetting_Get";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", id));

                LaboratorySetting response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToLaboratorySetting(reader);
                    }
                }
                conn.Close();
                return response;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

    }
}