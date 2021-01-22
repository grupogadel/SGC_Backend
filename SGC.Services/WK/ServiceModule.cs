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
    public class ServiceModule : IServiceModule
    {
        private readonly string _context;

        public ServiceModule(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Module/GetAll
        public async Task<List<Module>> GetAll()
        {
            var response = new List<Module>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Module_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToModule(reader));
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

        private Module MapToModule(SqlDataReader reader)
        {
            return new Module()
            {
                Module_ID = (int)reader["Module_ID"],
                Module_Cod = reader["Module_Cod"].ToString(),
				Module_Father = reader["Module_Father"]==DBNull.Value?(int?)null:(int)reader["Module_Father"],
                Module_Name = reader["Module_Name"].ToString(),
                Module_Desc = reader["Module_Desc"].ToString(),
				Module_Level = reader["Module_Level"]==DBNull.Value?(int?)null:(int)reader["Module_Level"],
				Module_FatherName = reader["Module_FatherName"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Module_Status = reader["Module_Status"].ToString()
            };
        }
		
		public async Task<List<Module>> Search(JObject obj)
        {
            var response = new List<Module>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Module_Search";

                cmd.Parameters.Add(new SqlParameter("@Module_Cod", obj["cod"].ToObject<string>()));
               
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToModule(reader));
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

        // POST: api/Module/Add/{}
        public int Add(Module model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Module_Add";
                cmd.Parameters.Add(new SqlParameter("@Module_Cod", model.Module_Cod));
				cmd.Parameters.Add(new SqlParameter("@Module_Father", model.Module_Father??(object)DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Module_Name", model.Module_Name));
                cmd.Parameters.Add(new SqlParameter("@Module_Desc", model.Module_Desc));
				cmd.Parameters.Add(new SqlParameter("@Module_Level", model.Module_Level??(object)DBNull.Value));
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

        // PUT: api/Module/Update/{}
        public int Update(Module model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Module_Update";
                cmd.Parameters.Add(new SqlParameter("@Module_ID", model.Module_ID));
                cmd.Parameters.Add(new SqlParameter("@Module_Cod", model.Module_Cod));
				cmd.Parameters.Add(new SqlParameter("@Module_Father", model.Module_Father ?? (object)DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Module_Name", model.Module_Name));
                cmd.Parameters.Add(new SqlParameter("@Module_Desc", model.Module_Desc));
				cmd.Parameters.Add(new SqlParameter("@Module_Level", model.Module_Level ?? (object)DBNull.Value));
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
