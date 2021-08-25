using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Collect;
using SGC.InterfaceServices.CM.Collect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.FI.DataMaster;
using SGC.Entities.Entities.XX.Finance;
using System.Data;

namespace SGC.Services.CM.Collect
{
    public class ServiceExpCollectorHead : IServiceExpCollectorHead
    {
        private readonly string _context;

        public ServiceExpCollectorHead(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public async Task<List<ExpCollectorHead>> Search(JObject obj)
        {
            var response = new List<ExpCollectorHead>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectorHead_Search";
                cmd.Parameters.Add(new SqlParameter("@TPayColl_ID", obj["tPayColl_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToExpCollectorHead(reader));
                    }
                }

                foreach (ExpCollectorHead Exp in response) {

                    if (Exp.ExpColIH_Type != "IN") {
                        Exp.ExpColIH_TotAmountDetails = await this.GetTotalAmountDetails(Exp.ExpColIH_ID);
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



        public async Task<decimal> GetTotalAmountDetails(int id)
        {
            decimal response = 0;
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[ExpCollectorHead_GetAmountDetails]";
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_ID", id));

                //cmd.Parameters.Add("@Result", System.Data.SqlDbType.Decimal).Direction = System.Data.ParameterDirection.ReturnValue;
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = (decimal)reader["SumTotal"];
                    }
                }

                //var resul = await cmd.ExecuteReaderAsync();
                //resul = (decimal)cmd.Parameters["@Result"].Value;

                await conn.CloseAsync();
                return response;
            }
            catch (Exception e)
            {
                return response;// 
                throw e;
            }
        }

        public async Task<List<ExpCollectMaster>> SearchExpMaster()
        {
            var response = new List<ExpCollectMaster>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectMaster_Search";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToExpMaster(reader));
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

        private ExpCollectorHead MapToExpCollectorHead(SqlDataReader reader)
        {
            return new ExpCollectorHead()
            {
                ExpColIH_ID = (int)reader["ExpColIH_ID"],
                TPayColl_ID = (int)reader["TPayColl_ID"],
                Company_ID = (int)reader["Company_ID"],
                ExpColIH_NO = reader["ExpColIH_NO"].ToString(),
                MExpColl_ID = (int)reader["MExpColl_ID"],
                Zone_ID = (int)reader["Zone_ID"],
                Period_ID = (int)reader["Period_ID"],
                Currency_ID = (int)reader["Currency_ID"],
                CompPago_ID = (int)reader["CompPago_ID"],
                ExpColIH_TotAmount = (decimal)reader["ExpColIH_TotAmount"],
                ExpColIH_DocDate = (DateTime)reader["ExpColIH_DocDate"],
                ExpColIH_DocNO = reader["ExpColIH_DocNO"].ToString(),
                ExpColIH_Type = reader["ExpColIH_Type"].ToString(),
                ExpColIH_Desc = reader["ExpColIH_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                ExpColIH_Status = reader["ExpColIH_Status"].ToString(),

              
                Currency = new Currency
                {
                    Currency_Cod = reader["Currency_Cod"].ToString(),
                    Currency_Name = reader["Currency_Name"].ToString(),
                },
                Zone = new Zone
                {
                    Zone_Cod = reader["Zone_Cod"].ToString(),
                    Zone_Name = reader["Zone_Name"].ToString(),
                },
                ComprobanteDePago = new ComprobanteDePago
                {
                    CompPago_ID = (int)reader["CompPago_ID"],
                    CompPago_Cod = reader["CompPago_Cod"].ToString(),
                    CompPago_Desc = reader["CompPago_Desc"].ToString(),
                },
                ExpCollectMaster = new ExpCollectMaster
                {
                    MExpColl_ID = (int)reader["MExpColl_ID"],
                    MExpColl_Cod = reader["MExpColl_Cod"].ToString(),
                    MExpColl_Name = reader["MExpColl_Name"].ToString(),
                },
            };
        }

        private ExpCollectMaster MapToExpMaster(SqlDataReader reader)
        {
            return new ExpCollectMaster()
            {
                MExpColl_ID = (int)reader["MExpColl_ID"],
                MExp_ID = (int)reader["MExp_ID"],
                Company_ID = (int)reader["Company_ID"],
                MExpColl_Cod = reader["MExpColl_Cod"].ToString(),
                UM_ID = (int)reader["UM_ID"],
                MExpColl_Categ = reader["MExpColl_Categ"].ToString(),
                MExpColl_Name = reader["MExpColl_Name"].ToString(),
                MExpColl_Status = reader["MExpColl_Status"].ToString(),
            };
        }

        public async Task<int> Add(ExpCollectorHead model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectorHeadIndirect_Add";
                cmd.Parameters.Add(new SqlParameter("@TPayColl_ID", model.TPayColl_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_NO", model.ExpColIH_NO));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", model.Period_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_ID", model.MExpColl_ID));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID", model.Currency_ID));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_TotAmount", model.ExpColIH_TotAmount));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_DocDate", model.ExpColIH_DocDate));
                cmd.Parameters.Add(new SqlParameter("@CompPago_ID", model.CompPago_ID));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_DocNO", model.ExpColIH_DocNO));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_Type", model.@ExpColIH_Type));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_Desc", model.ExpColIH_Desc));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                await conn.OpenAsync();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                await conn.CloseAsync();

                if (model.ExpColIH_Type == "DR" && resul > 0)
                {
                    await DetailsManagement(model.ExpCollectorDetails, resul, model.Modified_User);
                }

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }

        public async Task<int> Update(ExpCollectorHead model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectorHeadIndirect_Update";
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_ID", model.ExpColIH_ID));
                cmd.Parameters.Add(new SqlParameter("@Zone_ID", model.Zone_ID));
                cmd.Parameters.Add(new SqlParameter("@MExpColl_ID", model.MExpColl_ID));
                cmd.Parameters.Add(new SqlParameter("@Currency_ID", model.Currency_ID));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_TotAmount", model.ExpColIH_TotAmount));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_DocDate", model.ExpColIH_DocDate));
                cmd.Parameters.Add(new SqlParameter("@CompPago_ID", model.CompPago_ID));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_DocNO", model.ExpColIH_DocNO));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_Type", model.@ExpColIH_Type));
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_Desc", model.ExpColIH_Desc));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));
                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                
                await conn.OpenAsync();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                await conn.CloseAsync();
                if (model.ExpColIH_Type == "DR" && resul == 0) {    
                     await DetailsManagement( model.ExpCollectorDetails, model.ExpColIH_ID, model.Modified_User);
                }

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }



        public async Task<int> DetailsManagement(List<ExpCollectorDetails> expCollectorDetails, int expColIH_ID, string user)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[ExpCollectorDetails_management]";
                cmd.Parameters.Add(new SqlParameter("@ExpColIH_ID", expColIH_ID));
                cmd.Parameters.Add(new SqlParameter("@User", user));
                SqlParameter parLeyMineralDetail = SetExpDetail("ExpCollectorDetails", expCollectorDetails);
                cmd.Parameters.Add(parLeyMineralDetail);
                //Output
                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                await conn.OpenAsync();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                await conn.CloseAsync();

                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }

        }
        public SqlParameter SetExpDetail(string name, List<ExpCollectorDetails> expCollectorDetails)
        {
            try
            {
                DataTable table = new DataTable("dbo.ExpCollectorDetails");
                table.Columns.Add("ExpColID_ID", typeof(int));
                table.Columns.Add("ExpColIH_ID", typeof(int));
                table.Columns.Add("Batch_ID", typeof(int));
                table.Columns.Add("ExpColID_Amount", typeof(decimal));
                table.Columns.Add("ExpColID_Status", typeof(string));


                foreach (ExpCollectorDetails expDet in expCollectorDetails)
                    table.Rows.Add(new object[] {   expDet.ExpColID_ID,
                                                    expDet.ExpColIH_ID,
                                                    expDet.Batch_ID,
                                                    expDet.ExpColID_Amount,
                                                    expDet.ExpColID_Status,
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.ExpCollectorDetails";

                return parameter;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }
        public async Task<List<ExpCollectorDetails>> GetBatches(int id)
        {
            var response = new List<ExpCollectorDetails>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].ExpCollectorHeadIndirectGet_Batches";

                cmd.Parameters.Add(new SqlParameter("@ExpColIH_ID", id));


                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToDetailsExp(reader));
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

        private ExpCollectorDetails MapToDetailsExp(SqlDataReader reader)
        {
            return new ExpCollectorDetails()
            {
                ExpColID_ID = (int)reader["ExpColID_ID"],
                ExpColIH_ID = (int)reader["ExpColIH_ID"],
                Batch_ID = (int)reader["Batch_ID"],
                ExpColID_Amount = (decimal)reader["ExpColID_Amount"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                ExpColID_Status = reader["ExpColID_Status"].ToString(),

                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
                Zone_Name = reader["zone_Name"].ToString(),
            };
        }

    }
}