using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.OP.PlantCIP;
using SGC.InterfaceServices.OP.PlantCIP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.OP.PlantCIP
{
    public class ServiceCampaign : IServiceCampaign
    {
        private readonly string _context;

        public ServiceCampaign(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
    
        private Campaign MapToCampaign(SqlDataReader reader)
        {
            return new Campaign()
            {
                CampH_ID = (int)reader["CampH_ID"],
                Company_ID = (int)reader["Company_ID"],
                Plant_ID = (int)reader["Plant_ID"],
                CampH_Process_Date = reader["CampH_Process_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["CampH_Process_Date"],
                CampH_NO = reader["CampH_NO"].ToString(),
                CampH_Desc = reader["CampH_Desc"].ToString(),
                CampH_First_Date = reader["CampH_First_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["CampH_First_Date"],
                CampH_End_Date = reader["CampH_End_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["CampH_End_Date"],
                CampH_Ruma_TotWeight = (decimal)reader["CampH_Ruma_TotWeight"],
                CampH_Ruma_LeyAuOzTc_Aver = (decimal)reader["CampH_Ruma_LeyAuOzTc_Aver"],
                CampH_Ruma_LeyAgOzTc_Aver = (decimal)reader["CampH_Ruma_LeyAgOzTc_Aver"],
                CampH_Ruma_FinosAuGr_Aver = (decimal)reader["CampH_Ruma_FinosAuGr_Aver"],
                CampH_Ruma_FinosAgGr_Aver = (decimal)reader["CampH_Ruma_FinosAgGr_Aver"],
                CampH_Ruma_ConsuCN_Aver = (decimal)reader["CampH_Ruma_ConsuCN_Aver"],
                CampH_Ruma_ConsuOH_Aver = (decimal)reader["CampH_Ruma_ConsuOH_Aver"],
                CampH_Ruma_RecovAu_Aver = (decimal)reader["CampH_Ruma_RecovAu_Aver"],
                CampH_Ruma_RecovAg_Aver = (decimal)reader["CampH_Ruma_RecovAg_Aver"],
                CampH_Authsd_By = reader["CampH_Authsd_By"].ToString(),
                CampH_Authsd_Date = reader["CampH_Authsd_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["CampH_Authsd_Date"],
                CampH_Status_Cod = reader["CampH_Status_Cod"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                CampH_Status = reader["CampH_Status"].ToString(),
                Plants = new Plants
                {
                    Plant_ID = (int)reader["Plant_ID"],
                    Plant_Cod = (int)reader["Plant_Cod"],
                    Plant_Desc = reader["Plant_Desc"].ToString()
                }
            };
        }
        public async Task<List<Campaign>> Search(JObject obj)
        {
            var response = new List<Campaign>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Campaign_Search";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@CampH_NO", obj["campH_NO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Plant_ID", obj["plant_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@CampH_Status_Cod", obj["campH_Status_Cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCampaign(reader));
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
        
        public async Task<int> Add(Campaign model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Campaign_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Plant_ID", model.Plant_ID));
                cmd.Parameters.Add(new SqlParameter("@CampH_Desc", model.CampH_Desc));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_TotWeight", model.CampH_Ruma_TotWeight));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_LeyAuOzTc_Aver", model.CampH_Ruma_LeyAuOzTc_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_LeyAgOzTc_Aver", model.CampH_Ruma_LeyAgOzTc_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_FinosAuGr_Aver", model.CampH_Ruma_FinosAuGr_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_FinosAgGr_Aver", model.CampH_Ruma_FinosAgGr_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_ConsuCN_Aver", model.CampH_Ruma_ConsuCN_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_ConsuOH_Aver", model.CampH_Ruma_ConsuOH_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_RecovAu_Aver", model.CampH_Ruma_RecovAu_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_RecovAg_Aver", model.CampH_Ruma_RecovAg_Aver));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                SqlParameter parGetLiquidationDetail = GetRumas("lstRumas", model.LstRumas);
                cmd.Parameters.Add(parGetLiquidationDetail);

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

        public SqlParameter GetRumas(string name, List<Ruma> lstRumas)
        {
            try
            {
                DataTable table = new DataTable("dbo.IDRumas");
                table.Columns.Add("Ruma_ID", typeof(int));
                table.Columns.Add("Ruma_Status", typeof(string));

                foreach (Ruma Ruma in lstRumas)
                    table.Rows.Add(new object[] {   Ruma.Ruma_ID,
                                                    Ruma.Ruma_Status
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.IDRumas";

                return parameter;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        public async Task<List<Ruma>> SearchRuma(JObject obj)
        {
            var response = new List<Ruma>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Campaign_Search_Ruma";

                bool rank = false;
                DateTime dateTime;

                if (!DateTime.TryParse(obj["date_From"].ToObject<string>(), out dateTime) && !DateTime.TryParse(obj["date_To"].ToObject<string>(), out dateTime))
                {
                    obj["date_To"] = DateTime.Now;
                    obj["date_From"] = obj["date_To"];
                    rank = false;
                }
                else
                {
                    if (!DateTime.TryParse(obj["date_From"].ToObject<string>(), out dateTime))
                    {
                        obj["date_From"] = obj["date_To"];
                    }
                    rank = true;
                }

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Ruma_NO", obj["ruma_NO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["date_To"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["date_From"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@MatType_ID", obj["matType_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Rank", rank));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToRuma(reader));
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

        private Ruma MapToRuma(SqlDataReader reader)
        {
            return new Ruma()
            {
                Ruma_ID = (int)reader["Ruma_ID"],
                Company_ID = (int)reader["Company_ID"],
                CampH_ID = reader["CampH_ID"] == DBNull.Value ? (int?)null : (int)reader["CampH_ID"],
                Ruma_NO = reader["Ruma_NO"].ToString(),
                Ruma_Desc = reader["Ruma_Desc"].ToString(),
                MatType_ID = (int)reader["MatType_ID"],
                Ruma_Process_Date = (DateTime)reader["Ruma_Process_Date"],
                Period_ID = (int)reader["Period_ID"],
                Ruma_Weigth = (decimal)reader["Ruma_Weigth"],
                Ruma_NumLotes = (int)reader["Ruma_NumLotes"],
                Ruma_LeyAuAver = (decimal)reader["Ruma_LeyAuAver"],
                Ruma_LeyAgAver = (decimal)reader["Ruma_LeyAgAver"],
                Ruma_ConsuCNAver = (decimal)reader["Ruma_ConsuCNAver"],
                Ruma_ConsuOHAver = (decimal)reader["Ruma_ConsuOHAver"],
                Ruma_RecovAuAver = (decimal)reader["Ruma_RecovAuAver"],
                Ruma_RecovAgAver = (decimal)reader["Ruma_RecovAgAver"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Ruma_Status = reader["Ruma_Status"].ToString(),
                MaterialTypes = new MaterialType
                {
                    MatType_ID = (int)reader["MatType_ID"],
                    MatType_Cod = reader["MatType_Cod"].ToString(),
                    MatType_Desc = reader["MatType_Desc"].ToString()
                },
                Period = new Period
                {
                    Period_ID = (int)reader["Period_ID"],
                    Period_NO = reader["Period_NO"].ToString(),
                },
            };
        }
        public async Task<int> Update(Campaign model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Campaign_Update";
                cmd.Parameters.Add(new SqlParameter("@CampH_ID", model.CampH_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Plant_ID", model.Plant_ID));
                cmd.Parameters.Add(new SqlParameter("@CampH_Desc", model.CampH_Desc));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_TotWeight", model.CampH_Ruma_TotWeight));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_LeyAuOzTc_Aver", model.CampH_Ruma_LeyAuOzTc_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_LeyAgOzTc_Aver", model.CampH_Ruma_LeyAgOzTc_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_FinosAuGr_Aver", model.CampH_Ruma_FinosAuGr_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_FinosAgGr_Aver", model.CampH_Ruma_FinosAgGr_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_ConsuCN_Aver", model.CampH_Ruma_ConsuCN_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_ConsuOH_Aver", model.CampH_Ruma_ConsuOH_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_RecovAu_Aver", model.CampH_Ruma_RecovAu_Aver));
                cmd.Parameters.Add(new SqlParameter("@CampH_Ruma_RecovAg_Aver", model.CampH_Ruma_RecovAg_Aver));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));
                //Details
                SqlParameter parGetLiquidationDetail = GetRumas("lstRumas", model.LstRumas);
                cmd.Parameters.Add(parGetLiquidationDetail);

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



        public async Task<List<Ruma>> GetRumas(int id)
        {
            var response = new List<Ruma>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Campaign_Get_Rumas";

                cmd.Parameters.Add(new SqlParameter("@CampH_ID", id));


                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToRuma(reader));
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


        public async Task<int> ChangeStatus(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Campaign_ChangeStatus";
                cmd.Parameters.Add(new SqlParameter("@CampH_ID", obj["id"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Action", obj["action"].ToObject<string>()));

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


    }
}
