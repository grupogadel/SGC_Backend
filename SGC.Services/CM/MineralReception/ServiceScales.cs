using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
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
                Scales_ID= (int)reader["Scales_ID"],
                VendorOrig_ID= (int)reader["VendorOrig_ID"],
                Company_ID= (int)reader["Company_ID"],
                Scales_Lote = reader["Scales_Lote"].ToString(),
                Scales_SubLote = reader["Scales_SubLote"].ToString(),
                MinType_ID = (int)reader["MinType_ID"],
                Scales_MinOwner = reader["Scales_MinOwner"].ToString(),
                Scales_DateInp = (DateTime)reader["Scales_DateInp"],
                Scales_DateOut = (DateTime)reader["Scales_DateOut"],
                Orig_ID = (int)reader["Orig_ID"],
                Collec_ID = (int)reader["Collec_ID"],
                WrkShi_ID = (int)reader["WrkShi_ID"],
                Scales_Operator = reader["Scales_Operator"].ToString(),
                Scales_GuiRemRe_Serie = reader["Scales_GuiRemRe_Serie"].ToString(),
                Scales_GuiRemRe_Num = reader["Scales_GuiRemRe_Num"].ToString(),
                Scales_GuiRemDate = (DateTime)reader["Scales_GuiRemDate"],
                Scales_NumSacos = (int)reader["Scales_NumSacos"],
                Scales_TMH = (int)reader["Scales_TMH"],
                Scale_TMH_Hist = (decimal)reader["Scale_TMH_Hist"],
                Scales_DriverName = reader["Scales_DriverName"].ToString(),
                Scales_GRDriv_Serie = reader["Scales_GRDriv_Serie"].ToString(),
                Scales_GRDriv_Num = reader["Scales_GRDriv_Num"].ToString(),
                Scales_GRDate = (DateTime)reader["Scales_GRDate"],
                Scales_Patente = reader["Scales_Patente"].ToString(),
                Scale_Conces_NO = reader["Scale_Conces_NO"].ToString(),
                Scale_Conces_Name = reader["Scale_Conces_Name"].ToString(),
                Scale_Commit_NO = reader["Scale_Commit_NO"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Scales_Status = reader["Scales_Status"].ToString(),
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
                cmd.Parameters.Add(new SqlParameter("@Scales_ID", model.Scales_ID));
                cmd.Parameters.Add(new SqlParameter("@VendorOrig_ID", model.VendorOrig_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_Lote", model.Scales_Lote));
                cmd.Parameters.Add(new SqlParameter("@Scales_SubLote", model.Scales_SubLote));
                cmd.Parameters.Add(new SqlParameter("@MinType_ID", model.MinType_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_MinOwner", model.Scales_MinOwner));
                cmd.Parameters.Add(new SqlParameter("@Scales_DateInp", model.Scales_DateInp));
                cmd.Parameters.Add(new SqlParameter("@Scales_DateOut", model.Scales_DateOut));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_ID", model.WrkShi_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_Operator", model.Scales_Operator));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Serie", model.Scales_GuiRemRe_Serie));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Num", model.Scales_GuiRemRe_Num));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemDate", model.Scales_GuiRemDate));
                cmd.Parameters.Add(new SqlParameter("@Scales_NumSacos", model.Scales_NumSacos));
                cmd.Parameters.Add(new SqlParameter("@Scales_TMH", model.Scales_TMH));
                cmd.Parameters.Add(new SqlParameter("@Scale_TMH_Hist", model.Scale_TMH_Hist));
                cmd.Parameters.Add(new SqlParameter("@Scales_DriverName", model.Scales_DriverName));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Serie", model.Scales_GRDriv_Serie));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Num", model.Scales_GRDriv_Num));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDate", model.Scales_GRDate));
                cmd.Parameters.Add(new SqlParameter("@Scales_Patente", model.Scales_Patente));
                cmd.Parameters.Add(new SqlParameter("@Scale_Conces_NO", model.Scale_Conces_NO));
                cmd.Parameters.Add(new SqlParameter("@Scale_Conces_Name", model.Scale_Conces_Name));
                cmd.Parameters.Add(new SqlParameter("@Scale_Commit_NO", model.Scale_Commit_NO));
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
                cmd.CommandText = "[CM].Scales_Delete";
                cmd.Parameters.Add(new SqlParameter("@Scales_ID", obj["id"].ToObject<int>()));
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

        public Scales Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Scales model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[CM].Scales_Update";

                cmd.Parameters.Add(new SqlParameter("@Scales_ID", model.Scales_ID));
                //cmd.Parameters.Add(new SqlParameter("@Orig_Cod", model.Orig_Cod));
                cmd.Parameters.Add(new SqlParameter("@VendorOrig_ID", model.VendorOrig_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_Lote", model.Scales_Lote));
                cmd.Parameters.Add(new SqlParameter("@Scales_SubLote", model.Scales_SubLote));
                cmd.Parameters.Add(new SqlParameter("@MinType_ID", model.MinType_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_MinOwner", model.Scales_MinOwner));
                cmd.Parameters.Add(new SqlParameter("@Scales_DateInp", model.Scales_DateInp));
                cmd.Parameters.Add(new SqlParameter("@Scales_DateOut", model.Scales_DateOut));
                cmd.Parameters.Add(new SqlParameter("@Orig_ID", model.Orig_ID));
                cmd.Parameters.Add(new SqlParameter("@Collec_ID", model.Collec_ID));
                cmd.Parameters.Add(new SqlParameter("@WrkShi_ID", model.WrkShi_ID));
                cmd.Parameters.Add(new SqlParameter("@Scales_Operator", model.Scales_Operator));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Serie", model.Scales_GuiRemRe_Serie));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemRe_Num", model.Scales_GuiRemRe_Num));
                cmd.Parameters.Add(new SqlParameter("@Scales_GuiRemDate", model.Scales_GuiRemDate));
                cmd.Parameters.Add(new SqlParameter("@Scales_NumSacos", model.Scales_NumSacos));
                cmd.Parameters.Add(new SqlParameter("@Scales_TMH", model.Scales_TMH));
                cmd.Parameters.Add(new SqlParameter("@Scale_TMH_Hist", model.Scale_TMH_Hist));
                cmd.Parameters.Add(new SqlParameter("@Scales_DriverName", model.Scales_DriverName));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Serie", model.Scales_GRDriv_Serie));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDriv_Num", model.Scales_GRDriv_Num));
                cmd.Parameters.Add(new SqlParameter("@Scales_GRDate", model.Scales_GRDate));
                cmd.Parameters.Add(new SqlParameter("@Scales_Patente", model.Scales_Patente));
                cmd.Parameters.Add(new SqlParameter("@Scale_Conces_NO", model.Scale_Conces_NO));
                cmd.Parameters.Add(new SqlParameter("@Scale_Conces_Name", model.Scale_Conces_Name));
                cmd.Parameters.Add(new SqlParameter("@Scale_Commit_NO", model.Scale_Commit_NO));
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
