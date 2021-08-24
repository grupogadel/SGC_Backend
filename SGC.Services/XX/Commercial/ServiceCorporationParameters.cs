using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using SGC.InterfaceServices.XX.Commercial;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.XX.Commercial
{
    public class ServiceCorporationParameters : IServiceCorporationParameters
    {
        private readonly string _context;

        public ServiceCorporationParameters(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/CorporationParameters/GetAll/1
        public async Task<List<CorporationParameters>> GetAll(int idCompany)
        {
            var response = new List<CorporationParameters>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CorporationParameters_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCorporationParameters(reader));
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
        private CorporationParameters MapToCorporationParameters(SqlDataReader reader)
        {
            return new CorporationParameters()
            {
                CorpP_ID = (int)reader["CorpP_ID"],
                Company_ID = (int)reader["Company_ID"],
                CorpP_Cod = reader["CorpP_Cod"].ToString(),
                CorpP_Desc = reader["CorpP_Desc"].ToString(),
                CorpP_WeigAuPor = reader["CorpP_WeigAuPor"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_WeigAuPor"],
                CorpP_WeigAuMin = reader["CorpP_WeigAuMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_WeigAuMin"],
                CorpP_WeigAuMax = reader["CorpP_WeigAuMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_WeigAuMax"],
                CorpP_LeyAuPor = reader["CorpP_LeyAuPor"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_LeyAuPor"],
                CorpP_LeyAuMin = reader["CorpP_LeyAuMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_LeyAuMin"],
                CorpP_LeyAuMax = reader["CorpP_LeyAuMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_LeyAuMax"],
                CorpP_LeyAgPor = reader["CorpP_LeyAgPor"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_LeyAgPor"],
                CorpP_LeyAgMin = reader["CorpP_LeyAgMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_LeyAgMin"],
                CorpP_LeyAgMax = reader["CorpP_LeyAgMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_LeyAgMax"],
                CorpP_HumiAuVal = reader["CorpP_HumiAuVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_HumiAuVal"],
                CorpP_HumiAuMin = reader["CorpP_HumiAuMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_HumiAuMin"],
                CorpP_HumiAuMax = reader["CorpP_HumiAuMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_HumiAuMax"],
                CorpP_HumiAgVal = reader["CorpP_HumiAgVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_HumiAgVal"],
                CorpP_HumiAgMin = reader["CorpP_HumiAgMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_HumiAgMin"],
                CorpP_HumiAgMax = reader["CorpP_HumiAgMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_HumiAgMax"],
                CorpP_RecovAuVal = reader["CorpP_RecovAuVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAuVal"],
                CorpP_RecovAuMin = reader["CorpP_RecovAuMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAuMin"],
                CorpP_RecovAuMax = reader["CorpP_RecovAuMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAuMax"],
                CorpP_RecovAgVal = reader["CorpP_RecovAgVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAgVal"],
                CorpP_RecovAgMin = reader["CorpP_RecovAgMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAgMin"],
                CorpP_RecovAgMax = reader["CorpP_RecovAgMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAgMax"],
                CorpP_RecovAu_Est = reader["CorpP_RecovAu_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAu_Est"],
                CorpP_RecovAu_EstMin = reader["CorpP_RecovAu_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAu_EstMin"],
                CorpP_RecovAu_EstMax = reader["CorpP_RecovAu_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAu_EstMax"],
                CorpP_RecovAg_Est = reader["CorpP_RecovAg_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAg_Est"],
                CorpP_RecovAg_EstMin = reader["CorpP_RecovAg_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAg_EstMin"],
                CorpP_RecovAg_EstMax = reader["CorpP_RecovAg_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_RecovAg_EstMax"],
                CorpP_MaquilaAuVal = reader["CorpP_MaquilaAuVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAuVal"],
                CorpP_MaquilaAuMin = reader["CorpP_MaquilaAuMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAuMin"],
                CorpP_MaquilaAuMax = reader["CorpP_MaquilaAuMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAuMax"],
                CorpP_MaquilaAgVal = reader["CorpP_MaquilaAgVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAgVal"],
                CorpP_MaquilaAgMin = reader["CorpP_MaquilaAgMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAgMin"],
                CorpP_MaquilaAgMax = reader["CorpP_MaquilaAgMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAgMax"],
                CorpP_MaquilaAu_Est = reader["CorpP_MaquilaAu_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAu_Est"],
                CorpP_MaquilaAu_EstMin = reader["CorpP_MaquilaAu_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAu_EstMin"],
                CorpP_MaquilaAu_EstMax = reader["CorpP_MaquilaAu_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAu_EstMax"],
                CorpP_MaquilaAg_Est = reader["CorpP_MaquilaAg_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAg_Est"],
                CorpP_MaquilaAg_EstMin = reader["CorpP_MaquilaAg_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAg_EstMin"],
                CorpP_MaquilaAg_EstMax = reader["CorpP_MaquilaAg_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MaquilaAg_EstMax"],
                CorpP_MarginPIAuVal = reader["CorpP_MarginPIAuVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginPIAuVal"],
                CorpP_MarginPIAuMin = reader["CorpP_MarginPIAuMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginPIAuMin"],
                CorpP_MarginPIAuMax = reader["CorpP_MarginPIAuMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginPIAuMax"],
                CorpP_MarginPIAgVal = reader["CorpP_MarginPIAgVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginPIAgVal"],
                CorpP_MarginPIAgMin = reader["CorpP_MarginPIAgMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginPIAgMin"],
                CorpP_MarginPIAgMax = reader["CorpP_MarginPIAgMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginPIAgMax"],
                CorpP_MarginAu_Est = reader["CorpP_MarginAu_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginAu_Est"],
                CorpP_MarginAu_EstMin = reader["CorpP_MarginAu_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginAu_EstMin"],
                CorpP_MarginAu_EstMax = reader["CorpP_MarginAu_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginAu_EstMax"],
                CorpP_MarginAg_Est = reader["CorpP_MarginAg_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginAg_Est"],
                CorpP_MarginAg_EstMin = reader["CorpP_MarginAg_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginAg_EstMin"],
                CorpP_MarginAg_EstMax = reader["CorpP_MarginAg_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_MarginAg_EstMax"],
                CorpP_ConsuCNQty = reader["CorpP_ConsuCNQty"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuCNQty"],
                CorpP_ConsuCNMin = reader["CorpP_ConsuCNMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuCNMin"],
                CorpP_ConsuCNMax = reader["CorpP_ConsuCNMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuCNMax"],
                CorpP_ConsuOHQty = reader["CorpP_ConsuOHQty"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuOHQty"],
                CorpP_ConsuOHMin = reader["CorpP_ConsuOHMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuOHMin"],
                CorpP_ConsuOHMax = reader["CorpP_ConsuOHMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuOHMax"],
                CorpP_ConsuCN_Est = reader["CorpP_ConsuCN_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuCN_Est"],
                CorpP_ConsuCN_EstMin = reader["CorpP_ConsuCN_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuCN_EstMin"],
                CorpP_ConsuCN_EstMax = reader["CorpP_ConsuCN_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuCN_EstMax"],
                CorpP_ConsuOH_Est = reader["CorpP_ConsuOH_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuOH_Est"],
                CorpP_ConsuOH_EstMin = reader["CorpP_ConsuOH_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuOH_EstMin"],
                CorpP_ConsuOH_EstMax = reader["CorpP_ConsuOH_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ConsuOH_EstMax"],
                CorpP_ExpAdmVal = reader["CorpP_ExpAdmVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpAdmVal"],
                CorpP_ExpAdmMin = reader["CorpP_ExpAdmMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpAdmMin"],
                CorpP_ExpAdmMax = reader["CorpP_ExpAdmMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpAdmMax"],
                CorpP_ExpAdm_Est = reader["CorpP_ExpAdm_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpAdm_Est"],
                CorpP_ExpAdm_EstMin = reader["CorpP_ExpAdm_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpAdm_EstMin"],
                CorpP_ExpAdm_EstMax = reader["CorpP_ExpAdm_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpAdm_EstMax"],
                CorpP_ExpLabVal = reader["CorpP_ExpLabVal"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpLabVal"],
                CorpP_ExpLabMin = reader["CorpP_ExpLabMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpLabMin"],
                CorpP_ExpLabMax = reader["CorpP_ExpLabMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpLabMax"],
                CorpP_ExpLab_Est = reader["CorpP_ExpLab_Est"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpLab_Est"],
                CorpP_ExpLab_EstMin = reader["CorpP_ExpLab_EstMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpLab_EstMin"],
                CorpP_ExpLab_EstMax = reader["CorpP_ExpLab_EstMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["CorpP_ExpLab_EstMax"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                CorpP_Status = reader["CorpP_Status"].ToString()
            };
        }
        public int Add(CorporationParameters model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CorporationParameters_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@CorpP_Cod", model.CorpP_Cod));
                cmd.Parameters.Add(new SqlParameter("@CorpP_Desc", model.CorpP_Desc));
                cmd.Parameters.Add(new SqlParameter("@CorpP_WeigAuPor", model.CorpP_WeigAuPor));
                cmd.Parameters.Add(new SqlParameter("@CorpP_WeigAuMin", model.CorpP_WeigAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_WeigAuMax", model.CorpP_WeigAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAuPor", model.CorpP_LeyAuPor));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAuMin", model.CorpP_LeyAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAuMax", model.CorpP_LeyAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAgPor", model.CorpP_LeyAgPor));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAgMin", model.CorpP_LeyAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAgMax", model.CorpP_LeyAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAuVal", model.CorpP_HumiAuVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAuMin", model.CorpP_HumiAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAuMax", model.CorpP_HumiAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAgVal", model.CorpP_HumiAgVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAgMin", model.CorpP_HumiAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAgMax", model.CorpP_HumiAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAuVal", model.CorpP_RecovAuVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAuMin", model.CorpP_RecovAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAuMax", model.CorpP_RecovAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAgVal", model.CorpP_RecovAgVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAgMin", model.CorpP_RecovAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAgMax", model.CorpP_RecovAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAu_Est", model.CorpP_RecovAu_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAu_EstMin", model.CorpP_RecovAu_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAu_EstMax", model.CorpP_RecovAu_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAg_Est", model.CorpP_RecovAg_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAg_EstMin", model.CorpP_RecovAg_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAg_EstMax", model.CorpP_RecovAg_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAuVal", model.CorpP_MaquilaAuVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAuMin", model.CorpP_MaquilaAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAuMax", model.CorpP_MaquilaAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAgVal", model.CorpP_MaquilaAgVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAgMin", model.CorpP_MaquilaAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAgMax", model.CorpP_MaquilaAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAu_Est", model.CorpP_MaquilaAu_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAu_EstMin", model.CorpP_MaquilaAu_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAu_EstMax", model.CorpP_MaquilaAu_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAg_Est", model.CorpP_MaquilaAg_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAg_EstMin", model.CorpP_MaquilaAg_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAg_EstMax", model.CorpP_MaquilaAg_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAuVal", model.CorpP_MarginPIAuVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAuMin", model.CorpP_MarginPIAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAuMax", model.CorpP_MarginPIAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAgVal", model.CorpP_MarginPIAgVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAgMin", model.CorpP_MarginPIAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAgMax", model.CorpP_MarginPIAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAu_Est", model.CorpP_MarginAu_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAu_EstMin", model.CorpP_MarginAu_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAu_EstMax", model.CorpP_MarginAu_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAg_Est", model.CorpP_MarginAg_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAg_EstMin", model.CorpP_MarginAg_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAg_EstMax", model.CorpP_MarginAg_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCNQty", model.CorpP_ConsuCNQty));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCNMin", model.CorpP_ConsuCNMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCNMax", model.CorpP_ConsuCNMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOHQty", model.CorpP_ConsuOHQty));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOHMin", model.CorpP_ConsuOHMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOHMax", model.CorpP_ConsuOHMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCN_Est", model.CorpP_ConsuCN_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCN_EstMin", model.CorpP_ConsuCN_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCN_EstMax", model.CorpP_ConsuCN_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOH_Est", model.CorpP_ConsuOH_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOH_EstMin", model.CorpP_ConsuOH_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOH_EstMax", model.CorpP_ConsuOH_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdmVal", model.CorpP_ExpAdmVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdmMin", model.CorpP_ExpAdmMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdmMax", model.CorpP_ExpAdmMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdm_Est", model.CorpP_ExpAdm_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdm_EstMin", model.CorpP_ExpAdm_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdm_EstMax", model.CorpP_ExpAdm_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLabVal", model.CorpP_ExpLabVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLabMin", model.CorpP_ExpLabMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLabMax", model.CorpP_ExpLabMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLab_Est", model.CorpP_ExpLab_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLab_EstMin", model.CorpP_ExpLab_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLab_EstMax", model.CorpP_ExpLab_EstMax));
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
        public int Update(CorporationParameters model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CorporationParameters_Update";
                cmd.Parameters.Add(new SqlParameter("@CorpP_ID", model.CorpP_ID));
                cmd.Parameters.Add(new SqlParameter("@CorpP_Desc", model.CorpP_Desc));
                cmd.Parameters.Add(new SqlParameter("@CorpP_WeigAuPor", model.CorpP_WeigAuPor));
                cmd.Parameters.Add(new SqlParameter("@CorpP_WeigAuMin", model.CorpP_WeigAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_WeigAuMax", model.CorpP_WeigAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAuPor", model.CorpP_LeyAuPor));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAuMin", model.CorpP_LeyAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAuMax", model.CorpP_LeyAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAgPor", model.CorpP_LeyAgPor));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAgMin", model.CorpP_LeyAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_LeyAgMax", model.CorpP_LeyAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAuVal", model.CorpP_HumiAuVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAuMin", model.CorpP_HumiAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAuMax", model.CorpP_HumiAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAgVal", model.CorpP_HumiAgVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAgMin", model.CorpP_HumiAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_HumiAgMax", model.CorpP_HumiAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAuVal", model.CorpP_RecovAuVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAuMin", model.CorpP_RecovAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAuMax", model.CorpP_RecovAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAgVal", model.CorpP_RecovAgVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAgMin", model.CorpP_RecovAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAgMax", model.CorpP_RecovAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAu_Est", model.CorpP_RecovAu_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAu_EstMin", model.CorpP_RecovAu_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAu_EstMax", model.CorpP_RecovAu_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAg_Est", model.CorpP_RecovAg_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAg_EstMin", model.CorpP_RecovAg_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_RecovAg_EstMax", model.CorpP_RecovAg_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAuVal", model.CorpP_MaquilaAuVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAuMin", model.CorpP_MaquilaAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAuMax", model.CorpP_MaquilaAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAgVal", model.CorpP_MaquilaAgVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAgMin", model.CorpP_MaquilaAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAgMax", model.CorpP_MaquilaAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAu_Est", model.CorpP_MaquilaAu_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAu_EstMin", model.CorpP_MaquilaAu_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAu_EstMax", model.CorpP_MaquilaAu_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAg_Est", model.CorpP_MaquilaAg_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAg_EstMin", model.CorpP_MaquilaAg_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MaquilaAg_EstMax", model.CorpP_MaquilaAg_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAuVal", model.CorpP_MarginPIAuVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAuMin", model.CorpP_MarginPIAuMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAuMax", model.CorpP_MarginPIAuMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAgVal", model.CorpP_MarginPIAgVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAgMin", model.CorpP_MarginPIAgMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginPIAgMax", model.CorpP_MarginPIAgMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAu_Est", model.CorpP_MarginAu_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAu_EstMin", model.CorpP_MarginAu_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAu_EstMax", model.CorpP_MarginAu_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAg_Est", model.CorpP_MarginAg_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAg_EstMin", model.CorpP_MarginAg_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_MarginAg_EstMax", model.CorpP_MarginAg_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCNQty", model.CorpP_ConsuCNQty));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCNMin", model.CorpP_ConsuCNMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCNMax", model.CorpP_ConsuCNMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOHQty", model.CorpP_ConsuOHQty));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOHMin", model.CorpP_ConsuOHMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOHMax", model.CorpP_ConsuOHMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCN_Est", model.CorpP_ConsuCN_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCN_EstMin", model.CorpP_ConsuCN_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuCN_EstMax", model.CorpP_ConsuCN_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOH_Est", model.CorpP_ConsuOH_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOH_EstMin", model.CorpP_ConsuOH_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ConsuOH_EstMax", model.CorpP_ConsuOH_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdmVal", model.CorpP_ExpAdmVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdmMin", model.CorpP_ExpAdmMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdmMax", model.CorpP_ExpAdmMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdm_Est", model.CorpP_ExpAdm_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdm_EstMin", model.CorpP_ExpAdm_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpAdm_EstMax", model.CorpP_ExpAdm_EstMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLabVal", model.CorpP_ExpLabVal));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLabMin", model.CorpP_ExpLabMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLabMax", model.CorpP_ExpLabMax));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLab_Est", model.CorpP_ExpLab_Est));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLab_EstMin", model.CorpP_ExpLab_EstMin));
                cmd.Parameters.Add(new SqlParameter("@CorpP_ExpLab_EstMax", model.CorpP_ExpLab_EstMax));
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
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CorporationParameters_Delete";
                cmd.Parameters.Add(new SqlParameter("@CorpP_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
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
        public async Task<List<CorporationParameters>> Search(JObject obj)
        {
            var response = new List<CorporationParameters>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CorporationParameters_Search";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@CorpP_Cod", obj["codCorpP"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCorporationParameters(reader));
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
    }
}
