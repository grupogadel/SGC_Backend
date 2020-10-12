using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.XX.Commercial;
using SGC.InterfaceServices.XX.Commercial;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.XX.Commercial
{
    public class ServiceMaquilaCommercial : IServiceMaquilaCommercial
    {
        private readonly string _context;

        public ServiceMaquilaCommercial(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/MaquilaCommercial/GetAll
        public async Task<List<MaquilaCommercial>> GetAll(int id, int cond)
        {
            var response = new List<MaquilaCommercial>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MaquilaCommercial_GetAll";
                cmd.Parameters.Add(new SqlParameter("@Company_ID", id));
                cmd.Parameters.Add(new SqlParameter("@Cond_ID", cond));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMaquilaCommercial(reader));
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

        private MaquilaCommercial MapToMaquilaCommercial(SqlDataReader reader)
        {
            return new MaquilaCommercial()
            {
                MaqComm_ID = (int)reader["MaqComm_ID"],
                Cond_ID = (int)reader["Cond_ID"],
                Company_ID = (int)reader["Company_ID"],
                MaqComm_LeyFrom = (decimal) reader["MaqComm_LeyFrom"],
                MaqComm_LeyTo = (decimal)reader["MaqComm_LeyTo"],
                MaqComm_Maquila = (decimal)reader["MaqComm_Maquila"],
                MaqComm_Recov = (decimal)reader["MaqComm_Recov"],
                MaqComm_MarginPI = (decimal)reader["MaqComm_MarginPI"],
                MaqComm_Consu = (decimal)reader["MaqComm_Consu"],
                MaqComm_ExpAdm = (decimal)reader["MaqComm_ExpAdm"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                MaqComm_Status = reader["MaqComm_Status"].ToString()
            };
        }

    }

}
