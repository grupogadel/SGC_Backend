using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.InterfaceServices.XX.Commercial.MineralReception;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Commercial.MineralReception
{
    public class ServiceSampleOrigin: IServiceSampleOrigin
    {
        private readonly string _context;
        public ServiceSampleOrigin(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/SampleOrigin/GetAll
        public async Task<List<SampleOrigin>> GetAll(int idCompany)
        {
            var response = new List<SampleOrigin>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].SampleOrigin_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToSampleOrigin(reader));
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

        private SampleOrigin MapToSampleOrigin(SqlDataReader reader)
        {
            return new SampleOrigin()
            {
                SampOrig_ID = (int)reader["SampOrig_ID"],
                Company_ID = (int)reader["Company_ID"],
                SampOrig_AreaCod = reader["SampOrig_AreaCod"].ToString(),
                SampOrig_AreaDesc = reader["SampOrig_AreaDesc"].ToString(),
                SampOrig_Cod = reader["SampOrig_Cod"].ToString(),
                SampOrig_Module = reader["SampOrig_Module"].ToString(),
				SampOrig_Name = reader["SampOrig_Name"].ToString(),
                SampOrig_Desc = reader["SampOrig_Desc"].ToString(),
                SampOrig_ExgTab = (bool) reader["SampOrig_ExgTab"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                SampOrig_Status = reader["SampOrig_Status"].ToString()
            };
        }

        // POST: api/SampleOrigin/Add
        public int Add(SampleOrigin model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].SampleOrigin_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_Cod", model.SampOrig_Cod));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_Module", model.SampOrig_Module));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_AreaDesc", model.SampOrig_AreaDesc));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_Desc", model.SampOrig_Desc));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_ExgTab", model.SampOrig_ExgTab));
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

        // PUT: api/SampleOrigin/Update/1
        public int Update(SampleOrigin model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].SampleOrigin_Update";

                cmd.Parameters.Add(new SqlParameter("@SampOrig_ID", model.SampOrig_ID));
                //cmd.Parameters.Add(new SqlParameter("@SampOrig_Cod", model.SampOrig_Cod));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_Module", model.SampOrig_Module));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_AreaDesc", model.SampOrig_AreaDesc));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_Desc", model.SampOrig_Desc));
                cmd.Parameters.Add(new SqlParameter("@SampOrig_ExgTab", model.SampOrig_ExgTab));
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

        // DELETE: api/SampleOrigin/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].SampleOrigin_Delete";
                cmd.Parameters.Add(new SqlParameter("@SampOrig_ID", obj["id"].ToObject<int>()));
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

        public async Task<List<SampleOrigin>> Search(JObject obj)
        {
            var response = new List<SampleOrigin>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].SampleOrigin_Search";

                cmd.Parameters.Add(new SqlParameter("@SampOrig_Cod", obj["cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["companyID"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToSampleOrigin(reader));
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

        // GET api/SampleOrigin/Get/1
        public async Task<SampleOrigin> Get(int idCompany, int id)
        {
            var response = new SampleOrigin();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].SampleOrigin_Get";
                cmd.Parameters.Add(new SqlParameter("@SampOrig_ID", id));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToSampleOrigin(reader);
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
    }
}
