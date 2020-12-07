using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.CM.DataMaster.Commercial;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.MineralReception
{
    public class ServiceScales : IServiceScales
    {
        private readonly string _context;

        public ServiceScales(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        public Scales Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Scales>> Search(JObject obj)
        {
            var response = new List<Scales>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Scales_Search";

                bool rank = false;
                if (obj["date_To"].ToObject<DateTime>() == obj["date_From"].ToObject<DateTime>())
                    rank = false;
                else
                    rank = true;

                //cmd.Parameters.Add(new SqlParameter("@Ruma_NO", obj["cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Scales_Lote", obj["scales_Lote"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["date_To"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["date_From"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Zone", obj["zone"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Proveedor", obj["proveedor"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Period_NO", obj["periodNO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Rank", rank));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToScales(reader));
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
        public async Task<List<Scales>> Search2(JObject obj)
        {
            var response = new List<Scales>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Scales_Search2";

                bool rank = false;
                if (obj["date_To"].ToObject<DateTime>() == obj["date_From"].ToObject<DateTime>())
                    rank = false;
                else
                    rank = true;

                //cmd.Parameters.Add(new SqlParameter("@Ruma_NO", obj["cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Scales_Lote", obj["scales_Lote"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["date_To"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["date_From"].ToObject<DateTime>()));
                //cmd.Parameters.Add(new SqlParameter("@Zone", obj["zone"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Period_NO", obj["periodNO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Rank", rank));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToScales(reader));
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


        public async Task<List<Scales>> Search3(JObject obj)
        {
            var response = new List<Scales>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Scales_Search3";

                bool rank = false;
                if (obj["date_To"].ToObject<DateTime>() == obj["date_From"].ToObject<DateTime>())
                    rank = false;
                else
                    rank = true;

                //cmd.Parameters.Add(new SqlParameter("@Ruma_NO", obj["cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Scales_Lote", obj["scales_Lote"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["date_To"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["date_From"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Zone", obj["zone"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Proveedor", obj["proveedor"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Rank", rank));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToScales(reader));
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

        public async Task<List<Scales>> GetAll(int idCompany)
        {
            var response = new List<Scales>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Scales_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToScales(reader));
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

        private Scales MapToScales(SqlDataReader reader)
        {
            return new Scales()
            {
                Scales_ID = (int)reader["Scales_ID"],
                Vendor_ID = (int)reader["Vendor_ID"],
                Company_ID = (int)reader["Company_ID"],
                Period_ID = (int)reader["Period_ID"],
                Scales_Lote = reader["Scales_Lote"].ToString(),
                Scales_SubLote = reader["Scales_SubLote"].ToString(),
                MinType_ID = (int)reader["MinType_ID"],
                AnalReq_ID = (int)reader["AnalReq_ID"],
                MinFrom_ID = (int)reader["AnalReq_ID"],
                Scales_MinOwner = reader["Scales_MinOwner"].ToString(),
                Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                Scales_DateOut = (DateTime)reader["Scales_DateOut"],
                Orig_ID = (int)reader["Orig_ID"],
                Collec_ID = (int)reader["Collec_ID"],
                WrkShi_ID = (int)reader["WrkShi_ID"],
                Scales_Operator = reader["Scales_Operator"].ToString(),
                Scales_GuiRemRe_TaxID = reader["Scales_GuiRemRe_TaxID"].ToString(),
                Scales_GuiRemRe_Date = (DateTime)reader["Scales_GuiRemRe_Date"],
                Scales_GuiRemRe_Serie = reader["Scales_GuiRemRe_Serie"].ToString(),
                Scales_GuiRemRe_Num = reader["Scales_GuiRemRe_Num"].ToString(),
                Scales_NumSacos = (int)reader["Scales_NumSacos"],
                Scales_TMH = (decimal)reader["Scales_TMH"],
                Scales_TMH_Hist = (decimal)reader["Scales_TMH_Hist"],
                Scales_DriverRUC = reader["Scales_DriverRUC"].ToString(),
                Scales_DriverName = reader["Scales_DriverName"].ToString(),
                Scales_GRDriv_Serie = reader["Scales_GRDriv_Serie"].ToString(),
                Scales_GRDriv_Num = reader["Scales_GRDriv_Num"].ToString(),
                Scales_GRDriv_Date = (DateTime)reader["Scales_GRDriv_Date"],
                Scales_Patente = reader["Scales_Patente"].ToString(),
                Scales_Conces_NO = reader["Scales_Conces_NO"].ToString(),
                Scales_Conces_Name = reader["Scales_Conces_Name"].ToString(),
                Scales_Commit_NO = reader["Scales_Commit_NO"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Scales_Status = reader["Scales_Status"].ToString(),
                MineralTypes = new MineralsType
                {
                    MinType_ID = (int)reader["MinType_ID"],
                    MinType_Cod = reader["MinType_Cod"].ToString(),
                    MinType_Desc = reader["MinType_Desc"].ToString()
                },
                AnalysisRequests = new AnalysisRequest
                {
                    AnalReq_ID = (int)reader["AnalReq_ID"],
                    AnalReq_Cod = reader["AnalReq_Cod"].ToString(),
                    AnalReq_Desc = reader["AnalReq_Desc"].ToString()
                },
                MineralFroms = new MineralFrom
                {
                    MinFrom_ID = (int)reader["MinFrom_ID"],
                    MinFrom_Cod = reader["MinFrom_Cod"].ToString(),
                    MinFrom_Name = reader["MinFrom_Name"].ToString()
                },
                Origins = new Origin
                {
                    Orig_ID = (int)reader["Orig_ID"],
                    Orig_Cod = reader["Orig_Cod"].ToString(),
                    Orig_Name = reader["Orig_Name"].ToString()
                },
                Collectors = new Collector
                {
                    Collec_ID = (int)reader["Collec_ID"],
                    Collec_Name = reader["Collec_Name"].ToString(),
                    Collec_TaxID = reader["Collec_TaxID"].ToString()

                },
                WorkShifts = new WorkShifts
                {
                    WrkShi_ID = (int)reader["WrkShi_ID"],
                    WrkShi_Cod = reader["WrkShi_Cod"].ToString(),
                    WrkShi_Desc = reader["WrkShi_Desc"].ToString()
                },
                Vendors = new Vendor
                {
                    Vendor_ID = (int)reader["Vendor_ID"],
                    Vendor_TaxID = reader["Vendor_TaxID"].ToString(),
                    Vendor_Desc = reader["Vendor_Desc"].ToString(),
                    Vendor_LastName = reader["Vendor_LastName"].ToString(),
                    Vendor_SurName = reader["Vendor_SurName"].ToString(),
                },
                Periods =new Period
                {
                    Period_ID = (int)reader["Period_ID"],
                    Period_Cod = reader["Period_Cod"].ToString(),
                    Period_NO = reader["Period_NO"].ToString(),
                }
            };
        }
        public int Add(Scales model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Scales_Add";
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", model.Vendor_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", model.Period_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_Lote", model.Scales_Lote));
                cmd.Parameters.Add(new SqlParameter("@Scales_SubLote", model.Scales_SubLote));
                cmd.Parameters.Add(new SqlParameter("@MinType_ID", model.MinType_ID));
                cmd.Parameters.Add(new SqlParameter("@AnalReq_ID", model.AnalReq_ID));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_ID", model.MinFrom_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_MinOwner", model.Scales_MinOwner));
                cmd.Parameters.Add(new SqlParameter("@Scales_DateInp", model.Scales_DateInp));
                cmd.Parameters.Add(new SqlParameter("@Scales_DateOut", model.Scales_DateOut));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_ID", model.WrkShi_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_Operator", model.Scales_Operator));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_TaxID", model.Scales_GuiRemRe_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Date", model.Scales_GuiRemRe_Date));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Serie", model.Scales_GuiRemRe_Serie));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Num", model.Scales_GuiRemRe_Num));
                cmd.Parameters.Add(new SqlParameter("@Scales_NumSacos", model.Scales_NumSacos));
                cmd.Parameters.Add(new SqlParameter("@Scales_TMH", model.Scales_TMH));
                cmd.Parameters.Add(new SqlParameter("@Scales_TMH_Hist", model.Scales_TMH_Hist));
                cmd.Parameters.Add(new SqlParameter("@Scales_DriverRUC", model.Scales_DriverRUC));
                cmd.Parameters.Add(new SqlParameter("@Scales_DriverName", model.Scales_DriverName));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Serie", model.Scales_GRDriv_Serie));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Num", model.Scales_GRDriv_Num));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Date", model.Scales_GRDriv_Date));
                cmd.Parameters.Add(new SqlParameter("@Scales_Patente", model.Scales_Patente));
                cmd.Parameters.Add(new SqlParameter("@Scales_Conces_NO", model.Scales_Conces_NO));
                cmd.Parameters.Add(new SqlParameter("@Scales_Conces_Name", model.Scales_Conces_Name));
                cmd.Parameters.Add(new SqlParameter("@Scales_Commit_NO", model.Scales_Commit_NO));
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

        //public int Delete(JObject obj)
        //{
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(_context);
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.CommandText = "[CM].Scales_Delete";
        //        cmd.Parameters.Add(new SqlParameter("@Scales_ID", obj["id"].ToObject<int>()));
        //        cmd.Parameters.Add(new SqlParameter("@Modified_User", obj["user"].ToObject<string>()));

        //        cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

        //        conn.Open();
        //        var resul = cmd.ExecuteNonQuery();
        //        resul = (int)cmd.Parameters["@Result"].Value;
        //        conn.Close();

        //        return resul;
        //    }
        //    catch (Exception e)
        //    {
        //        return -1;
        //        throw e;
        //    }
        //}

        // DELETE: api/Scales/Delete/1
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Scales_Delete";
                cmd.Parameters.Add(new SqlParameter("@Scales_ID", obj["id"].ToObject<int>()));
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

        //public Scales Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public int Update(Scales model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Scales_Update";

                cmd.Parameters.Add(new SqlParameter("@Scales_ID", model.Scales_ID));
                cmd.Parameters.Add(new SqlParameter("@Vendor_ID", model.Vendor_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Period_ID", model.Period_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_Lote", model.Scales_Lote));
                cmd.Parameters.Add(new SqlParameter("@Scales_SubLote", model.Scales_SubLote));
                cmd.Parameters.Add(new SqlParameter("@MinType_ID", model.MinType_ID));
                cmd.Parameters.Add(new SqlParameter("@AnalReq_ID", model.AnalReq_ID));
                cmd.Parameters.Add(new SqlParameter("@MinFrom_ID", model.MinFrom_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_MinOwner", model.Scales_MinOwner));
                cmd.Parameters.Add(new SqlParameter("@Scales_DateInp", model.Scales_DateInp));
                cmd.Parameters.Add(new SqlParameter("@Scales_DateOut", model.Scales_DateOut));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_ID", model.WrkShi_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_Operator", model.Scales_Operator));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_TaxID", model.Scales_GuiRemRe_TaxID));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Date", model.Scales_GuiRemRe_Date));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Serie", model.Scales_GuiRemRe_Serie));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Num", model.Scales_GuiRemRe_Num));
                cmd.Parameters.Add(new SqlParameter("@Scales_NumSacos", model.Scales_NumSacos));
                cmd.Parameters.Add(new SqlParameter("@Scales_TMH", model.Scales_TMH));
                cmd.Parameters.Add(new SqlParameter("@Scales_TMH_Hist", model.Scales_TMH_Hist));
                cmd.Parameters.Add(new SqlParameter("@Scales_DriverRUC", model.Scales_DriverRUC));
                cmd.Parameters.Add(new SqlParameter("@Scales_DriverName", model.Scales_DriverName));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Serie", model.Scales_GRDriv_Serie));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Num", model.Scales_GRDriv_Num));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Date", model.Scales_GRDriv_Date));
                cmd.Parameters.Add(new SqlParameter("@Scales_Patente", model.Scales_Patente));
                cmd.Parameters.Add(new SqlParameter("@Scales_Conces_NO", model.Scales_Conces_NO));
                cmd.Parameters.Add(new SqlParameter("@Scales_Conces_Name", model.Scales_Conces_Name));
                cmd.Parameters.Add(new SqlParameter("@Scales_Commit_NO", model.Scales_Commit_NO));
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