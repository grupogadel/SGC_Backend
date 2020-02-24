using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.InterfaceServices.CM.DataMaster;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.DataMaster
{
    public class ServiceCollector : IServiceCollector
    {
        private readonly string _context;

        public ServiceCollector(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Collector/GetAll
        public async Task<List<Collector>> GetAll(int idCompany)
        {
            var response = new List<Collector>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCollector(reader));
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

        private Collector MapToCollector(SqlDataReader reader)
        {
            return new Collector()
            {
                Collec_ID = (int)reader["Collec_ID"],
                Zone_ID = (int)reader["Zone_ID"],
                Company_ID = (int)reader["Company_ID"],
                Collec_Cod = reader["Collec_Cod"].ToString(),
                Collec_TaxID = reader["Collec_TaxID"].ToString(),
                Collec_Name = reader["Collec_Name"].ToString(),
                Collec_LastName = reader["Collec_LastName"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Collec_Status = reader["Collec_Status"].ToString(),
            };
        }

        // POST: api/Collector/Add
        public int Add(Collector model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_Cod", model.Collec_Cod));
                cmd.Parameters.Add(new SqlParameter("@Collec_TaxID", model.Collec_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Collec_Name", model.Collec_Name));
                cmd.Parameters.Add(new SqlParameter("@Collec_LastName", model.Collec_LastName));
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

        // PUT: api/Collector/Update/1
        public int Update(Collector model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_Update";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_Cod", model.Collec_Cod));
                cmd.Parameters.Add(new SqlParameter("@Collec_TaxID", model.Collec_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Collec_Name", model.Collec_Name));
                cmd.Parameters.Add(new SqlParameter("@Collec_LastName", model.Collec_LastName));
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

        // DELETE: api/Collector/Delete/1
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_Delete";
                cmd.Parameters.Add(new SqlParameter("@Period_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));

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

        // GET api/Collector/Get/1
        public Collector Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_Get";
                cmd.Parameters.Add(new SqlParameter("@Collector_ID", id));

                Collector response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToCollector(reader);
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
