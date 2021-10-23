using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.Commercial.Reports;
using SGC.InterfaceServices.CM.Commercial.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace SGC.Services.CM.Commercial.Reports
{
    public class ServiceReports : IServiceReports
    {
        private readonly string _context;

        public ServiceReports(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public async Task<List<BatchComProcTime>> SearchTimeProc(JObject obj)
        {
            var response = new List<BatchComProcTime>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].[BatchMineral_Search_TimeProc]";

                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["company_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@BatchM_Lote_New", obj["batchM_Lote_New"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", obj["vendor_ID"].ToObject<int>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToManagementBatchComProcTime(reader));
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

        private BatchComProcTime MapToManagementBatchComProcTime(SqlDataReader reader)
        {
            return new BatchComProcTime()
            {
                BatchM_ID = (int)reader["BatchM_ID"],
                BatchM_Lote_New = reader["BatchM_Lote_New"].ToString(),

                Scales_DateInp = (DateTime)reader["Scales_DateInp"],

                Vendor_ID = (int)reader["Vendor_ID"],
                Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                Vendor_Desc = reader["Vendor_Desc"].ToString(),
                Vendor_LastName = reader["Vendor_LastName"].ToString(),
                Vendor_SurName = reader["Vendor_SurName"].ToString(),

                SampH_Proces_Date = reader["SampH_Proces_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["SampH_Proces_Date"],
                SampD_RecLab_Date = reader["SampD_RecLab_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["SampD_RecLab_Date"],
                SampH_LabFinish_Date = reader["SampH_LabFinish_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["SampH_LabFinish_Date"],
                IntCtrlH_Approved_Date = reader["IntCtrlH_Approved_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["IntCtrlH_Approved_Date"],
                Creation_DateLiq = reader["Creation_DateLiq"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["Creation_DateLiq"],
                LiquiH_AcceptDate = reader["LiquiH_AcceptDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["LiquiH_AcceptDate"],
               
            };
        }

    }
}
