using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SGC.Entities.Entities.WK;
using SGC.InterfaceServices.WK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SGC.Services.WK
{
    public class ServiceUserAccount: IServiceUserAccount
    {
        private readonly string _context;

        public ServiceUserAccount(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET: api/UserAccount/GetAll
        public async Task<List<UserAccount>> GetAll()
        {
            var users = new List<UserAccount>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].UserAccount_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(MapToUserAccount(reader));
                    }
                }
                await conn.CloseAsync();
                return users;
            }
            catch (Exception e)
            {
                return users;
                throw e;
            }
        }
		
		// GET: api/UserAccount/GetAllPositionByUser/1
        public async Task<List<UserPosition>> GetAllPositionByUser(int id)
        {
            var response = new List<UserPosition>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].PositionByUser_GetAll";
				
				cmd.Parameters.Add(new SqlParameter("@UserAcc_ID", id));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToUserPosition(reader));
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

        private UserAccount MapToUserAccount(SqlDataReader reader)
        {
            return new UserAccount()
            {
                UserAcc_ID = (int)reader["UserAcc_ID"],
				Person_ID = (int)reader["Person_ID"],
                UserAcc_User = reader["UserAcc_User"].ToString(),
                UserAcc_Pass = reader["UserAcc_Pass"].ToString(),
				Creation_User = reader["Creation_User"].ToString(),
				Creation_Date = (DateTime)reader["Creation_Date"],
				Modified_User = reader["Modified_User"].ToString(),
				Modified_Date = (DateTime)reader["Modified_Date"],
				UserAcc_Status = reader["UserAcc_Status"].ToString(),
				
				Person_DNI = reader["Person_DNI"].ToString(),
				Person_Name = reader["Person_Name"].ToString(),
				Person_LastName = reader["Person_LastName"].ToString(),
				Person_Number = reader["Person_Number"].ToString(),
				Person_Email = reader["Person_Email"].ToString()
				
            };
        }

        private UserPosition MapToUserPosition(SqlDataReader reader)
        {
            return new UserPosition()
            {
				UserPos_ID = (int) reader["UserPos_ID"],
				UserAcc_ID = (int) reader["UserAcc_ID"],
                Position_ID = (int)reader["Position_ID"],
				Creation_User = reader["Creation_User"].ToString(),
				Creation_Date = (DateTime)reader["Creation_Date"],
				Modified_User = reader["Modified_User"].ToString(),
				Modified_Date = (DateTime)reader["Modified_Date"],
				UserPos_Status = reader["UserPos_Status"].ToString(),
				
                Position_Name = reader["Position_Name"].ToString(),
                Company_ID = (int) reader["Company_ID"],
				Company_Name = reader["Company_Name"].ToString()
            };
        }
		
		private Person MapToPerson(SqlDataReader reader)
        {
            return new Person()
            {
				Person_ID = (int) reader["Person_ID"],
				Person_DNI = reader["Person_DNI"].ToString(),
				Person_Name = reader["Person_Name"].ToString(),
				Person_LastName = reader["Person_LastName"].ToString(),
				Person_Number = reader["Person_Number"].ToString(),
				Person_Email = reader["Person_Email"].ToString(),
				Creation_User = reader["Creation_User"].ToString(),
				Creation_Date = (DateTime)reader["Creation_Date"],
				Modified_User = reader["Modified_User"].ToString(),
				Modified_Date = (DateTime)reader["Modified_Date"],
				Person_Status = reader["Person_Status"].ToString()
            };
        }
		
		// GET api/UserAccount/GetUserAccount/
        public UserAccount GetUserAccount(string dni)
        {
			UserAccount user = new UserAccount();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].UserAccount_Get";
                cmd.Parameters.Add(new SqlParameter("@Person_DNI", dni));

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = MapToUserAccount(reader);
                    }
                }
                conn.Close();
                return user;
            }
            catch (Exception e)
            {
                return user;
                throw e;
            }
        }
		
		// GET api/UserAccount/GetPerson/
        public Person GetPerson(string dni)
        {
			Person person = new Person();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Person_Get";
                cmd.Parameters.Add(new SqlParameter("@Person_DNI", dni));

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        person = MapToPerson(reader);
                    }
                }
                conn.Close();
                return person;
            }
            catch (Exception e)
            {
                return person;
                throw e;
            }
        }

        // POST: api/UserAccount/Add/{}
        public int Add(JObject obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].UserAccount_Add";
                cmd.Parameters.Add(new SqlParameter("@Option", obj["option"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Person_ID", obj["person_ID"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@UserAcc_User", obj["userAcc_User"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@UserAcc_Pass", obj["userAcc_Pass"].ToObject<string>()));
				cmd.Parameters.Add(new SqlParameter("@Person_DNI", obj["person_DNI"].ToObject<string>()));
				cmd.Parameters.Add(new SqlParameter("@Person_Name", obj["person_Name"].ToObject<string>()));
				cmd.Parameters.Add(new SqlParameter("@Person_LastName", obj["person_LastName"].ToObject<string>()));
				cmd.Parameters.Add(new SqlParameter("@Person_Number", obj["person_Number"].ToObject<string>()));
				cmd.Parameters.Add(new SqlParameter("@Person_Email", obj["person_Email"].ToObject<string>()));
				cmd.Parameters.Add(new SqlParameter("@Position_ID", obj["position_ID"].ToObject<int>()));
				cmd.Parameters.Add(new SqlParameter("@Creation_User", obj["creation_User"].ToObject<string>()));

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

        // PUT: api/UserAccount/Update/
        public int Update(UserAccount model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].UserAccount_Update";
                cmd.Parameters.Add(new SqlParameter("@UserAcc_ID", model.UserAcc_ID));
                cmd.Parameters.Add(new SqlParameter("@UserAcc_User", model.UserAcc_User));
                cmd.Parameters.Add(new SqlParameter("@UserAcc_Pass ", model.UserAcc_Pass ));
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

        // PUT: api/UserAccount/UpdateUserPosition/
        public int UpdateUserPosition(UserAccount model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].UserPosition_Update";
				//Head
                cmd.Parameters.Add(new SqlParameter("@UserAcc_ID", model.UserAcc_ID));
                cmd.Parameters.Add(new SqlParameter("@CreaModi_User", model.Modified_User));
				//Detail
                SqlParameter parUserPositionDetails = GetUserPositionDetails("tabUserPositionDetails", model.UserPositions);
                cmd.Parameters.Add(parUserPositionDetails);
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
		
		public SqlParameter GetUserPositionDetails(string name, List<UserPosition> listUserPositionDetails)
        {
            try
            {
                DataTable table = new DataTable("WK.tabUserPositionDetails");
                table.Columns.Add("UserPos_ID", typeof(int));
                table.Columns.Add("Position_ID", typeof(int));
                table.Columns.Add("UserPos_Status", typeof(string));

                foreach (UserPosition userPos in listUserPositionDetails)
                    table.Rows.Add(new object[] { userPos.UserPos_ID,
                                                  userPos.Position_ID,
                                                  userPos.UserPos_Status
                                                });

                SqlParameter parameter = new SqlParameter(name, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "WK.tabUserPositionDetails";

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

    }
}


