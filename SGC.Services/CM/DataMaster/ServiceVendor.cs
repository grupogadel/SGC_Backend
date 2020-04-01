using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;
using SGC.InterfaceServices.CM.DataMaster;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.DataMaster
{
    public class ServiceVendor : IServiceVendor
    {
        private readonly string _context;

        public ServiceVendor(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public int Add(Vendor model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Vendor_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_TaxID", model.Vendor_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_CatPers", model.Vendor_CatPers));
                cmd.Parameters.Add(new SqlParameter("@DocIdent_ID", model.DocIdent_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Desc", model.Vendor_Desc));
                cmd.Parameters.Add(new SqlParameter("@Vendor_LastName", model.Vendor_LastName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_SurName", model.Vendor_SurName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Address", model.Vendor_Address));
                cmd.Parameters.Add(new SqlParameter("@Country_ID", model.Country_ID));
                cmd.Parameters.Add(new SqlParameter("@Region_ID", model.Region_ID));
                cmd.Parameters.Add(new SqlParameter("@Depa_ID", model.Depa_ID));
                cmd.Parameters.Add(new SqlParameter("@Prov_ID", model.Prov_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Distric", model.Vendor_Distric));
                cmd.Parameters.Add(new SqlParameter("@Vendor_CelPhone", model.Vendor_CelPhone));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Email", model.Vendor_Email));
                cmd.Parameters.Add(new SqlParameter("@Vendor_DetracPorc", model.Vendor_DetracPorc));

                cmd.Parameters.Add(new SqlParameter("@Bank_ID_AcctLocal_NO", model.Bank_ID_AcctLocal_NO));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID_AcctLocal_NO", model.Currency_ID_AcctLocal_NO));
                cmd.Parameters.Add(new SqlParameter("@Vendor_AcctLocal_NO", model.Vendor_AcctLocal_NO));

                cmd.Parameters.Add(new SqlParameter("@Bank_ID_AcctLocalCCI_NO", model.Bank_ID_AcctLocalCCI_NO));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID_AcctLocalCCI_NO", model.Currency_ID_AcctLocalCCI_NO));
                cmd.Parameters.Add(new SqlParameter("@Vendor_AcctLocalCCI_NO", model.Vendor_AcctLocalCCI_NO));

                cmd.Parameters.Add(new SqlParameter("@Bank_ID_AcctDetracc_NO", model.Bank_ID_AcctDetracc_NO));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID_AcctDetracc_NO", model.Currency_ID_AcctDetracc_NO));
                cmd.Parameters.Add(new SqlParameter("@Vendor_AcctDetracc_NO", model.Vendor_AcctDetracc_NO));
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

        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Vendor_Delete";
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));

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

        public Vendor Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Vendor_Get";
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", id));

                //cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                
                Vendor response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToVendor(reader);
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

        public async Task<List<Vendor>> GetAll(int idCompany)
        {
            var response = new List<Vendor>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Vendor_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToVendor(reader));
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


        private Vendor MapToVendor(SqlDataReader reader)
        {
            return new Vendor()
            {
                Vendor_ID = (int)reader["Vendor_ID"],
                Company_ID = (int)reader["Company_ID"],
                Vendor_Cod = reader["Vendor_Cod"].ToString(),
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Vendor_CatPers = reader["Vendor_CatPers"].ToString(),
                DocIdent_ID = (int)reader["DocIdent_ID"],
                Vendor_Desc = reader["Vendor_Desc"].ToString(),
                Vendor_LastName = reader["Vendor_LastName"].ToString(),
                Vendor_SurName = reader["Vendor_SurName"].ToString(),
                Vendor_Address = reader["Vendor_Address"].ToString(),
                Country_ID = (int)reader["Country_ID"],
                Region_ID = (int)reader["Region_ID"],
                Depa_ID= (int)reader["Depa_ID"],
                Prov_ID= (int)reader["Prov_ID"],
                Vendor_Distric = reader["Vendor_Distric"].ToString(),
                Vendor_CelPhone = reader["Vendor_CelPhone"].ToString(),
                Vendor_Email = reader["Vendor_Email"].ToString(),
                Vendor_DetracPorc = (decimal)reader["Vendor_DetracPorc"],

                Bank_ID_AcctLocal_NO = (int)reader["Bank_ID_AcctLocal_NO"],
                Currency_ID_AcctLocal_NO = (int)reader["Currency_ID_AcctLocal_NO"],
                Vendor_AcctLocal_NO = reader["Vendor_AcctLocal_NO"].ToString(),

                Bank_ID_AcctLocalCCI_NO = (int)reader["Bank_ID_AcctLocalCCI_NO"],
                Currency_ID_AcctLocalCCI_NO = (int)reader["Currency_ID_AcctLocalCCI_NO"],
                Vendor_AcctLocalCCI_NO = reader["Vendor_AcctLocalCCI_NO"].ToString(),

                Bank_ID_AcctDetracc_NO = (int)reader["Bank_ID_AcctDetracc_NO"],
                Currency_ID_AcctDetracc_NO = (int)reader["Currency_ID_AcctDetracc_NO"],
                Vendor_AcctDetracc_NO = reader["Vendor_AcctDetracc_NO"].ToString(),
                
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Vendor_Status = reader["Vendor_Status"].ToString(),
                Countrys=new Country
                {
                    Country_ID = (int)reader["Country_ID"],
                    Country_Name = reader["Country_Name"].ToString(),
                },
                Regions = new Region
                {
                    Region_ID = (int)reader["Region_ID"],
                    Region_Name = reader["Region_Name"].ToString(),
                },
                Departments = new Department
                {
                    Depa_ID = (int)reader["Depa_ID"],
                    Depa_Name = reader["Depa_Name"].ToString(),
                },
                Provinces = new Province
                {
                    Prov_ID = (int)reader["Prov_ID"],
                    Prov_Name = reader["Prov_Name"].ToString(),
                },
                //Banks = new Bank
                //{
                //    Bank_ID = (int)reader["Bank_ID"],
                //    Bank_Cod = reader["Bank_Cod"].ToString(),
                //    Bank_Name = reader["Bank_Name"].ToString()
                //},
                //Currencys = new Currency
                //{
                //    Currency_ID = (int)reader["Currency_ID"],
                //    Currency_Cod = reader["Currency_Cod"].ToString()
                //},
                DocIdentitys= new DocIdentity
                {
                    DocIdent_ID = (int)reader["DocIdent_ID"],
                    DocIdent_Cod = reader["DocIdent_Cod"].ToString(),
                    DocIdent_Name= reader["DocIdent_Name"].ToString()
                }
            };
        }

        public int Update(Vendor model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Vendor_Update";

                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", model.Vendor_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_TaxID", model.Vendor_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_CatPers", model.Vendor_CatPers));
                cmd.Parameters.Add(new SqlParameter("@DocIdent_ID", model.DocIdent_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Desc", model.Vendor_Desc));
                cmd.Parameters.Add(new SqlParameter("@Vendor_LastName", model.Vendor_LastName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_SurName", model.Vendor_SurName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Address", model.Vendor_Address));
                cmd.Parameters.Add(new SqlParameter("@Country_ID", model.Country_ID));
                cmd.Parameters.Add(new SqlParameter("@Region_ID", model.Region_ID));
                cmd.Parameters.Add(new SqlParameter("@Depa_ID", model.Depa_ID));
                cmd.Parameters.Add(new SqlParameter("@Prov_ID", model.Prov_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Distric", model.Vendor_Distric));
                cmd.Parameters.Add(new SqlParameter("@Vendor_CelPhone", model.Vendor_CelPhone));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Email", model.Vendor_Email));
                cmd.Parameters.Add(new SqlParameter("@Vendor_DetracPorc", model.Vendor_DetracPorc));

                cmd.Parameters.Add(new SqlParameter("@Bank_ID_AcctLocal_NO", model.Bank_ID_AcctLocal_NO));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID_AcctLocal_NO", model.Currency_ID_AcctLocal_NO));
                cmd.Parameters.Add(new SqlParameter("@Vendor_AcctLocal_NO", model.Vendor_AcctLocal_NO));

                cmd.Parameters.Add(new SqlParameter("@Bank_ID_AcctLocalCCI_NO", model.Bank_ID_AcctLocalCCI_NO));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID_AcctLocalCCI_NO", model.Currency_ID_AcctLocalCCI_NO));
                cmd.Parameters.Add(new SqlParameter("@Vendor_AcctLocalCCI_NO", model.Vendor_AcctLocalCCI_NO));

                cmd.Parameters.Add(new SqlParameter("@Bank_ID_AcctDetracc_NO", model.Bank_ID_AcctDetracc_NO));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID_AcctDetracc_NO", model.Currency_ID_AcctDetracc_NO));
                cmd.Parameters.Add(new SqlParameter("@Vendor_AcctDetracc_NO", model.Vendor_AcctDetracc_NO));

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
