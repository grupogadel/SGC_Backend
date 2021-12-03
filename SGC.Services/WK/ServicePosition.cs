using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.WK;
using SGC.InterfaceServices.WK;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SGC.Services.WK
{
    public class ServicePosition : IServicePosition
    {
        private readonly string _context;

        public ServicePosition(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        private Position MapToPosition(SqlDataReader reader)
        {
            return new Position()
            {
                Position_ID = (int)reader["Position_ID"],
				Company_ID = (int)reader["Company_ID"],
				Company_Name = reader["Company_Name"].ToString(),
                Position_Cod = reader["Position_Cod"].ToString(),
				Position_Name = reader["Position_Name"].ToString(),
				Position_Desc = reader["Position_Desc"].ToString(),
				Position_Father_ID = reader["Position_Father_ID"]==DBNull.Value?(int?)null:(int)reader["Position_Father_ID"],
				Position_FatherName = reader["Position_FatherName"].ToString(),
				Position_Level = reader["Position_Level"]==DBNull.Value?(int?)null:(int)reader["Position_Level"],
                Creation_User = reader["Creation_User"].ToString(),
                Creation_Date = (DateTime)reader["Creation_Date"],
                Modified_User = reader["Modified_User"].ToString(),
                Modified_Date = (DateTime)reader["Modified_Date"],
                Position_Status = reader["Position_Status"].ToString()
            };
        }
		
		public async Task<List<Position>> GetAll()
        {
            var response = new List<Position>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Position_GetAll";
               
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPosition(reader));
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
		
		public async Task<List<Position>> Search(JObject obj)
        {
            var response = new List<Position>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Position_Search";
				
				cmd.Parameters.Add(new SqlParameter("@Company_ID", obj["idCompany"].ToObject<int>()));
                cmd.Parameters.Add(new SqlParameter("@Position_Cod", obj["cod"].ToObject<string>()));
               
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToPosition(reader));
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

        public async Task<List<AccessPosition>> UnlinkedAccesses(int idPosition)
        {
            var response = new List<AccessPosition>();
            var responseLinked = new List<AccessPosition>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Access_GetAll";

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToAccess(reader));
                    }
                }
                await conn.CloseAsync();

                responseLinked = await LinkedAccesses(idPosition);
                response = setPositionUnlinked(responseLinked, response);
                return response;
            }
            catch (Exception e)
            {
                return response;
                throw e;
            }
        }

        public  void ManagementAccess(List<AccessPosition> accessPosition)
        {
            try
            {
                foreach (AccessPosition item in accessPosition)
                {
                     itemGet(item);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public async void itemGet(AccessPosition accessPosition)
        {
            var response = new List<AccessPosition>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Access_Management";

                cmd.Parameters.Add(new SqlParameter("@AccPos_ID", accessPosition.AccPos_ID));
                cmd.Parameters.Add(new SqlParameter("@Access_ID", accessPosition.Access_ID));
                cmd.Parameters.Add(new SqlParameter("@Position_ID", accessPosition.Position_ID));
                cmd.Parameters.Add(new SqlParameter("@AccPos_LimMin", accessPosition.AccPos_LimMin));
                cmd.Parameters.Add(new SqlParameter("@AccPos_LimMax", accessPosition.AccPos_LimMax));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", accessPosition.Modified_User));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", accessPosition.Creation_User));
                cmd.Parameters.Add(new SqlParameter("@AccPos_Status", accessPosition.AccPos_Status));

                //Output
                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                await conn.OpenAsync();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                await conn.CloseAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        public async Task<List<AccessPosition>> LinkedAccesses(int idPosition)
        {
            var response = new List<AccessPosition>();

            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Access_GetLinked";

                cmd.Parameters.Add(new SqlParameter("@Position_ID", idPosition));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                     while (await reader.ReadAsync())
                    {
                        response.Add(MapToAccessPosition(reader));
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


        private AccessPosition MapToAccess(SqlDataReader reader)
        {
            return new AccessPosition()
            {
                AccPos_ID = 0,
                AccPos_LimMax = 0,
                AccPos_LimMin = 0,
                Access = new Access
                {
                    Access_ID = (int)reader["Access_ID"],
                    Module_ID = (int)reader["Module_ID"],
                    Access_Cod = reader["Access_Cod"].ToString(),
                    Access_Name = reader["Access_Name"].ToString(),
                    Access_Desc = reader["Access_Desc"].ToString(),
                    Access_Url = reader["Access_Url"].ToString(),
                    Access_IconName = reader["Access_IconName"].ToString(),
                    Creation_User = reader["Creation_User"].ToString(),
                    Creation_Date = (DateTime)reader["Creation_Date"],
                    Modified_User = reader["Modified_User"].ToString(),
                    Modified_Date = (DateTime)reader["Modified_Date"],
                    Access_Status = reader["Access_Status"].ToString(),
                    Module = new Module
                    {
                        Module_Name = reader["Module_Name"].ToString(),
                        Module_Cod = reader["Module_Cod"].ToString(),
                    }
                }
            };
        }

        private AccessPosition MapToAccessPosition(SqlDataReader reader)
        {
            return new AccessPosition()
            {
                AccPos_ID = (int)reader["AccPos_ID"],
                Access_ID = (int)reader["Access_ID"],
                Position_ID = (int)reader["Position_ID"],
                AccPos_LimMax = reader["AccPos_LimMax"] == DBNull.Value ? (decimal?)null : (decimal)reader["AccPos_LimMax"],
                AccPos_LimMin = reader["AccPos_LimMin"] == DBNull.Value ? (decimal?)null : (decimal)reader["AccPos_LimMin"],
                Creation_User = reader["Creation_UserAP"].ToString(),
                Modified_User = reader["Modified_UserAP"].ToString(),
                Access = new Access{
                    Access_ID = (int)reader["Access_ID"],
                    Module_ID = (int)reader["Module_ID"],
                    Access_Cod = reader["Access_Cod"].ToString(),
                    Access_Name = reader["Access_Name"].ToString(),
                    Access_Desc = reader["Access_Desc"].ToString(),
                    Access_Url = reader["Access_Url"].ToString(),
                    Access_IconName = reader["Access_IconName"].ToString(),
                    Creation_User = reader["Creation_User"].ToString(),
                    Creation_Date = (DateTime)reader["Creation_Date"],
                    Modified_User = reader["Modified_User"].ToString(),
                    Modified_Date = (DateTime)reader["Modified_Date"],
                    Access_Status = reader["Access_Status"].ToString(),
                    Module = new Module
                    {
                        Module_Name = reader["Module_Name"].ToString(),
                        Module_Cod = reader["Module_Cod"].ToString(),
                    }
                }
            };
        }

        // POST: api/Position/Add/{}
        public int Add(Position model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Position_Add";
				cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Position_Cod", model.Position_Cod));
				cmd.Parameters.Add(new SqlParameter("@Position_Father_ID", model.Position_Father_ID??(object)DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Position_Name", model.Position_Name));
                cmd.Parameters.Add(new SqlParameter("@Position_Desc", model.Position_Desc));
				cmd.Parameters.Add(new SqlParameter("@Position_Level", model.Position_Level??(object)DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Creation_User", model.Creation_User));

                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

              
                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;

                if (resul > 0) {
                    model.AccessPosition = setPosition(model.AccessPosition, resul);
                    ManagementAccess(model.AccessPosition);
                    resul = 0;
                }
                conn.Close();
                return resul;
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }

        }

        public List<AccessPosition> setPosition(List<AccessPosition> accessPosition, int idPosition)
        {
            try
            {
                foreach (AccessPosition item in accessPosition)
                {
                    item.Position_ID = idPosition;
                }
                return accessPosition;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AccessPosition> setPositionUnlinked(List<AccessPosition> linked, List<AccessPosition> all)
        {
            List<AccessPosition> accessPositionSend = new List<AccessPosition>();
            List<AccessPosition> accessPositionTemp = all;
            bool be = false;
            try
            {
                
                for (int c = 0; c < all.Count; c++){
                    for (int i = 0; i < linked.Count; i++) {
                        if (all[c].Access.Access_ID == linked[i].Access_ID){
                            be = true;
                            break;
                        }
                        else be = false;
                    }
                    if (be == false) accessPositionSend.Add(all[c]);
                   
                }
                //accessPositionSend = accessPositionTemp;
                return accessPositionSend;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        // PUT: api/Position/Update/{}
        public int Update(Position model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Position_Update";
                cmd.Parameters.Add(new SqlParameter("@Position_ID", model.Position_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", model.Company_ID));
                cmd.Parameters.Add(new SqlParameter("@Position_Cod", model.Position_Cod));
				cmd.Parameters.Add(new SqlParameter("@Position_Father_ID", model.Position_Father_ID??(object)DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Position_Name", model.Position_Name));
                cmd.Parameters.Add(new SqlParameter("@Position_Desc", model.Position_Desc));
				cmd.Parameters.Add(new SqlParameter("@Position_Level", model.Position_Level??(object)DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Modified_User", model.Modified_User));

                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                conn.Open();
                var resul = cmd.ExecuteNonQuery();
                resul = (int)cmd.Parameters["@Result"].Value;
                conn.Close();
                if (resul == 0)
                {
                    ManagementAccess(model.AccessPosition);
                }

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
