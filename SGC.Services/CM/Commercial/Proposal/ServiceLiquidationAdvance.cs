using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Proposal;
using SGC.InterfaceServices.CM.Commercial.Proposal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.CM.Commercial.Proposal
{
    public class ServiceLiquidationAdvance : IServiceLiquidationAdvance
    {
        private readonly string _context;

        public ServiceLiquidationAdvance(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public async Task<List<LiquidationAdvance>> Search(JObject obj)
        {
            var response = new List<LiquidationAdvance>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[Liquidation_ProposalGetAll]";
                cmd.Parameters.Add(new SqlParameter("@LiquiH_ID", obj["liquiH_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToLiquidationAdvance(reader));
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
      
        

        private LiquidationAdvance MapToLiquidationAdvance(SqlDataReader reader)
        {
            return new LiquidationAdvance()
            {

                LiqAdv_ID = (int)reader["LiqAdv_ID"],
                LiquiH_ID = (int)reader["LiquiH_ID"],
                AdvanD_ID = (int)reader["AdvanD_ID"],
                LiqAdv_NO = reader["LiqAdv_NO"].ToString(),
                LiqAdv_DocSerieNO = reader["LiqAdv_DocSerieNO"].ToString(),
                LiqAdv_Date = (DateTime)reader["LiqAdv_Date"],
                LiqAdv_Amount = (decimal)reader["LiqAdv_Amount"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                LiqAdv_Status = reader["LiqAdv_Status"].ToString()
            };
        }



        public async Task<int> Add(ModelProposal model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[Liquidation_ProposalAdd]";

                //Head
                cmd.Parameters.Add(new SqlParameter("@LiquiH_ID", model.LiquiH_ID));
                cmd.Parameters.Add(new SqlParameter("@LiquiUser", model.LiquiUser));
                //Details
                SqlParameter parGetLiquidationAdvance = GetLiquidationAdvance("tabLiquidationAdvance", model.LiquidationAdvances);
                cmd.Parameters.Add(parGetLiquidationAdvance);
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


        public SqlParameter GetLiquidationAdvance(string name, List<LiquidationAdvance> liquidationAdvance)
        {
            try
            {
                DataTable table = new DataTable("CM.tabLiquidationAdvance");
                table.Columns.Add("LiqAdv_ID", typeof(int));
                table.Columns.Add("AdvanD_ID", typeof(int));
                table.Columns.Add("LiqAdv_NO", typeof(string));
                table.Columns.Add("LiqAdv_DocSerieNO", typeof(string));
                table.Columns.Add("LiqAdv_Date", typeof(DateTime));
                table.Columns.Add("LiqAdv_Amount", typeof(decimal));
                table.Columns.Add("BatchM_ID", typeof(int));
                table.Columns.Add("LiqAdv_Status", typeof(string));
                table.Columns.Add("Zone_ID", typeof(int));

                foreach (LiquidationAdvance liqAdv in liquidationAdvance)
                    table.Rows.Add(new object[] {   liqAdv.LiqAdv_ID,
                                                    liqAdv.AdvanD_ID,
                                                    liqAdv.LiqAdv_NO,
                                                    liqAdv.LiqAdv_DocSerieNO,
                                                    liqAdv.LiqAdv_Date,
                                                    liqAdv.LiqAdv_Amount,
                                                    liqAdv.BatchM_ID,
                                                    liqAdv.LiqAdv_Status,
                                                    liqAdv.Zone_ID
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "CM.tabLiquidationAdvance";

                return parameter;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }


    }
}
