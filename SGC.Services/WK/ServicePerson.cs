using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.WK;
using SGC.InterfaceServices.WK;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.Services.WK
{
    public class ServicePerson : IServicePerson
    {
        private readonly string _context;

        public ServicePerson(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        private Person MapToPerson(SqlDataReader reader)
        {
            return new Person()
            {
                Person_ID = (int)reader["Person_ID"],
				Person_DNI = reader["Person_DNI"].ToString(),
				Person_Name = reader["Person_Name"].ToString(),
                Person_LastName = reader["Person_LastName"].ToString(),
				Person_Number = reader["Person_Number"].ToString(),
				Person_Email = reader["Person_Email"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Person_Status = reader["Person_Status"].ToString()
            };
        }
		
		public async Task<List<Person>> GetAll()
        {
            var response = new List<Person>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Person_GetAll";
               
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPerson(reader));
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
		
		/*public async Task<List<Position>> Search(JObject obj)
        {
            var response = new List<Position>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Position_Search";
				
				cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Position_Cod", obj["cod"].ToObject<string>()));
               
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPosition(reader));
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
        }*/

        // POST: api/Person/Add/{}
        public int Add(Person model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Person_Add";
				cmd.Parameters.Add(new SqlParameter("@Person_DNI", model.Person_DNI));
                cmd.Parameters.Add(new SqlParameter("@Person_Name", model.Person_Name));
				cmd.Parameters.Add(new SqlParameter("@Person_LastName", model.Person_LastName));
                cmd.Parameters.Add(new SqlParameter("@Person_Number", model.Person_Number));
                cmd.Parameters.Add(new SqlParameter("@Person_Email", model.Person_Email));
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

        // PUT: api/Person/Update/{}
        public int Update(Person model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Person_Update";
                cmd.Parameters.Add(new SqlParameter("@Person_ID", model.Person_ID));
                cmd.Parameters.Add(new SqlParameter("@Person_DNI", model.Person_DNI));
                cmd.Parameters.Add(new SqlParameter("@Person_Name", model.Person_Name));
				cmd.Parameters.Add(new SqlParameter("@Person_LastName", model.Person_LastName));
                cmd.Parameters.Add(new SqlParameter("@Person_Number", model.Person_Number));
                cmd.Parameters.Add(new SqlParameter("@Person_Email", model.Person_Email));
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

    }
}
