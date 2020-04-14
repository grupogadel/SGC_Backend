
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.CM.DataMaster.Commercial;
using SGC.InterfaceServices.CM.DataMaster.Commercial;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace SGC.Services.CM.DataMaster.Commercial
{
    public class ServiceOrigin : IServiceOrigin
    {
        private readonly string _context;

        public ServiceOrigin(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Origin/GetAll
        public async Task<List<Origin>> GetAll(int idCompany)
        {
            var response = new List<Origin>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Origin_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToOrigin(reader));
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

        private Origin MapToOrigin(SqlDataReader reader)
        {
            return new Origin()
            {
                Orig_ID = (int)reader["Orig_ID"],
                Orig_Cod = reader["Orig_Cod"].ToString(),
                Zone_ID = (int)reader["Zone_ID"],
                Orig_Name = reader["Orig_Name"].ToString(),
                Orig_Desc = reader["Orig_Desc"].ToString(),
                Orig_Address = reader["Orig_Address"].ToString(),
                Orig_Reference = reader["Orig_Reference"].ToString(),
                Orig_Coordinates = reader["Orig_Coordinates"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Company_ID = (int)reader["Company_ID"],
                Orig_Status = reader["Orig_Status"].ToString(),
                Zones = new Zone {
                    Zone_ID = (int)reader["Zone_ID"],
                    Zone_Name = reader["Zone_Name"].ToString()
                }

            };
        }

        // POST: api/Origin/Add
        public int Add(Origin model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Origin_Add";
                //cmd.Parameters.Add(new SqlParameter("@Orig_Cod", model.Orig_Cod));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Orig_Name", model.Orig_Name));
                cmd.Parameters.Add(new SqlParameter("@Orig_Desc", model.Orig_Desc));
                cmd.Parameters.Add(new SqlParameter("@Orig_Address", model.Orig_Address));
                cmd.Parameters.Add(new SqlParameter("@Orig_Reference", model.Orig_Reference));
                cmd.Parameters.Add(new SqlParameter("@Orig_Coordinates", model.Orig_Coordinates));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));

                cmd.Parameters.Add("@Result",System.Data.SqlDbType.Int).Direction=System.Data.ParameterDirection.ReturnValue;

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

        // PUT: api/Origin/Update/1
        public int Update(Origin model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Origin_Update";

                cmd.Parameters.Add(new SqlParameter("@Orig_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Orig_Name", model.Orig_Name));
                cmd.Parameters.Add(new SqlParameter("@Orig_Desc", model.Orig_Desc));
                cmd.Parameters.Add(new SqlParameter("@Orig_Address", model.Orig_Address));
                cmd.Parameters.Add(new SqlParameter("@Orig_Reference", model.Orig_Reference));
                cmd.Parameters.Add(new SqlParameter("@Orig_Coordinates", model.Orig_Coordinates));
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

        // DELETE: api/District/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Origin_Delete";
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", obj["id"].ToObject<int>()));
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

        // GET api/District/Get/1
        /*public Origin Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Origin_Get";
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                Origin response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToOrigin(reader);
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
        }*/

    }

}
