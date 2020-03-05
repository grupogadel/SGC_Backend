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

        // POST: api/MaquilaCommercial/Add
        public int Add(MaquilaCommercial model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MaquilaCommercial_Add";
                cmd.Parameters.Add(new SqlParameter("@Cond_ID", model.Cond_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@MaqComm_LeyFrom", model.MaqComm_LeyFrom));
                cmd.Parameters.Add(new SqlParameter("@MaqComm_LeyTo", model.MaqComm_LeyTo));
                cmd.Parameters.Add(new SqlParameter("@MaqComm_Maquila", model.MaqComm_Maquila));
                cmd.Parameters.Add(new SqlParameter("@MaqComm_Recov", model.MaqComm_Recov));
                cmd.Parameters.Add(new SqlParameter("@MaqComm_MarginPI", model.MaqComm_MarginPI));
                cmd.Parameters.Add(new SqlParameter("@MaqComm_Consu", model.MaqComm_Consu));
                cmd.Parameters.Add(new SqlParameter("@MaqComm_ExpAdm", model.MaqComm_ExpAdm));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));

                cmd.Parameters.Add("@Result",System.Data.SqlDbType.Int).Direction=System.Data.ParameterDirection.ReturnValue;

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

        // PUT: api/MaquilaCommercial/Update/1
        public int Update(MaquilaCommercialHead model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MaquilaCommercial_Update";
                //Head
                cmd.Parameters.Add(new SqlParameter("@Cond_ID", model.Cond_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@CreaModi_User", model.CreaModi_User));
                //Detail
                SqlParameter parMaquilasCommercials = GetMaquilaCommercial("tabMaquilaCommercial", model.MaquilasCommercials);
                cmd.Parameters.Add(parMaquilasCommercials);
                //Output
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

        public static SqlParameter GetMaquilaCommercial(string name, List<MaquilaCommercial> listMaquilaCommercial)
        {
            //logger.InfoFormat("Servicio, Rol:   GetAccesos(string name=:{0}, List<AccesoModel> lstListaAcc)", name);

            try
            {
                DataTable table = new DataTable("dbo.tabMaquilaCommercial");
                table.Columns.Add("MaqComm_ID", typeof(int));
                table.Columns.Add("MaqComm_LeyFrom", typeof(decimal));
                table.Columns.Add("MaqComm_LeyTo", typeof(decimal));
                table.Columns.Add("MaqComm_Maquila", typeof(decimal));
                table.Columns.Add("MaqComm_Recov", typeof(decimal));
                table.Columns.Add("MaqComm_MarginPI", typeof(decimal));
                table.Columns.Add("MaqComm_Consu", typeof(decimal));
                table.Columns.Add("MaqComm_ExpAdm", typeof(decimal));
                table.Columns.Add("MaqComm_Status", typeof(string));

                foreach (MaquilaCommercial maqCom in listMaquilaCommercial)
                    table.Rows.Add(new object[] { maqCom.MaqComm_ID,
                                                  maqCom.MaqComm_LeyFrom,
                                                  maqCom.MaqComm_LeyTo,
                                                  maqCom.MaqComm_Maquila,
                                                  maqCom.MaqComm_Recov,
                                                  maqCom.MaqComm_MarginPI,
                                                  maqCom.MaqComm_Consu,
                                                  maqCom.MaqComm_ExpAdm,
                                                  maqCom.MaqComm_Status
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.tabMaquilaCommercial";

                return parameter;
            }
            catch (Exception e)
            {
                //logger.ErrorFormat("Servicio, Rol:  Error en el metodo GetAccesos(string name=:{0}, List<AccesoModel> lstListaAcc)", name);
                //logger.ErrorFormat("Exception - {0}", e);
                return null;
                throw e;
            }
        }

        // DELETE: api/MaquilaCommercial/Delete/
        public int Delete(int id, string user)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[XX].MaquilaCommercial_Delete";
                cmd.Parameters.Add(new SqlParameter("@MaqComm_ID", id));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", user));

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
