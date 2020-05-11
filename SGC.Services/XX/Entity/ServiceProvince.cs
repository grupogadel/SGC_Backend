
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace SGC.Services.XX
{
    public class ServiceProvince : IServiceProvince
    {
        private readonly string _context;

        public ServiceProvince(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int Add(Province model)
        {
            throw new NotImplementedException();
        }

        public int Delete(Province obj)
        {
            throw new NotImplementedException();
        }

        public Province Get(int id)
        {
            throw new NotImplementedException();
        }

        // GET: api/Provincias/GetAll
        public async Task<List<Province>> GetAll()
        {
            var response = new List<Province>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Province_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToProvince(reader));
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

        public int Update(Province model)
        {
            throw new NotImplementedException();
        }

        private Province MapToProvince(SqlDataReader reader)
        {
            return new Province()
            {
                Prov_ID= (int)reader["Prov_ID"],
                Depa_ID = (int)reader["Depa_ID"],
                Prov_Cod = reader["Prov_Cod"].ToString(),
                Prov_Name = reader["Prov_Name"].ToString(),
                Prov_Desc = reader["Prov_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime) reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date   = (DateTime) reader["Modified_Date"],
                Prov_Status = reader["Prov_Status"].ToString(),
                Departments = new Department
                {
                    Depa_ID = (int)reader["Depa_ID"],
                    Depa_Name = reader["Depa_Name"].ToString()
                }
            };
        }

        // POST: api/Distritos/Add
        /*public int Add(Distrito model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Distrito_Add";
                cmd.Parameters.Add(new SqlParameter("@Dist_Cod", model.Dist_Cod));
                cmd.Parameters.Add(new SqlParameter("@Prov_ID", model.Prov_ID));
                cmd.Parameters.Add(new SqlParameter("@Dist_Name", model.Dist_Name));
                cmd.Parameters.Add(new SqlParameter("@Dist_Desc", model.Dist_Desc));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));

                //cmd.Parameters.Add("@Resultado",System.Data.SqlDbType.Int).Direction=System.Data.ParameterDirection.ReturnValue;

                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                //var resul = (int)cmd.Parameters["@Resultado"].Value;
                conn.Close();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }

        }

        // PUT: api/Distritos/Update/1
        public int Update(Distrito model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Distrito_Update";

                cmd.Parameters.Add(new SqlParameter("@Dist_ID", model.Dist_ID));
                cmd.Parameters.Add(new SqlParameter("@Dist_Cod", model.Dist_Cod));
                cmd.Parameters.Add(new SqlParameter("@Prov_ID", model.Prov_ID));
                cmd.Parameters.Add(new SqlParameter("@Dist_Name", model.Dist_Name));
                cmd.Parameters.Add(new SqlParameter("@Dist_Desc", model.Dist_Desc));
                cmd.Parameters.Add(new SqlParameter("@Dist_Status", model.Dist_Status));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                //var resul = (int)cmd.Parameters["@Resultado"].Value;
                conn.Close();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }

        // DELETE: api/Distritos/Delete/1
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Distrito_Delete";
                cmd.Parameters.Add(new SqlParameter("@Dist_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                //var resul = (int)cmd.Parameters["@Resultado"].Value;
                conn.Close();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }

        // GET api/Distritos/Get/1
        public Distrito Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Distrito_Get";
                cmd.Parameters.Add(new SqlParameter("@Dist_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                Distrito response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToDistrito(reader);
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
		*/

    }

}
