using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster.CollectorControl;
using SGC.InterfaceServices.CM.DataMaster.CollectorControl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.CM.DataMaster.Commercial.CollectorControl
{
    public class ServiceExpCollectMaster : IServiceExpCollectMaster
    {
        private readonly string _context;

        public ServiceExpCollectMaster(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        //POST: api/ExpCollectMaster/GetAll/{}
        public async Task<List<ExpCollectMaster>> GetAllM(JObject obj)
        {
            var response = new List<ExpCollectMaster>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectMaster_GetAllM";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToExpCollectMaster(reader));
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

        // POST: api/ExpCollectMaster/Search/{}
        public async Task<List<ExpCollectMaster>> SearchM(JObject obj)
        {
            var response = new List<ExpCollectMaster>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectMaster_SearchM";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToExpCollectMaster(reader));
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

        // POST: api/ExpCollectMaster/Add
        public int Add(ExpCollectMaster model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectMaster_Add";
                cmd.Parameters.Add(new SqlParameter("@MAccL_ID", model.@MAccL_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_Cod", model.MExpColl_Cod));
                cmd.Parameters.Add(new SqlParameter("@UM_ID", model.UM_ID));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_Level", model.MExpColl_Level));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_Name", model.MExpColl_Name));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_Desc", model.MExpColl_Desc));
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

        // PUT: api/ExpCollectMaster/Update
        public int Update(ExpCollectMaster model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectMaster_Update";
                cmd.Parameters.Add(new SqlParameter("@MExpColl_ID", model.MExpColl_ID));
                cmd.Parameters.Add(new SqlParameter("@MAccL_ID", model.MAccL_ID));
                cmd.Parameters.Add(new SqlParameter("@UM_ID", model.UM_ID));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_Level", model.MExpColl_Level));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_Name", model.MExpColl_Name));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_Desc", model.MExpColl_Desc));
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

        // DELETE: api/ExpCollectMaster/Delete
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectMaster_Delete";
                cmd.Parameters.Add(new SqlParameter("@MExpColl_ID", obj["id"].ToObject<int>()));
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

        private ExpCollectMaster MapToExpCollectMaster(SqlDataReader reader)
        {
            return new ExpCollectMaster()
            {
                MExpColl_ID = (int)reader["MExpColl_ID"],
                MAccL_ID = (int)reader["MAccL_ID"],
                MAccL_Cod = reader["MAccL_Cod"].ToString(),
                MAccL_Desc = reader["MAccL_Desc"].ToString(),
                Company_ID = (int)reader["Company_ID"],
                MExpColl_Cod = reader["MExpColl_Cod"].ToString(),
                UM_ID = (int)reader["UM_ID"],
                UM_Cod = reader["UM_Cod"].ToString(),
                MExpColl_Level = reader["MExpColl_Level"].ToString(),
                MExpColl_Name = reader["MExpColl_Name"].ToString(),
                MExpColl_Desc = reader["MExpColl_Desc"].ToString(),
                AccCat_ID = (int)reader["AccCat_ID"],
                AccCat_Desc = reader["AccCat_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                MExpColl_Status = reader["MExpColl_Status"].ToString()
            };
        }
    }
}
