using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Operations.Mining
{
    public class ServiceMineralFrom : IServiceMineralFrom
    {
        private readonly string _context;

        public ServiceMineralFrom(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/MineralFrom/GetAll
        public async Task<List<MineralFrom>> GetAll(int idCompany)
        {
            var response = new List<MineralFrom>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MineralFrom_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMineralFrom(reader));
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

        private MineralFrom MapToMineralFrom(SqlDataReader reader)
        {
            return new MineralFrom()
            {
                MinFrom_ID = (int)reader["MinFrom_ID"],
                Company_ID = (int)reader["Company_ID"],
                MinFrom_Cod = reader["MinFrom_Cod"].ToString(),
                MinFrom_Name = reader["MinFrom_Name"].ToString(),
                MinFrom_Desc = reader["MinFrom_Desc"].ToString(),
                MinFrom_Location = reader["MinFrom_Location"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                MinFrom_Status = reader["MinFrom_Status"].ToString(),
            };
        }
        public int Add(MineralFrom model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MineralFrom_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_Cod", model.MinFrom_Cod));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_Name", model.MinFrom_Name));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_Desc", model.MinFrom_Desc));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_Location", model.MinFrom_Location));
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
        public int Update(MineralFrom model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MineralFrom_Update";
                cmd.Parameters.Add(new SqlParameter("@MinFrom_ID", model.MinFrom_ID));
                //cmd.Parameters.Add(new SqlParameter("@MinType_Cod", model.MinType_Cod));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_Name", model.MinFrom_Name));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_Desc", model.MinFrom_Desc));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_Location", model.MinFrom_Location));
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
                cmd.CommandText = "[XX].MineralFrom_Delete";
                cmd.Parameters.Add(new SqlParameter("@MinFrom_ID", obj["id"].ToObject<int>()));
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
        public async Task<List<MineralFrom>> Search(JObject obj)
        {
            var response = new List<MineralFrom>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MineralFrom_Search";

                cmd.Parameters.Add(new SqlParameter("@MinFrom_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMineralFrom(reader));
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
