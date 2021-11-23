using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Operations.Mining.Plant;
using SGC.InterfaceServices.XX.Operations.Mining.Plant;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Services.XX.Operations.Mining.Plant
{
    public class ServiceCircuitPlant : IServiceCircuitPlant
    {
        private readonly string _context;

        public ServiceCircuitPlant(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }


        public CircuitPlant Get(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[OP].CircuitPlant_Get";
                cmd.Parameters.Add(new SqlParameter("@Circuit_Cod", obj["cod"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));

                //cmd.Parameters.Add("@Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                CircuitPlant response = null;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response = MapToCircuitPlant(reader);
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
        

        

        private CircuitPlant MapToCircuitPlant(SqlDataReader reader)
        {
            return new CircuitPlant()
            {
                Circuit_ID = (int)reader["Circuit_ID"],
                Company_ID = (int)reader["Company_ID"],
                Plant_ID = (int)reader["Plant_ID"],
                Circuit_Cod = (int)reader["Circuit_Cod"],
                Circuit_Desc = reader["Circuit_Desc"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Circuit_Status = reader["Circuit_Status"].ToString(),
            };
        }

    }
}
