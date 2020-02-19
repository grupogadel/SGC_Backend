
using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;
using SGC.InterfaceServices.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.XX.Entity
{
    public class ServiceCompany : IServiceCompany
    {
        private readonly string _context;

        public ServiceCompany(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/Company/GetAll
        public async Task<List<Company>> GetAll()
        {
            var response = new List<Company>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Company_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCompany(reader));
                    }
                }
                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return new List<Company>();//[]
                throw e;
            }
        }

        private Company MapToCompany(SqlDataReader reader)
        {
            return new Company()
            {
                Compa_ID = (int)reader["Compa_ID"],
                Compa_Father_ID = reader["Compa_Father_ID"] == DBNull.Value ? new int?() : (int)reader["Compa_Father_ID"],
                Compa_Cod = reader["Compa_Cod"].ToString(),
                Compa_Name = reader["Compa_Name"].ToString(),
                Compa_TaxID = reader["Compa_TaxID"].ToString(),
                Compa_Country = reader["Compa_Country"].ToString(),
                Compa_Region = reader["Compa_Region"].ToString(),
                Compa_Address = reader["Compa_Address"].ToString(),
                Compa_Curr_Funct = reader["Compa_Curr_Funct"].ToString(),
                Compa_Curr_Loc = reader["Compa_Curr_Loc"].ToString(),
                Compa_Curr_Grp = reader["Compa_Curr_Grp"].ToString(),
                //Compa_AcctDeb = reader["Compa_AcctDeb"].ToString(),
                //Compa_AcctCre = reader["Compa_AcctCre"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Compa_Status = reader["Compa_Status"].ToString(),

                Currency_Funct = new Currency { Currency_ID = (int)reader["Currency_ID_F"], Currency_Country = reader["Currency_Country_F"].ToString(), Currency_Cod = reader["Currency_Cod_F"].ToString(), Currency_Name = reader["Currency_Name_F"].ToString() },
                Currency_Loc = new Currency { Currency_ID = (int)reader["Currency_ID_L"], Currency_Country = reader["Currency_Country_L"].ToString(), Currency_Cod = reader["Currency_Cod_L"].ToString(), Currency_Name = reader["Currency_Name_L"].ToString() },
                Currency_Grp = new Currency { Currency_ID = (int)reader["Currency_ID_G"], Currency_Country = reader["Currency_Country_G"].ToString(), Currency_Cod = reader["Currency_Cod_G"].ToString(), Currency_Name = reader["Currency_Name_G"].ToString() }

            };
        }

        // POST: api/Company/Add
        public int Add(Company model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Company_Add";
                cmd.Parameters.Add(new SqlParameter("@Compa_Father_ID", model.Compa_Father_ID != null ? model.Compa_Father_ID : 0));
                cmd.Parameters.Add(new SqlParameter("@Compa_Cod", model.Compa_Cod));
                cmd.Parameters.Add(new SqlParameter("@Compa_Name", model.Compa_Name));
                cmd.Parameters.Add(new SqlParameter("@Compa_TaxID", model.Compa_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Compa_Country", model.Compa_Country));
                cmd.Parameters.Add(new SqlParameter("@Compa_Region", model.Compa_Region));
                cmd.Parameters.Add(new SqlParameter("@Compa_Address", model.Compa_Address));
                cmd.Parameters.Add(new SqlParameter("@Compa_Curr_Funct", model.Compa_Curr_Funct));
                cmd.Parameters.Add(new SqlParameter("@Compa_Curr_Loc", model.Compa_Curr_Loc));
                cmd.Parameters.Add(new SqlParameter("@Compa_Curr_Grp", model.Compa_Curr_Grp));
                //cmd.Parameters.Add(new SqlParameter("@Compa_AcctDeb", model.Compa_AcctDeb));
                //cmd.Parameters.Add(new SqlParameter("@Compa_AcctCre", model.Compa_AcctCre));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));

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

        // PUT: api/Company/Update/1
        public int Update(Company model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Company_Update";
                cmd.Parameters.Add(new SqlParameter("@Compa_ID", model.Compa_ID));
                cmd.Parameters.Add(new SqlParameter("@Compa_Father_ID", model.Compa_Father_ID != null ? model.Compa_Father_ID : 0));
                cmd.Parameters.Add(new SqlParameter("@Compa_Cod", model.Compa_Cod));
                cmd.Parameters.Add(new SqlParameter("@Compa_Name", model.Compa_Name));
                cmd.Parameters.Add(new SqlParameter("@Compa_TaxID", model.Compa_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Compa_Country", model.Compa_Country));
                cmd.Parameters.Add(new SqlParameter("@Compa_Region", model.Compa_Region));
                cmd.Parameters.Add(new SqlParameter("@Compa_Address", model.Compa_Address));
                cmd.Parameters.Add(new SqlParameter("@Compa_Curr_Funct", model.Compa_Curr_Funct));
                cmd.Parameters.Add(new SqlParameter("@Compa_Curr_Loc", model.Compa_Curr_Loc));
                cmd.Parameters.Add(new SqlParameter("@Compa_Curr_Grp", model.Compa_Curr_Grp));
                //cmd.Parameters.Add(new SqlParameter("@Compa_AcctDeb", model.Compa_AcctDeb));
                //cmd.Parameters.Add(new SqlParameter("@Compa_AcctCre", model.Compa_AcctCre));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));
                cmd.Parameters.Add(new SqlParameter("@Compa_Status", model.Compa_Status));

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

        // DELETE: api/Company/Delete/1
        public int Delete(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Company_Delete";
                cmd.Parameters.Add(new SqlParameter("@Compa_ID", id));

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

        // GET api/Company/Get/1
        public Company Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Company_Get";
                cmd.Parameters.Add(new SqlParameter("@Compa_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                Company response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToCompany(reader);
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
