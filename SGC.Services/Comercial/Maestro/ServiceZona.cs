
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.Comercial.Maestros;
using SGC.InterfaceServices.Comercial.Maestros;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace SGC.Services.Comercial.Maestros
{
    public class ServiceZona : IServiceZona
    {
        private readonly string _context;

        public ServiceZona(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Zonas/GetAll
        public async Task<List<Zona>> GetAll()
        {
            var response = new List<Zona>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Zona_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToZona(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return response;// new List<Zona>();//[]
                throw e;
            }
        }

        private Zona MapToZona(SqlDataReader reader)
        {
            return new Zona()
            {
                Zone_ID = (int)reader["Zone_ID"],
                Zone_Cod = reader["Zone_Cod"].ToString(),
                Dist_ID = (int)reader["Dist_ID"],
                Zone_Name = reader["Zone_Name"].ToString(),
                Zone_Desc = reader["Zone_Desc"].ToString(),
                Zone_Status = reader["Zone_Status"].ToString()

            };
        }

        // POST: api/Zonas/Add
        public int Add(Zona model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Zona_Add";
                cmd.Parameters.Add(new SqlParameter("@Zone_Cod", model.Zone_Cod));
                cmd.Parameters.Add(new SqlParameter("@Dist_ID", model.Dist_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_Name", model.Zone_Name));
                cmd.Parameters.Add(new SqlParameter("@Zone_Desc", model.Zone_Desc));

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

        // PUT: api/Zonas/Update/1
        public int Update(Zona model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Zona_Update";
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_Cod", model.Zone_Cod));
                cmd.Parameters.Add(new SqlParameter("@Dist_ID", model.Dist_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_Name", model.Zone_Name));
                cmd.Parameters.Add(new SqlParameter("@Zone_Desc", model.Zone_Desc));

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

        // DELETE: api/Zonas/Delete/1
        public int Delete(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Zona_Delete";
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", id));

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

        // GET api/Zonas/Get/1
        public Zona Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Zona_Get";
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                Zona response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToZona(reader);
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
