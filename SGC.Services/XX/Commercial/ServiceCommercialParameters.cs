using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using SGC.InterfaceServices.XX.Commercial;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Commercial
{
    public class ServiceCommercialParameters : IServiceCommercialParameters
    {
        private readonly string _context;

        public ServiceCommercialParameters(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }
        // GET: api/CommercialParameters/GetAll/1
        public async Task<List<CommercialParameters>> GetAll(int idCompany)
        {
            var response = new List<CommercialParameters>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialParameters_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCommercialParameters(reader));
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
        private CommercialParameters MapToCommercialParameters(SqlDataReader reader)
        {
            return new CommercialParameters()
            {
                CommP_ID = (int)reader["CommP_ID"],
                Company_ID = (int)reader["Company_ID"],
                CommP_Cod = reader["CommP_Cod"].ToString(),
                CommP_Name = reader["CommP_Name"].ToString(),
                CommP_WeigAuPor = (decimal)reader["CommP_WeigAuPor"],
                CommP_LeyAuQuan = (decimal)reader["CommP_LeyAuQuan"],
                CommP_LeyAgQuan = (decimal)reader["CommP_LeyAgQuan"],
                CommP_HumiAuPor = (decimal)reader["CommP_HumiAuPor"],
                CommP_HumiAgPor = (decimal)reader["CommP_HumiAgPor"],
                CommP_RecovAuMin = (decimal)reader["CommP_RecovAuMin"],
                CommP_RecovAuMax = (decimal)reader["CommP_RecovAuMax"],
                CommP_MaquilaMin = (decimal)reader["CommP_MaquilaMin"],
                CommP_MaquilaMax = (decimal)reader["CommP_MaquilaMax"],
                CommP_ConsuMin = (decimal)reader["CommP_ConsuMin"],
                CommP_ConsuMax = (decimal)reader["CommP_ConsuMax"],
                CommP_ExpAdm = (decimal)reader["CommP_ExpAdm"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                CommP_Status = reader["CommP_Status"].ToString(),
            };
        }
        public int Add(CommercialParameters model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialParameters_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@CommP_Cod", model.CommP_Cod));
                cmd.Parameters.Add(new SqlParameter("@CommP_Name", model.CommP_Name));
                cmd.Parameters.Add(new SqlParameter("@CommP_WeigAuPor", model.CommP_WeigAuPor));
                cmd.Parameters.Add(new SqlParameter("@CommP_LeyAuQuan", model.CommP_LeyAuQuan));
                cmd.Parameters.Add(new SqlParameter("@CommP_LeyAgQuan", model.CommP_LeyAgQuan));
                cmd.Parameters.Add(new SqlParameter("@CommP_HumiAuPor", model.CommP_HumiAuPor));
                cmd.Parameters.Add(new SqlParameter("@CommP_HumiAgPor", model.CommP_HumiAgPor));
                cmd.Parameters.Add(new SqlParameter("@CommP_RecovAuMin", model.CommP_RecovAuMin));
                cmd.Parameters.Add(new SqlParameter("@CommP_RecovAuMax", model.CommP_RecovAuMax));
                cmd.Parameters.Add(new SqlParameter("@CommP_MaquilaMin", model.CommP_MaquilaMin));
                cmd.Parameters.Add(new SqlParameter("@CommP_MaquilaMax", model.CommP_MaquilaMax));
                cmd.Parameters.Add(new SqlParameter("@CommP_ConsuMin", model.CommP_ConsuMin));
                cmd.Parameters.Add(new SqlParameter("@CommP_MaquilaMax", model.CommP_MaquilaMax));
                cmd.Parameters.Add(new SqlParameter("@CommP_ExpAdm", model.CommP_ExpAdm));
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
        public int Update(CommercialParameters model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialParameters_Update";
                cmd.Parameters.Add(new SqlParameter("@CommP_ID", model.CommP_ID));
                //cmd.Parameters.Add(new SqlParameter("@MinType_Cod", model.MinType_Cod));
                cmd.Parameters.Add(new SqlParameter("@CommP_Name", model.CommP_Name));
                cmd.Parameters.Add(new SqlParameter("@CommP_WeigAuPor", model.CommP_WeigAuPor));
                cmd.Parameters.Add(new SqlParameter("@CommP_LeyAuQuan", model.CommP_LeyAuQuan));
                cmd.Parameters.Add(new SqlParameter("@CommP_LeyAgQuan", model.CommP_LeyAgQuan));
                cmd.Parameters.Add(new SqlParameter("@CommP_HumiAuPor", model.CommP_HumiAuPor));
                cmd.Parameters.Add(new SqlParameter("@CommP_HumiAgPor", model.CommP_HumiAgPor));
                cmd.Parameters.Add(new SqlParameter("@CommP_RecovAuMin", model.CommP_RecovAuMin));
                cmd.Parameters.Add(new SqlParameter("@CommP_RecovAuMax", model.CommP_RecovAuMax));
                cmd.Parameters.Add(new SqlParameter("@CommP_MaquilaMin", model.CommP_MaquilaMin));
                cmd.Parameters.Add(new SqlParameter("@CommP_MaquilaMax", model.CommP_MaquilaMax));
                cmd.Parameters.Add(new SqlParameter("@CommP_ConsuMin", model.CommP_ConsuMin));
                cmd.Parameters.Add(new SqlParameter("@CommP_MaquilaMax", model.CommP_MaquilaMax));
                cmd.Parameters.Add(new SqlParameter("@CommP_ExpAdm", model.CommP_ExpAdm));
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
                cmd.CommandText = "[XX].CommercialParameters_Delete";
                cmd.Parameters.Add(new SqlParameter("@CommP_ID", obj["id"].ToObject<int>()));
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
        public async Task<List<CommercialParameters>> Search(JObject obj)
        {
            var response = new List<CommercialParameters>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].CommercialParameters_Search";

                cmd.Parameters.Add(new SqlParameter("@CommP_Cod", obj["cod"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCommercialParameters(reader));
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
