using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.M_WK;
using SGC.InterfaceServices.M_WK;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.M_WK
{
    public class ServiceUsuario: IServiceUsuario
    {
        private readonly string _context;

        public ServiceUsuario(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Usuarios/GetAll
        public List<Usuario> GetAll()
        {
            var usuarios = new List<Usuario>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Usuario_GetAll";

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(MapToUsuario(reader));
                    }
                }

                cmd.CommandText = "[WK].Posicion_GetByUser";

                foreach (var u in usuarios)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@User_ID", u.User_ID));
                    
                    using (var dr =  cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            u.Positions.Add(MapToPosicion(dr));
                        }
                    }
                }
                conn.Close();
				
                return usuarios;
            }
            catch (Exception e)
            {
                return usuarios;//
                throw e;
            }
        }

        private Usuario MapToUsuario(SqlDataReader reader)
        {
            return new Usuario()
            {
                User_ID = (int)reader["User_ID"],
                User_Cod = reader["User_Cod"].ToString(),
                User_Name = reader["User_Name"].ToString(),
                User_LastName = reader["User_LastName"].ToString(),
                User_Email = reader["User_Email"].ToString(),
                User_User = reader["User_User"].ToString(),
                User_Status = reader["User_Status"].ToString(),
                //Position_ID = (int)reader["Position_ID"],
            };
        }

        private Posicion MapToPosicion(SqlDataReader reader)
        {
            return new Posicion()
            {
                Position_ID = (int)reader["Position_ID"],
                Position_Cod = reader["Position_Cod"].ToString(),
                Position_Name = reader["Position_Name"].ToString()
            };
        }

        // POST: api/Usuarios/Add
        /*public int Add(Usuario model)
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
        public int Update(Usuario model)
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
        public Usuario Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Zona_Get";
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                Usuario response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToUsuario(reader);
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
        }*/
    }
}


