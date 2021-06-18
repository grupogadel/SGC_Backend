using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.WK;
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
                Person_ID = (int)reader["Person_ID"],
                PosCollec_ID = (int)reader["PosCollec_ID"],
                Company_ID = (int)reader["Company_ID"],
                Collec_TaxID = reader["Collec_TaxID"].ToString(),
                Collec_Name = reader["Collec_Name"].ToString(),
                Collec_LastName = reader["Collec_LastName"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Collec_Status = reader["Collec_Status"].ToString(),

                Zone = new Zone { 
                    Zone_ID = (int)reader["Zone_ID"],
                    Dist_ID = (int)reader["Dist_ID"],
                    Zone_Name = reader["Zone_Name"].ToString(),
                },
                PositionCollector = new PositionCollector { 
                    PosCollec_ID = (int)reader["PosCollec_ID"],
                    PosCollec_Name = reader["PosCollec_Name"].ToString(),
                },
                Person = new Person
                {
                    Person_ID = (int)reader["Person_ID"],
                    Person_Email = reader["Person_Email"].ToString(),
                    Person_Number = reader["Person_Number"].ToString(),
                }
            };
        }

        // POST: api/Collector/Add
        public int Add(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                var model = new Collector();
                model = obj["collector"].ToObject<Collector>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_Add";
                cmd.Parameters.Add(new SqlParameter("@PosCollec_ID", model.PosCollec_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Person_ID", model.Person_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_TaxID", model.Collec_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Collec_Name", model.Collec_Name));
                cmd.Parameters.Add(new SqlParameter("@Collec_LastName", model.Collec_LastName));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                cmd.Parameters.Add(new SqlParameter("@Person_Number", model.Person.Person_Number));
                cmd.Parameters.Add(new SqlParameter("@Person_Email", model.Person.Person_Email));
                cmd.Parameters.Add(new SqlParameter("@Opt", obj["opt"].ToObject<int>()));

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

        // PUT: api/Collector/Update/1
        public int Update(Collector model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_Update";
                cmd.Parameters.Add(new SqlParameter("@PosCollec_ID", model.PosCollec_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@Person_ID", model.Person_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_Name", model.Collec_Name));
                cmd.Parameters.Add(new SqlParameter("@Collec_LastName", model.Collec_LastName));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));
                cmd.Parameters.Add(new SqlParameter("@Person_Number", model.Person.Person_Number));
                cmd.Parameters.Add(new SqlParameter("@Person_Email", model.Person.Person_Email));

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
                cmd.CommandText = "[CM].Collector_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", obj["id"].ToObject<int>()));
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

        // GET api/Collector/Get/1
        public Collector Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_Get";
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", id));

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

        public async Task<List<Collector>> Search(JObject obj)
        {
            var response = new List<Collector>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_Search";

                cmd.Parameters.Add(new SqlParameter("@Collec_TaxID", obj["tax"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@PosCollec_ID", obj["posCollec_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Status", obj["status"].ToObject<string>()));

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

        public async Task<Collector> GetDni(JObject obj)
        {
            var response = new Collector();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_GetDni";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Dni", obj["dni"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToCollector(reader);
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

        // GET api/Collector/Get/1
        public Collector GetRuc(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Collector_GetRuc";
                cmd.Parameters.Add(new SqlParameter("@Collec_TaxID", id));

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
