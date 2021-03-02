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
    public class ServicePosition : IServicePosition
    {
        private readonly string _context;

        public ServicePosition(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        private Position MapToPosition(SqlDataReader reader)
        {
            return new Position()
            {
                Position_ID = (int)reader["Position_ID"],
				Company_ID = (int)reader["Company_ID"],
				Company_Name = reader["Company_Name"].ToString(),
                Position_Cod = reader["Position_Cod"].ToString(),
				Position_Name = reader["Position_Name"].ToString(),
				Position_Desc = reader["Position_Desc"].ToString(),
				Position_Father_ID = reader["Position_Father_ID"]==DBNull.Value?(int?)null:(int)reader["Position_Father_ID"],
				Position_FatherName = reader["Position_FatherName"].ToString(),
				Position_Level = reader["Position_Level"]==DBNull.Value?(int?)null:(int)reader["Position_Level"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Position_Status = reader["Position_Status"].ToString()
            };
        }
		
		public async Task<List<Position>> GetAll()
        {
            var response = new List<Position>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Position_GetAll";
               
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
        }
		
		public async Task<List<Position>> Search(JObject obj)
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
        }

        // POST: api/Position/Add/{}
        public int Add(Position model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Position_Add";
				cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Position_Cod", model.Position_Cod));
				cmd.Parameters.Add(new SqlParameter("@Position_Father_ID", model.Position_Father_ID??(object)DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Position_Name", model.Position_Name));
                cmd.Parameters.Add(new SqlParameter("@Position_Desc", model.Position_Desc));
				cmd.Parameters.Add(new SqlParameter("@Position_Level", model.Position_Level??(object)DBNull.Value));
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

        // PUT: api/Position/Update/{}
        public int Update(Position model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Position_Update";
                cmd.Parameters.Add(new SqlParameter("@Position_ID", model.Position_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Position_Cod", model.Position_Cod));
				cmd.Parameters.Add(new SqlParameter("@Position_Father_ID", model.Position_Father_ID??(object)DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Position_Name", model.Position_Name));
                cmd.Parameters.Add(new SqlParameter("@Position_Desc", model.Position_Desc));
				cmd.Parameters.Add(new SqlParameter("@Position_Level", model.Position_Level??(object)DBNull.Value));
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
