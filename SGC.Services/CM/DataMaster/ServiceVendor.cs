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
                cmd.Parameters.Add(new SqlParameter("@Vendor_Class", model.Vendor_Class));
                cmd.Parameters.Add(new SqlParameter("@Country_ID", model.Country_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Type", model.Vendor_Type));
                cmd.Parameters.Add(new SqlParameter("@Vendor_PostalCod", model.Vendor_PostalCod));
                cmd.Parameters.Add(new SqlParameter("@Vendor_LastName", model.Vendor_LastName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_SurName", model.Vendor_SurName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Address", model.Vendor_Address));
                cmd.Parameters.Add(new SqlParameter("@Dist_ID", model.Dist_ID));
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

        // DELETE: api/Vendor/Delete/1
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

        public Vendor GetRuc(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Vendor_GetRuc";
                cmd.Parameters.Add(new SqlParameter("@Vendor_TaxID", id));

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
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Vendor_CatPers = reader["Vendor_CatPers"].ToString(),
                DocIdent_ID = (int)reader["DocIdent_ID"],
                Vendor_Desc = reader["Vendor_Desc"].ToString(),
                Vendor_LastName = reader["Vendor_LastName"].ToString(),
                Vendor_SurName = reader["Vendor_SurName"].ToString(),
                Vendor_Address = reader["Vendor_Address"].ToString(),
                Dist_ID = (int)reader["Dist_ID"],
                Vendor_CelPhone = reader["Vendor_CelPhone"].ToString(),
                Vendor_Email = reader["Vendor_Email"].ToString(),
                Vendor_DetracPorc = (decimal)reader["Vendor_DetracPorc"],

                Country_ID = (int)reader["Country_ID"],
                Vendor_Class = reader["Vendor_Class"].ToString(),
                Vendor_Type = reader["Vendor_Type"].ToString(),
                Vendor_PostalCod = reader["Vendor_PostalCod"].ToString(),

                Bank_ID_AcctLocal_NO = reader["Bank_ID_AcctLocal_NO"] == DBNull.Value ? 0 : (int)reader["Bank_ID_AcctLocal_NO"],
                Currency_ID_AcctLocal_NO = reader["Currency_ID_AcctLocal_NO"] == DBNull.Value ? 0 : (int)reader["Currency_ID_AcctLocal_NO"],
                Vendor_AcctLocal_NO = reader["Vendor_AcctLocal_NO"] == DBNull.Value ? null : reader["Vendor_AcctLocal_NO"].ToString(),

                Bank_ID_AcctLocalCCI_NO = reader["Bank_ID_AcctLocalCCI_NO"] == DBNull.Value ? 0 : (int)reader["Bank_ID_AcctLocalCCI_NO"],
                Currency_ID_AcctLocalCCI_NO = reader["Currency_ID_AcctLocalCCI_NO"] == DBNull.Value ? 0 : (int)reader["Currency_ID_AcctLocalCCI_NO"],
                Vendor_AcctLocalCCI_NO = reader["Vendor_AcctLocalCCI_NO"] == DBNull.Value ? null : reader["Vendor_AcctLocalCCI_NO"].ToString(),

                Bank_ID_AcctDetracc_NO = reader["Bank_ID_AcctDetracc_NO"] == DBNull.Value ? 0 : (int)reader["Bank_ID_AcctDetracc_NO"],
                Currency_ID_AcctDetracc_NO = reader["Currency_ID_AcctDetracc_NO"] == DBNull.Value ? 0 : (int)reader["Currency_ID_AcctDetracc_NO"],
                Vendor_AcctDetracc_NO = reader["Vendor_AcctDetracc_NO"] == DBNull.Value ? null : reader["Vendor_AcctDetracc_NO"].ToString(),

                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Vendor_Status = reader["Vendor_Status"].ToString(),

                Country = new Country
                {
                    Country_ID = reader["Country_ID"] == DBNull.Value ? 0 : (int)reader["Country_ID"],
                    Country_Name = reader["Country_Name"] == DBNull.Value ? "" : reader["Country_Name"].ToString(),
                },

                Districts = new District
                {
                    Dist_ID = reader["Dist_ID"] == DBNull.Value ? 0 : (int)reader["Dist_ID"],
                    Dist_Name = reader["Dist_Name"] == DBNull.Value ? "" : reader["Dist_Name"].ToString(),
                    Provinces = new Province
                    {
                        Prov_ID = reader["Prov_ID"] == DBNull.Value ? 0 : (int)reader["Prov_ID"],
                        Prov_Name = reader["Prov_Name"] == DBNull.Value ? "" : reader["Prov_Name"].ToString(),
                        Departments = new Department
                        {
                            Depa_ID = reader["Depa_ID"] == DBNull.Value ? 0 : (int)reader["Depa_ID"],
                            Depa_Name = reader["Depa_Name"] == DBNull.Value ? "" : reader["Depa_Name"].ToString(),
                            Regions = new Region
                            {
                                Region_ID = reader["Region_ID"] == DBNull.Value ? 0 : (int)reader["Region_ID"],
                                Region_Name = reader["Region_Name"] == DBNull.Value ? "" : reader["Region_Name"].ToString(),
                                Countrys = new Country
                                {
                                    Country_ID = reader["Country_ID"] == DBNull.Value ? 0 : (int)reader["Country_ID"],
                                    Country_Name = reader["Country_Name"] == DBNull.Value ? "" : reader["Country_Name"].ToString(),
                                }
                            }
                        }
                    }
                },
                DocIdentitys = new DocIdentity
                {
                    DocIdent_ID = (int)reader["DocIdent_ID"],
                    DocIdent_Cod = reader["DocIdent_Cod"].ToString(),
                    DocIdent_Desc = reader["DocIdent_Desc"].ToString()
                },
                Banks = new Bank
                {
                    //Bank_ID = (int)reader["Bank_ID"],
                    //Bank_Cod = reader["Bank_Cod"].ToString(),
                    //Bank_Name = reader["Bank_Name"].ToString()

                    Bank_ID = reader["Bank_ID"] == DBNull.Value ? 0 : (int)reader["Bank_ID"],
                    Bank_Cod = reader["Bank_Cod"] == DBNull.Value ? null : reader["Bank_Cod"].ToString(),
                    Bank_Name = reader["Bank_Name"] == DBNull.Value ? null : reader["Bank_Name"].ToString(),
                },
                Banks1 = new Bank
                {
                    //Bank_ID = (int)reader["Bank_ID1"],
                    //Bank_Cod = reader["Bank_Cod1"].ToString(),
                    //Bank_Name = reader["Bank_Name1"].ToString()

                    Bank_ID = reader["Bank_ID1"] == DBNull.Value ? 0 : (int)reader["Bank_ID1"],
                    Bank_Cod = reader["Bank_Cod1"] == DBNull.Value ? null : reader["Bank_Cod1"].ToString(),
                    Bank_Name = reader["Bank_Name1"] == DBNull.Value ? null : reader["Bank_Name1"].ToString(),
                },
                Banks2 = new Bank
                {
                    //Bank_ID = (int)reader["Bank_ID2"],
                    //Bank_Cod = reader["Bank_Cod2"].ToString(),
                    //Bank_Name = reader["Bank_Name2"].ToString()

                    Bank_ID = reader["Bank_ID2"] == DBNull.Value ? 0 : (int)reader["Bank_ID2"],
                    Bank_Cod = reader["Bank_Cod2"] == DBNull.Value ? null : reader["Bank_Cod2"].ToString(),
                    Bank_Name = reader["Bank_Name2"] == DBNull.Value ? null : reader["Bank_Name2"].ToString(),
                },
                Currencys = new Currency
                {
                    //Currency_ID = (int)reader["Currency_ID"],
                    //Currency_Cod = reader["Currency_Cod"].ToString(),
                    //Currency_Name = reader["Currency_Name"].ToString()

                    Currency_ID = reader["Currency_ID"] == DBNull.Value ? 0 : (int)reader["Currency_ID"],
                    Currency_Cod = reader["Currency_Cod"] == DBNull.Value ? null : reader["Currency_Cod"].ToString(),
                    Currency_Name = reader["Currency_Name"] == DBNull.Value ? null : reader["Currency_Name"].ToString(),
                },
                Currencys1 = new Currency
                {
                    //Currency_ID = (int)reader["Currency_ID1"],
                    //Currency_Cod = reader["Currency_Cod1"].ToString(),
                    //Currency_Name = reader["Currency_Name1"].ToString()

                    Currency_ID = reader["Currency_ID1"] == DBNull.Value ? 0 : (int)reader["Currency_ID1"],
                    Currency_Cod = reader["Currency_Cod1"] == DBNull.Value ? null : reader["Currency_Cod1"].ToString(),
                    Currency_Name = reader["Currency_Name1"] == DBNull.Value ? null : reader["Currency_Name1"].ToString(),
                },
                Currencys2 = new Currency
                {
                    //Currency_ID = (int)reader["Currency_ID2"],
                    //Currency_Cod = reader["Currency_Cod2"].ToString(),
                    //Currency_Name = reader["Currency_Name2"].ToString()

                    Currency_ID = reader["Currency_ID2"] == DBNull.Value ? 0 : (int)reader["Currency_ID2"],
                    Currency_Cod = reader["Currency_Cod2"] == DBNull.Value ? null : reader["Currency_Cod2"].ToString(),
                    Currency_Name = reader["Currency_Name2"] == DBNull.Value ? null : reader["Currency_Name2"].ToString(),
                }
            };
        }
        public async Task<List<Vendor>> Search(JObject obj)
        {
            var response = new List<Vendor>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Vendor_Search";

                cmd.Parameters.Add(new SqlParameter("@Vendor_TaxID", obj["cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));

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
                cmd.Parameters.Add(new SqlParameter("@Vendor_Class", model.Vendor_Class));
                cmd.Parameters.Add(new SqlParameter("@Country_ID", model.Country_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Type", model.Vendor_Type));
                cmd.Parameters.Add(new SqlParameter("@Vendor_PostalCod", model.Vendor_PostalCod));
                cmd.Parameters.Add(new SqlParameter("@Vendor_LastName", model.Vendor_LastName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_SurName", model.Vendor_SurName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Address", model.Vendor_Address));
                cmd.Parameters.Add(new SqlParameter("@Dist_ID", model.Dist_ID));
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
