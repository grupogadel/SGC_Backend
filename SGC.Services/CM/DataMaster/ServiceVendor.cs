using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
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
                //cmd.Parameters.Add(new SqlParameter("@Orig_Cod", model.Orig_Cod));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_TaxID", model.Vendor_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_CatPers", model.Vendor_CatPers));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Desc", model.Vendor_Desc));
                cmd.Parameters.Add(new SqlParameter("@Vendor_LastName", model.Vendor_LastName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_SurName", model.Vendor_SurName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Address", model.Vendor_Address));
                cmd.Parameters.Add(new SqlParameter("@Dist_ID", model.Dist_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_CelPhone", model.Vendor_CelPhone));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Email", model.Vendor_Email));
                cmd.Parameters.Add(new SqlParameter("@Bank_Acct_Cod", model.Bank_Acct_Cod));
                cmd.Parameters.Add(new SqlParameter("@Vendor_BankAcct", model.Vendor_BankAcct));
                cmd.Parameters.Add(new SqlParameter("@Bank_AcctDet_Cod", model.Bank_AcctDet_Cod));
                cmd.Parameters.Add(new SqlParameter("@Vendor_BankAcctDet", model.Vendor_BankAcctDet));
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
            throw new NotImplementedException();
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
                Vendor_Cod = reader["Vendor_Cod"].ToString(),
                //Zone_ID = (int)reader["Zone_ID"],
                Company_ID = (int)reader["Company_ID"],
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Vendor_CatPers = reader["Vendor_CatPers"].ToString(),
                Vendor_Desc = reader["Vendor_Desc"].ToString(),
                Vendor_LastName = reader["Vendor_LastName"].ToString(),
                Vendor_SurName = reader["Vendor_SurName"].ToString(),
                Vendor_Address = reader["Vendor_Address"].ToString(),
                Dist_ID = (int)reader["Dist_ID"],
                Vendor_CelPhone= reader["Vendor_CelPhone"].ToString(),
                Vendor_Email= reader["Vendor_Email"].ToString(),
                Bank_Acct_Cod = reader["Bank_Acct_Cod"].ToString(),
                Vendor_BankAcct = reader["Vendor_BankAcct"].ToString(),
                Bank_AcctDet_Cod = reader["Bank_AcctDet_Cod"].ToString(),
                Vendor_BankAcctDet = reader["Vendor_BankAcctDet"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Vendor_Status = reader["Vendor_Status"].ToString()
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
                //cmd.Parameters.Add(new SqlParameter("@Orig_Cod", model.Orig_Cod));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_TaxID", model.Vendor_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_CatPers", model.Vendor_CatPers));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Desc", model.Vendor_Desc));
                cmd.Parameters.Add(new SqlParameter("@Vendor_LastName", model.Vendor_LastName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_SurName", model.Vendor_SurName));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Address", model.Vendor_Address));
                cmd.Parameters.Add(new SqlParameter("@Dist_ID", model.Dist_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_CelPhone", model.Vendor_CelPhone));
                cmd.Parameters.Add(new SqlParameter("@Vendor_Email", model.Vendor_Email));
                cmd.Parameters.Add(new SqlParameter("@Bank_Acct_Cod", model.Bank_Acct_Cod));
                cmd.Parameters.Add(new SqlParameter("@Vendor_BankAcct", model.Vendor_BankAcct));
                cmd.Parameters.Add(new SqlParameter("@Bank_AcctDet_Cod", model.Bank_AcctDet_Cod));
                cmd.Parameters.Add(new SqlParameter("@Vendor_BankAcctDet", model.Vendor_BankAcctDet));
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
