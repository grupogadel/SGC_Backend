﻿
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Entidad;
using SGC.InterfaceServices.XX.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace SGC.Services.XX
{
    public class ServiceDistrito : IServiceDistrito
    {
        private readonly string _context;

        public ServiceDistrito(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Distritos/GetAll
        public async Task<List<Distrito>> GetAll()
        {
            var response = new List<Distrito>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Distrito_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToDistrito(reader));
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

        private Distrito MapToDistrito(SqlDataReader reader)
        {
            return new Distrito()
            {
                Dist_ID = (int) reader["Dist_ID"],
                Dist_Cod = reader["Dist_Cod"].ToString(),
                Prov_ID = (int) reader["Prov_ID"],
                Dist_Name = reader["Dist_Name"].ToString(),
                Dist_Desc = reader["Dist_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime) reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime) reader["Modified_Date"],
                Dist_Status = reader["Dist_Status"].ToString()
            };
        }

        // POST: api/Distritos/Add
        public int Add(Distrito model)
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

    }

}
