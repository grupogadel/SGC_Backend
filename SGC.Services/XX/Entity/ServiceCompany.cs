
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
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
                Company_ID = (int)reader["Company_ID"],
                Company_Father_ID = reader["Company_Father_ID"] == DBNull.Value ? new int?() : (int)reader["Company_Father_ID"],
                Company_Cod = reader["Company_Cod"].ToString(),
                Company_Name = reader["Company_Name"].ToString(),
                Company_TaxID = reader["Company_TaxID"].ToString(),
                Country_ID = (int)reader["Country_ID"],
                Region_ID = (int)reader["Region_ID"],
                Company_Address = reader["Company_Address"].ToString(),
                Company_Curr_Funct = reader["Company_Curr_Funct"].ToString(),
                Company_Curr_Loc = reader["Company_Curr_Loc"].ToString(),
                Company_Curr_Grp = reader["Company_Curr_Grp"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Company_Status = reader["Company_Status"].ToString(),

                Region = new Region { Region_ID = (int)reader["Region_ID"], Region_Name = reader["Region_Name"].ToString() },
                Country = new Country { Country_ID = (int)reader["Country_ID"], Country_Name = reader["Country_Name"].ToString() },
                Currency_Funct = new Currency { Currency_ID = (int)reader["Currency_ID_F"],  Currency_Cod = reader["Currency_Cod_F"].ToString(), Currency_Name = reader["Currency_Name_F"].ToString() },
                Currency_Loc = new Currency { Currency_ID = (int)reader["Currency_ID_L"],  Currency_Cod = reader["Currency_Cod_L"].ToString(), Currency_Name = reader["Currency_Name_L"].ToString() },
                Currency_Grp = new Currency { Currency_ID = (int)reader["Currency_ID_G"],  Currency_Cod = reader["Currency_Cod_G"].ToString(), Currency_Name = reader["Currency_Name_G"].ToString() }

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
                cmd.Parameters.Add(new SqlParameter("@Company_Father_ID", model.Company_Father_ID != null ? model.Company_Father_ID : 0));
                cmd.Parameters.Add(new SqlParameter("@Company_Cod", model.Company_Cod));
                cmd.Parameters.Add(new SqlParameter("@Company_Name", model.Company_Name));
                cmd.Parameters.Add(new SqlParameter("@Company_TaxID", model.Company_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Country_ID", model.Country_ID));
                cmd.Parameters.Add(new SqlParameter("@Region_ID", model.Region_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_Address", model.Company_Address));
                cmd.Parameters.Add(new SqlParameter("@Company_Curr_Funct", model.Company_Curr_Funct));
                cmd.Parameters.Add(new SqlParameter("@Company_Curr_Loc", model.Company_Curr_Loc));
                cmd.Parameters.Add(new SqlParameter("@Company_Curr_Grp", model.Company_Curr_Grp));
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

        // PUT: api/Company/Update/1
        public int Update(Company model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Company_Update";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_Father_ID", model.Company_Father_ID != null ? model.Company_Father_ID : 0));
                cmd.Parameters.Add(new SqlParameter("@Company_Name", model.Company_Name));
                cmd.Parameters.Add(new SqlParameter("@Company_TaxID", model.Company_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Country_ID", model.Country_ID));
                cmd.Parameters.Add(new SqlParameter("@Region_ID", model.Region_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_Address", model.Company_Address));
                cmd.Parameters.Add(new SqlParameter("@Company_Curr_Funct", model.Company_Curr_Funct));
                cmd.Parameters.Add(new SqlParameter("@Company_Curr_Loc", model.Company_Curr_Loc));
                cmd.Parameters.Add(new SqlParameter("@Company_Curr_Grp", model.Company_Curr_Grp));
                
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
                cmd.CommandText = "[XX].Company_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["id"].ToObject<int>()));
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

        // GET api/Company/Get/1
        public Company Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Company_Get";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", id));

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

        public async Task<List<Company>> Search(JObject obj)
        {
            var response = new List<Company>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].Company_Search";

                cmd.Parameters.Add(new SqlParameter("@Company_Cod", obj["cod"].ToObject<string>()));
               
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
                return response;// 
                throw e;
            }
        }

    }

}
