using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.InterfaceServices.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.CM.MineralReception
{
    public class ServiceCrushed : IServiceCrushed
    {
        private readonly string _context;
        public ServiceCrushed(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public async Task<List<ModelCrushed>> Search(JObject obj)
        {
            var response = new List<ModelCrushed>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[Crushed_Search_Batches]";

                //bool rank = false;
                //DateTime dateTime;

                //if (!DateTime.TryParse(obj["date_From"].ToObject<string>(), out dateTime) && !DateTime.TryParse(obj["date_To"].ToObject<string>(), out dateTime))
                //{
                //    obj["date_To"] = DateTime.Now;
                //    obj["date_From"] = obj["date_To"];
                //    rank = false;
                //}
                //else
                //{
                //    if (!DateTime.TryParse(obj["date_From"].ToObject<string>(), out dateTime))
                //    {
                //        obj["date_From"] = obj["date_To"];
                //    }
                //    rank = true;
                //}

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                //cmd.Parameters.Add(new SqlParameter("@BatchM_Lote_New", obj["batchM_Lote_New"].ToObject<string>()));
                //cmd.Parameters.Add(new SqlParameter("@Date_To", obj["date_To"].ToObject<DateTime>()));
                //cmd.Parameters.Add(new SqlParameter("@Date_From", obj["date_From"].ToObject<DateTime>()));
                //cmd.Parameters.Add(new SqlParameter("@LiquiH_Status", obj["liquiH_Status"].ToObject<string>()));
                //cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["vendor_ID"].ToObject<int>()));
                //cmd.Parameters.Add(new SqlParameter("@Rank", rank));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToModelCrushed(reader));
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

        private ModelCrushed MapToModelCrushed(SqlDataReader reader)
        {
            return new ModelCrushed()
            {

                BatchM_ID = (int)reader["BatchM_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),
                Scales_ID = (int)reader["Scales_ID"],
                Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                Scales_NumSacos = (int)reader["Scales_NumSacos"],
                Scales_TMH = (decimal)reader["Scales_TMH"],
                Vendor_ID = (int)reader["Vendor_ID"],
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Vendor_Desc = reader["Vendor_Desc"].ToString(),
                Vendor_LastName = reader["Vendor_LastName"].ToString(),
                Vendor_SurName = reader["Vendor_SurName"].ToString(),
                MinType_ID = (int)reader["MinType_ID"],
                MinType_Desc = reader["MinType_Desc"].ToString(),
                Orig_ID = (int)reader["Orig_ID"],
                Orig_Name = reader["Orig_Name"].ToString(),
                Orig_Desc = reader["Orig_Desc"].ToString(),
                Zone_ID = (int)reader["Zone_ID"],
                Zone_Name = reader["Zone_Name"].ToString(),

                Crush_ID = reader["Crush_ID"] == DBNull.Value ? 0 : (int)reader["Crush_ID"],
                Company_ID = reader["Company_ID"] == DBNull.Value ? 0 : (int)reader["Company_ID"],
                Circuit_ID = reader["Circuit_ID"] == DBNull.Value ? 0 : (int)reader["Circuit_ID"],
                Crush_Process_Date = reader["Crush_Process_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["Crush_Process_Date"],
                Crush_Operator = reader["Crush_Operator"].ToString(),
                WrkShi_ID = reader["WrkShi_ID"] == DBNull.Value ? 0 : (int)reader["WrkShi_ID"],
                Crush_Horom_DateTimeStar = reader["Crush_Horom_DateTimeStar"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["Crush_Horom_DateTimeStar"],
                Crush_Horom_DateTimeEnd = reader["Crush_Horom_DateTimeEnd"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["Crush_Horom_DateTimeEnd"],
                Crush_Horom_TotalTime = reader["Crush_Horom_TotalTime"].ToString(),
                Crush_Status_Cod = reader["Crush_Status_Cod"].ToString(),

                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = reader["Creation_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = reader["Modified_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["Modified_Date"],
                Crush_Status = reader["Crush_Status"].ToString()

            };
        }

        //POST: api/Crushed/Add
        public async Task<int> Add(ModelCrushed model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Crushed_Add";
                //
                cmd.Parameters.Add(new SqlParameter("@Crush_ID", model.Crush_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Circuit_ID", model.Circuit_ID));
                cmd.Parameters.Add(new SqlParameter("@BatchM_ID", model.BatchM_ID));
                cmd.Parameters.Add(new SqlParameter("@Crush_Operator", model.Crush_Operator));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_ID", model.WrkShi_ID));
                cmd.Parameters.Add(new SqlParameter("@Crush_Horom_DateTimeStar", model.Crush_Horom_DateTimeStar));
                cmd.Parameters.Add(new SqlParameter("@Crush_Horom_DateTimeEnd", model.Crush_Horom_DateTimeEnd));
                cmd.Parameters.Add(new SqlParameter("@Crush_Horom_TotalTime", model.Crush_Horom_TotalTime));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                    
                //Output
                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                await conn.OpenAsync();
                var resul = await cmd.ExecuteNonQueryAsync();
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
