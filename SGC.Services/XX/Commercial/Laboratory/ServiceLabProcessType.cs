using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.InterfaceServices.XX.Commercial.Laboratory;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Commercial.Laboratory
{
    public class ServiceLabProcessType: IServiceLabProcessType
    {
        private readonly string _context;
        public ServiceLabProcessType(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/LabProcessType/GetAll
        public async Task<List<LabProcessType>> GetAll()
        {
            var response = new List<LabProcessType>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LabProcessType_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToLabProcessType(reader));
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

        private LabProcessType MapToLabProcessType(SqlDataReader reader)
        {
            return new LabProcessType()
            {
                LabProcTyp_ID = (int)reader["LabProcTyp_ID"],
                LabProcTyp_Cod = reader["LabProcTyp_Cod"].ToString(),
                LabProcTyp_Name = reader["LabProcTyp_Name"].ToString(),
                LabProcTyp_Desc = reader["LabProcTyp_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                LabProcTyp_Status = reader["LabProcTyp_Status"].ToString()
            };
        }

        // POST: api/LabProcessType/Add
        public int Add(LabProcessType model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LabProcessType_Add";
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_Cod", model.LabProcTyp_Cod));
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_Name", model.LabProcTyp_Name));
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_Desc", model.LabProcTyp_Desc));
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

        // PUT: api/LabProcessType/Update/1
        public int Update(LabProcessType model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LabProcessType_Update";

                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_ID", model.LabProcTyp_ID));
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_Cod", model.LabProcTyp_Cod));
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_Name", model.LabProcTyp_Name));
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_Desc", model.LabProcTyp_Desc));
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

        // DELETE: api/LabProcessType/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LabProcessType_Delete";
                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_ID", obj["id"].ToObject<int>()));
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

        public async Task<List<LabProcessType>> Search(JObject obj)
        {
            var response = new List<LabProcessType>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].LabProcessType_Search";

                cmd.Parameters.Add(new SqlParameter("@LabProcTyp_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToLabProcessType(reader));
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
