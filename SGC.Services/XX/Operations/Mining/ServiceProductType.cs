using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.InterfaceServices.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Operations.Mining
{
    public class ServiceProductType: IServiceProductType
    {
        private readonly string _context;
        public ServiceProductType(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/ProductType/GetAll/1
        public async Task<List<ProductType>> GetAll(int idCompany)
        {
            var response = new List<ProductType>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].ProductType_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", idCompany));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToProductType(reader));
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
        private ProductType MapToProductType(SqlDataReader reader)
        {
            return new ProductType()
            {
                ProdType_ID = (int)reader["ProdType_ID"],
                Company_ID = (int)reader["Company_ID"],
                ProdType_Cod = reader["ProdType_Cod"].ToString(),
                ProdType_Name = reader["ProdType_Name"].ToString(),
                ProdType_Desc = reader["ProdType_Desc"].ToString(),
                ProdType_Area = reader["ProdType_Area"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                ProdType_Status = reader["ProdType_Status"].ToString()
            };
        }

        // POST: api/ProductType/Add
        public int Add(ProductType model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].ProductType_Add";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@ProdType_Cod", model.ProdType_Cod));
                cmd.Parameters.Add(new SqlParameter("@ProdType_Name", model.ProdType_Name));
                cmd.Parameters.Add(new SqlParameter("@ProdType_Desc", model.ProdType_Desc));
                cmd.Parameters.Add(new SqlParameter("@ProdType_Area", model.ProdType_Area));
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

        // PUT: api/ProductType/Update/1
        public int Update(ProductType model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].ProductType_Update";

                cmd.Parameters.Add(new SqlParameter("@ProdType_ID", model.ProdType_ID));
                cmd.Parameters.Add(new SqlParameter("@ProdType_Cod", model.ProdType_Cod));
                cmd.Parameters.Add(new SqlParameter("@ProdType_Name", model.ProdType_Name));
                cmd.Parameters.Add(new SqlParameter("@ProdType_Desc", model.ProdType_Desc));
                cmd.Parameters.Add(new SqlParameter("@ProdType_Area", model.ProdType_Area));
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
        // DELETE: api/ProductType/Delete/
        public int Delete(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].ProductType_Delete";
                cmd.Parameters.Add(new SqlParameter("@ProdType_ID", obj["id"].ToObject<int>()));
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
        // POST: api/ProductType/Search/{}
        public async Task<List<ProductType>> Search(JObject obj)
        {
            var response = new List<ProductType>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].ProductType_Search";

                cmd.Parameters.Add(new SqlParameter("@ProdType_Cod", obj["cod"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["companyID"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToProductType(reader));
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
