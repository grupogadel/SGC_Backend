using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.CM.MineralReception
{
    public class ServiceRuma : IServiceRuma
    {
        private readonly string _context;

        public ServiceRuma(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        public async Task<List<Ruma>> GetAll(int idCompany)
        {
            var response = new List<Ruma>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Ruma_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

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
                Ruma_NO = reader["Ruma_NO"].ToString(),
                Ruma_Desc = reader["Ruma_Desc"].ToString(),
                MatType_ID = (int)reader["MatType_ID"],
                Ruma_Date = (DateTime)reader["Ruma_Date"],
                Ruma_Period = reader["Ruma_Period"].ToString(),
                Ruma_Weigth = (decimal)reader["Ruma_Weigth"],
                Ruma_NumLotes = (int)reader["Ruma_NumLotes"],
                Ruma_LeyAu = (decimal)reader["Ruma_LeyAu"],
                Ruma_LeyAg = (decimal)reader["Ruma_LeyAg"],
                //Ruma_RecovAu = (decimal)reader["Ruma_RecovAuRuma_RecovAu"],
                //Ruma_RecovAg = (decimal)reader["Ruma_RecovAg"],
                //Ruma_ConsNaCN = (decimal)reader["Ruma_ConsNaCN"],
                //Ruma_ConsNaOH = (decimal)reader["Ruma_ConsNaOH"],
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
            };
        }
        public async Task<List<Ruma>> Search(JObject obj)
        {
            var response = new List<Ruma>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Ruma_Search";

                bool rank = false;
                if (obj["date_To"].ToObject<DateTime>() == obj["date_From"].ToObject<DateTime>()) 
                    rank = false;
                else 
                    rank = true;

                //cmd.Parameters.Add(new SqlParameter("@Ruma_NO", obj["cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Ruma_NO", obj["ruma_NO"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Date_To", obj["date_To"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@Date_From", obj["date_From"].ToObject<DateTime>()));
                cmd.Parameters.Add(new SqlParameter("@TipoRuma", obj["tipoRuma"].ToObject<string>()));
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

        public int Add(Ruma model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Ruma_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Ruma_NO", model.Ruma_NO));
                cmd.Parameters.Add(new SqlParameter("@Ruma_Desc", model.Ruma_Desc));
                cmd.Parameters.Add(new SqlParameter("@MatType_ID", model.MatType_ID));
                cmd.Parameters.Add(new SqlParameter("@Ruma_Date", model.Ruma_Date));
                cmd.Parameters.Add(new SqlParameter("@Ruma_Period", model.Ruma_Period));
                cmd.Parameters.Add(new SqlParameter("@Ruma_Weigth", model.Ruma_Weigth));
                cmd.Parameters.Add(new SqlParameter("@Ruma_NumLotes", model.Ruma_NumLotes));
                cmd.Parameters.Add(new SqlParameter("@Ruma_LeyAu", model.Ruma_LeyAu));
                cmd.Parameters.Add(new SqlParameter("@Ruma_LeyAg", model.Ruma_LeyAg));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));
                //Details
                var param= new SqlParameter("@lstLotes",SqlDbType.Structured);
                param.TypeName = "dbo.IDLotes";
                param.Value = GetLotes(model.LstLotes);
                cmd.Parameters.Add(param);
                //SqlParameter param = new SqlParameter();
                //param.ParameterName = "@IDLotes";
                //param.Value = GetLotes();
                //cmd.Parameters.Add(param);

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

        private DataTable GetLotes(List<int> lstLotes)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Lote", typeof(int));
            //for(int i = 1; i < 3; i++)
            //{
            //    dt.Rows.Add(i);
            //}
            foreach (int idLote in lstLotes)
                dt.Rows.Add(idLote);
            return dt;
        }

        public int Update(Ruma model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Ruma_Update";
                cmd.Parameters.Add(new SqlParameter("@Ruma_ID", model.Ruma_ID));
                //cmd.Parameters.Add(new SqlParameter("@Ruma_NO", model.Ruma_NO));
                cmd.Parameters.Add(new SqlParameter("@Ruma_Desc", model.Ruma_Desc));
                cmd.Parameters.Add(new SqlParameter("@MatType_ID", model.MatType_ID));
                cmd.Parameters.Add(new SqlParameter("@Ruma_Date", model.Ruma_Date));
                cmd.Parameters.Add(new SqlParameter("@Ruma_Period", model.Ruma_Period));
                cmd.Parameters.Add(new SqlParameter("@Ruma_Weigth", model.Ruma_Weigth));
                cmd.Parameters.Add(new SqlParameter("@Ruma_NumLotes", model.Ruma_NumLotes));
                cmd.Parameters.Add(new SqlParameter("@Ruma_LeyAu", model.Ruma_LeyAu));
                cmd.Parameters.Add(new SqlParameter("@Ruma_LeyAg", model.Ruma_LeyAg));
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
                cmd.CommandText = "[OP].Ruma_Delete";
                cmd.Parameters.Add(new SqlParameter("@Ruma_ID", obj["id"].ToObject<int>()));
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
        // GET api/Ruma/Get/1
        public Ruma Get(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].Ruma_Get";
                cmd.Parameters.Add(new SqlParameter("@Ruma_ID", id));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                Ruma response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToRuma(reader);
                    }
                }
                conn.Close();
                return response;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }
    }
}
