
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Finance;
using SGC.Entities.Entities.XX.Entity;
using SGC.InterfaceServices.XX.Finance;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.Services.XX.Entity
{
    public class ServiceUnitMeasuare : IServiceUnitMeasuare
    {
        private readonly string _context;

        public ServiceUnitMeasuare(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        private UnitMeasuare MapToUnitMeasuare(SqlDataReader reader)
        {
            return new UnitMeasuare()
            {
                UM_ID = (int)reader["UM_ID"],
                UM_Cod = reader["UM_Cod"].ToString(),
                UM_Cod_Alt = reader["UM_Cod_Alt"].ToString(),
                UM_Desc = reader["UM_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                UM_Status = reader["UM_Status"].ToString(),
            };
        }

        public int Add(UnitMeasuare model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].UnitMeasuare_Add";
                cmd.Parameters.Add(new SqlParameter("@UM_Cod", model.UM_Cod));
                cmd.Parameters.Add(new SqlParameter("@UM_Cod_Alt", model.UM_Cod_Alt));
                cmd.Parameters.Add(new SqlParameter("@UM_Desc", model.UM_Desc));
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

        // PUT: api/UnitMeasuare/Update/
        public int Update(UnitMeasuare model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].UnitMeasuare_Update";
                cmd.Parameters.Add(new SqlParameter("@UM_ID", model.UM_ID));
                cmd.Parameters.Add(new SqlParameter("@UM_Cod", model.UM_Cod));
                cmd.Parameters.Add(new SqlParameter("@UM_Cod_Alt", model.UM_Cod_Alt));
                cmd.Parameters.Add(new SqlParameter("@UM_Desc", model.UM_Desc));
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

        public int ChangeStatus(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].UnitMeasuare_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@UM_ID", obj["id"].ToObject<int>()));
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

        public async Task<List<UnitMeasuare>> Search(JObject obj)
        {
            var response = new List<UnitMeasuare>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].UnitMeasuare_Search";

                cmd.Parameters.Add(new SqlParameter("@UM_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToUnitMeasuare(reader));
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


    }

}
