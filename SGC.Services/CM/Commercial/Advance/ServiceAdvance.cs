using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Advance;
using SGC.InterfaceServices.CM.Commercial.Advance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.CM.Commercial.Advance
{
    public class ServiceAdvance: IServiceAdvance
    {
        private readonly string _context;
        public ServiceAdvance(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        //POST: api/Advance/Search/{}
        public List<AdvanceHead> Search(JObject obj)
        {
            var advanceHead = new List<AdvanceHead>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].AdvanceHead_Search";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["idVendor"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Period_NO", obj["noPeriod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@AdvanH_NO", obj["noAdvanH"].ToObject<string>()));

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        advanceHead.Add(MapToAdvanceHead(reader));
                    }
                }

                cmd.CommandText = "[CM].AdvanceDetails_Search";

                foreach (var ah in advanceHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AdvanH_ID", ah.AdvanH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ah.AdvanceDetails.Add(MapToAdvanceDetails(dr));
                        }
                    }
                }
                conn.Close();
                return advanceHead;
            }
            catch (Exception e)
            {
                return advanceHead;
                throw e;
            }
        }

        //POST: api/Advance/SearchForDiscounts/{}
        public List<AdvanceHead> SearchForDiscounts(JObject obj)
        {
            var advanceHead = new List<AdvanceHead>();
            var advanceDetails = new List<AdvanceDetails>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].AdvanceHead_SearchForDiscounts";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@AdvanH_NO", obj["noAdvanH"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["idVendor"].ToObject<string>()));
                
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        advanceHead.Add(MapToAdvanceHead(reader));
                    }
                }

                cmd.CommandText = "[CM].AdvanceDetails_Search";

                foreach (var ah in advanceHead)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AdvanH_ID", ah.AdvanH_ID));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ah.AdvanceDetails.Add(MapToAdvanceDetailsForDiscounts(dr));
                        }
                    }
                }

                conn.Close();
                return advanceHead;
            }
            catch (Exception e)
            {
                return advanceHead;
                throw e;
            }
        }

        //POST: api/Advance/Add
        public int Add(AdvanceHead model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Advance_Add";
                //Head
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_NO", model.Period_NO));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", model.Vendor_ID));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Detail
                SqlParameter parAdvanceDetails = GetAdvanceDetails("tabAdvanceDetails", model.AdvanceDetails);
                cmd.Parameters.Add(parAdvanceDetails);
                //Output
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
		
		//PUT: api/Advance/Update/{}
        public int Update(AdvanceDetails model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Advance_Update";
                //Detail
                //cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@AdvanD_ID", model.AdvanD_ID));
				cmd.Parameters.Add(new SqlParameter("@AdvanH_ID", model.AdvanH_ID));
                cmd.Parameters.Add(new SqlParameter("@BatchM_ID", model.BatchM_ID));
				cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
				//cmd.Parameters.Add(new SqlParameter("@AdvanD_Days", model.AdvanD_Days));
				cmd.Parameters.Add(new SqlParameter("@AdvanD_Desc", model.AdvanD_Desc));
				cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
				cmd.Parameters.Add(new SqlParameter("@Currency_ID", model.Currency_ID));
				cmd.Parameters.Add(new SqlParameter("@AdvanD_Curr", model.AdvanD_Curr));
				cmd.Parameters.Add(new SqlParameter("@AdvanD_AmountL", model.AdvanD_AmountL));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));
                //Output
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
		
		//PUT: api/Advance/Approb/{}
        public int Approb(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Advance_Approb";
                //Detail
                cmd.Parameters.Add(new SqlParameter("@AdvanD_ID",obj["id"].ToObject<int>()));
				cmd.Parameters.Add(new SqlParameter("@AdvanD_ApprUser", obj["user"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Action", obj["action"].ToObject<string>()));
                //Output
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
		
		//POST: api/Advance/Balance/{}
        public async Task<List<AdvanceBalance>> Balance(JObject obj)
        {
            var advanceBalance = new List<AdvanceBalance>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Advance_Balance";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["idVendor"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Year", obj["noYear"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Currency", obj["noCurrency"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = cmd.ExecuteReader())
                {
                    while (await reader.ReadAsync())
                    {
                        advanceBalance.Add(MapToAdvanceBalance(reader));
                    }
                }

                await conn.CloseAsync();
                return advanceBalance;
            }
            catch (Exception e)
            {
                return advanceBalance;
                throw e;
            }
        }

        public SqlParameter GetAdvanceDetails(string name, List<AdvanceDetails> listAdvanceDetails)
        {
            //logger.InfoFormat("Servicio, Rol:   GetAccesos(string name=:{0}, List<AccesoModel> lstListaAcc)", name);

            try
            {
                DataTable table = new DataTable("CM.tabAdvanceDetails");
                table.Columns.Add("AdvanD_ID", typeof(int));
                table.Columns.Add("AdvanD_Item", typeof(int));
                table.Columns.Add("BatchM_ID", typeof(int));
                table.Columns.Add("Zone_ID", typeof(int));
                table.Columns.Add("Currency_ID", typeof(int));
                table.Columns.Add("Collec_ID", typeof(int));
                table.Columns.Add("AdvanD_Days", typeof(int));
                table.Columns.Add("AdvanD_Desc", typeof(string));
                table.Columns.Add("AdvanD_AmountL", typeof(decimal));
                table.Columns.Add("AdvanD_Curr", typeof(string));

                int count = 1;

                foreach (AdvanceDetails maqCom in listAdvanceDetails)
                    
                    table.Rows.Add(new object[] { maqCom.AdvanD_ID,
                                                  count++,
                                                  maqCom.BatchM_ID,
                                                  maqCom.Zone_ID,
                                                  maqCom.Currency_ID,
                                                  maqCom.Collec_ID,
                                                  maqCom.AdvanD_Days,
                                                  maqCom.AdvanD_Desc,
                                                  maqCom.AdvanD_AmountL,
                                                  maqCom.AdvanD_Curr
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "CM.tabAdvanceDetails";

                return parameter;
            }
            catch (Exception e)
            {
                //logger.ErrorFormat("Servicio, Rol:  Error en el metodo GetAccesos(string name=:{0}, List<AccesoModel> lstListaAcc)", name);
                //logger.ErrorFormat("Exception - {0}", e);
                return null;
                throw e;
            }
        }

        //GET: api/Advance/GetAll/1
        public async Task<List<Discounts>> DiscountsGetAll(int id)
        {
            var discounts = new List<Discounts>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Discounts_GetAll";

                cmd.Parameters.Add(new SqlParameter("@AdvanD_ID", id));

                await conn.OpenAsync();
                using (var reader = cmd.ExecuteReader())
                {
                    while (await reader.ReadAsync())
                    {
                        discounts.Add(MapToDiscountsDetails(reader));
                    }
                }
                await conn.CloseAsync();
                return discounts;
            }
            catch (Exception e)
            {
                return discounts;
                throw e;
            }
        }

        //POST: api/Advance/DiscountsAdd
        public int DiscountsAdd(ModelDiscounts model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Advance_DiscountsAdd";
                //Head
                cmd.Parameters.Add(new SqlParameter("@AdvanD_ID", model.AdvanD_ID));
                cmd.Parameters.Add(new SqlParameter("@AdvanD_AmountL", model.AdvanD_AmountL));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                cmd.Parameters.Add(new SqlParameter("@AdvanD_Curr", model.AdvanD_Curr));
                //Detail
                SqlParameter parDiscountsDetails = GetDiscountsDetails("tabDiscountsDetails", model.DiscountsDetails);
                cmd.Parameters.Add(parDiscountsDetails);
                //Output
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

        //PUT: api/Advance/DiscountsEdit
        public int DiscountsEdit(ModelDiscounts model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Advance_DiscountsEdit";
                //Details
                cmd.Parameters.Add(new SqlParameter("@AdvanD_ID", model.AdvanD_ID));
                cmd.Parameters.Add(new SqlParameter("@AdvanD_AmountL", model.AdvanD_AmountL));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));
                cmd.Parameters.Add(new SqlParameter("@AdvanD_Curr", model.AdvanD_Curr));
                //Detail
                SqlParameter parDiscountsDetails = GetDiscountsDetails("tabDiscountsDetails", model.DiscountsDetails);
                cmd.Parameters.Add(parDiscountsDetails);
                //Output
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

        public SqlParameter GetDiscountsDetails(string name, List<Discounts> listDiscountsDetails)
        {
            //logger.InfoFormat("Servicio, Rol:   GetAccesos(string name=:{0}, List<AccesoModel> lstListaAcc)", name);

            try
            {   
                DataTable table = new DataTable("CM.tabDiscountsDetails");
                table.Columns.Add("Discount_ID", typeof(int));
                table.Columns.Add("Discount_NO", typeof(string));
                table.Columns.Add("Currency_ID", typeof(int));
                table.Columns.Add("Discount_Curr", typeof(string));
                table.Columns.Add("Discount_AmountL", typeof(decimal));
                table.Columns.Add("Discount_PaidDate", typeof(DateTime));
                table.Columns.Add("Bank_ID", typeof(int));
                table.Columns.Add("Discount_BankAcct", typeof(string));
                table.Columns.Add("Discount_Refer", typeof(string));
                table.Columns.Add("Discount_Status", typeof(string));

                foreach (Discounts discDet in listDiscountsDetails)
                    
                    table.Rows.Add(new object[] { discDet.Discount_ID,
                                                  discDet.Discount_NO,
                                                  discDet.Currency_ID,
                                                  discDet.Discount_Curr,
                                                  discDet.Discount_AmountL,
                                                  discDet.Discount_PaidDate,
                                                  discDet.Bank_ID,
                                                  discDet.Discount_BankAcct,
                                                  discDet.Discount_Refer,
                                                  discDet.Discount_Status
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "CM.tabDiscountsDetails";

                return parameter;
            }
            catch (Exception e)
            {
                //logger.ErrorFormat("Servicio, Rol:  Error en el metodo GetAccesos(string name=:{0}, List<AccesoModel> lstListaAcc)", name);
                //logger.ErrorFormat("Exception - {0}", e);
                return null;
                throw e;
            }
        }




		
		private AdvanceBalance MapToAdvanceBalance(SqlDataReader reader)
        {
            return new AdvanceBalance()
            {
                Period_Cod = (string)reader["Period_Cod"],
                MPeriod_Name = (string)reader["MPeriod_Name"],
                Amount = (decimal)reader["Amount"]
            };
        }

        private AdvanceHead MapToAdvanceHead(SqlDataReader reader)
        {
            return new AdvanceHead()
            {
                AdvanH_ID = (int)reader["AdvanH_ID"],
                Company_ID = (int)reader["Company_ID"],
                Period_ID = (int)reader["Period_ID"],
                Period_NO = reader["Period_NO"].ToString(),
                Vendor_ID = (int)reader["Vendor_ID"],
                Vendor_FullName = reader["Vendor_SurName"].ToString() + " " + reader["Vendor_LastName"].ToString(),
                AdvanH_NO = reader["AdvanH_NO"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                AdvanH_Status = reader["AdvanH_Status"].ToString()
            };
        }

        private AdvanceDetails MapToAdvanceDetails(SqlDataReader reader)
        {
            return new AdvanceDetails()
            {
                AdvanD_ID = (int)reader["AdvanD_ID"],
                AdvanH_ID = (int)reader["AdvanH_ID"],
                AdvanD_Item = (int)reader["AdvanD_Item"],
                BatchM_ID = (int)reader["BatchM_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
                Zone_ID = (int)reader["Zone_ID"],
                Zone_Name = reader["Zone_Name"].ToString(),
                Collec_ID = (int)reader["Collec_ID"],
                Collec_FullName = reader["Collec_Name"].ToString() + " " + reader["Collec_LastName"].ToString(),
                AdvanD_Date = (DateTime)reader["AdvanD_Date"],
                Currency_ID = (int)reader["Currency_ID"],
                AdvanD_Curr = reader["AdvanD_Curr"].ToString(),
                AdvanD_ExchRateSale = reader["AdvanD_ExchRateSale"] == DBNull.Value ? (decimal?)null : (decimal)reader["AdvanD_ExchRateSale"],
                AdvanD_Desc = reader["AdvanD_Desc"].ToString(),
                AdvanD_ApprDate = reader["AdvanD_ApprDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AdvanD_ApprDate"],
                AdvanD_ApprUser = reader["AdvanD_ApprUser"].ToString(),
                AdvanD_AmountL = (decimal)reader["AdvanD_AmountL"],
                AdvanD_AmountF = (decimal)reader["AdvanD_AmountF"],
                AdvanD_Days = (int)reader["AdvanD_Days"],
                AdvanD_PayToDate = (DateTime)reader["AdvanD_PayToDate"],
                AdvanD_Status_Cod = reader["AdvanD_Status_Cod"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                AdvanD_Status = reader["AdvanD_Status"].ToString()
            };
        }

        private AdvanceDetails MapToAdvanceDetailsForDiscounts(SqlDataReader reader)
        {
            return new AdvanceDetails()
            {
                AdvanD_ID = (int)reader["AdvanD_ID"],
                AdvanH_ID = (int)reader["AdvanH_ID"],
                AdvanD_Item = (int)reader["AdvanD_Item"],
                BatchM_ID = (int)reader["BatchM_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
                Zone_ID = (int)reader["Zone_ID"],
                Zone_Name = reader["Zone_Name"].ToString(),
                Collec_ID = (int)reader["Collec_ID"],
                Collec_FullName = reader["Collec_Name"].ToString() + " " + reader["Collec_LastName"].ToString(),
                AdvanD_Date = (DateTime)reader["AdvanD_Date"],
                Currency_ID = (int)reader["Currency_ID"],
                AdvanD_Curr = reader["AdvanD_Curr"].ToString(),
                AdvanD_ExchRateSale = reader["AdvanD_ExchRateSale"] == DBNull.Value ? (decimal?)null : (decimal)reader["AdvanD_ExchRateSale"],
                AdvanD_Desc = reader["AdvanD_Desc"].ToString(),
                AdvanD_ApprDate = reader["AdvanD_ApprDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AdvanD_ApprDate"],
                AdvanD_ApprUser = reader["AdvanD_ApprUser"].ToString(),
                AdvanD_AmountL = (decimal)reader["AdvanD_AmountL"],
                AdvanD_AmountF = (decimal)reader["AdvanD_AmountF"],
                AdvanD_Days = (int)reader["AdvanD_Days"],
                AdvanD_PayToDate = (DateTime)reader["AdvanD_PayToDate"],
                AdvanD_PayFull= (bool)reader["AdvanD_PayFull"],
                AdvanD_AmountPayFull = reader["AdvanD_AmountPayFull"] == DBNull.Value ? (decimal?)null : (decimal)reader["AdvanD_AmountPayFull"],
                AdvanD_Status_Cod = reader["AdvanD_Status_Cod"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                AdvanD_Status = reader["AdvanD_Status"].ToString()
            };
        }

        private Discounts MapToDiscountsDetails(SqlDataReader reader)
        {
            return new Discounts()
            {
                Discount_ID = (int)reader["Discount_ID"],
                AdvanD_ID = (int)reader["AdvanD_ID"],
                Discount_NO = reader["Discount_NO"].ToString(),
                Currency_ID = (int)reader["Currency_ID"],
                Discount_Curr = reader["Discount_Curr"].ToString(),
                Discount_ExchRateSale = (decimal)reader["Discount_ExchRateSale"],
                Discount_AmountL = (decimal)reader["Discount_AmountL"],
                Discount_AmountF = (decimal)reader["Discount_AmountF"],
                Discount_PaidDate = (DateTime)reader["Discount_PaidDate"],
                Bank_ID = (int)reader["Bank_ID"],
                Bank_Name = reader["Bank_Name"].ToString(),
                Discount_BankAcct = reader["Discount_BankAcct"].ToString(),
                Discount_Refer = reader["Discount_Refer"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Discount_Status = reader["Discount_Status"].ToString()
            };
        }
    }
}
