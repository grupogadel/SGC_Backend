using Microsoft.Extensions.Configuration;
using SGC.Entities.Entities.WK;
using SGC.InterfaceServices.WK;
using SGC.Entities.Entities.XX.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace SGC.Services.WK
{
    public class ServiceLogin : IServiceLogin
    {
        private readonly string _context;
        private List<NavigationMenu> _modules;

        public ServiceLogin(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("Conexion");
        }

        // GET api/UserAccount/GetPerson/
        public async Task<UserAccount> LoginUser(JObject obj)
        {
            var userAccount = new UserAccount();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].LoginUser";
                cmd.Parameters.Add(new SqlParameter("@UserAcc_User", obj["userAcc_User"].ToObject<string>()));
                cmd.Parameters.Add(new SqlParameter("@UserAcc_Pass", obj["userAcc_Pass"].ToObject<string>()));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        userAccount = MapToLoginUser(reader);
                    }
                }
                await conn.CloseAsync();
                userAccount.Company = await GetCompany(userAccount.UserAcc_ID);
                userAccount = await AddPositionCompany(userAccount);

                return userAccount;
            }
            catch (Exception e)
            {
                return userAccount;
                throw e;
            }
        }

        public async Task<List<Company>> GetCompany(int userAcc_ID)
        {
            var response = new List<Company>();
            var index = 0;
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].CompanyUser_Get";

                cmd.Parameters.Add(new SqlParameter("@UserAcc_ID", userAcc_ID));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToCompany(reader, index));
                        index++;
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

        public async Task<List<Position>> GetPosition(int userAcc_ID, int company_ID)
        {
            var response = new List<Position>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].PositionUser_Get";

                cmd.Parameters.Add(new SqlParameter("@UserAcc_ID", userAcc_ID));
                cmd.Parameters.Add(new SqlParameter("@Company_ID", company_ID));


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

        public async Task<UserAccount> AddPositionCompany(UserAccount userAccount)
        {
            var response = new UserAccount();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                for (int i = 0; i < userAccount.Company.Count; i++)
                {
                    userAccount.Company[i].Position = await GetPosition(userAccount.UserAcc_ID, userAccount.Company[i].Company_ID);
                }
                response = userAccount;
                return response;
            }
            catch (Exception e)
            {
                return response;
                throw e;
            }
        }

        public async Task<List<NavigationMenu>> NavigationMenuGet(int idPosition)
        {
            var response = new List<NavigationMenu>();
            try
            {
                List<NavigationMenu> menuitems = await MenuItemsGet(idPosition);
                var responseGroup = new List<NavigationMenu>();
                response = (from item in menuitems
                            where item.Module_Father == null
                            select new NavigationMenu
                            {
                                Id = item.Id,
                                Module_Father = item.Module_Father,
                                Title = item.Title,
                                Icon = item.Icon,
                                Type = item.Type,
                                Url = item.Url,
                                Children = GetChildren(item.Id, menuitems)
                            }).ToList();

                var menuAll = new NavigationMenu();
                menuAll.Id = 0;
                menuAll.Type = "group";
                menuAll.Title = "Modulos";
                menuAll.Module_Father = 1;
                menuAll.Icon = "icon";
                menuAll.Url = "";
                menuAll.Children = response;
                responseGroup.Add(menuAll);

                return responseGroup;
            }
            catch (Exception e)
            {
                return response;
                throw e;
            }
        }

        public async Task<NavigationMenu> GetFather(int father_ID)
        {
            var response = new NavigationMenu();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].Module_GetFather";

                cmd.Parameters.Add(new SqlParameter("@Father_ID", father_ID));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response = MapToMenuModule(reader);
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


        public async Task<List<NavigationMenu>> ModulesByAccess(int idPosition)
        {
            var response = new List<NavigationMenu>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].LoginMenuModule";
                cmd.Parameters.Add(new SqlParameter("@Position_ID", idPosition));


                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMenuModule(reader));
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

        private static List<NavigationMenu> GetChildren(int idCategoria, List<NavigationMenu> menuitems)
        {
            List<NavigationMenu> response = (from item in menuitems
                                               let tieneHijos = menuitems.Where(o => o.Module_Father == item.Id).Any()
                                               where item.Module_Father == idCategoria
                                               select new NavigationMenu
                                               {
                                                   Id = item.Id,
                                                   Module_Father = item.Module_Father,
                                                   Title = item.Title,
                                                   Icon = item.Icon,
                                                   Type = item.Type,
                                                   Url = item.Url,
                                                   Children = tieneHijos && item.Type == "group" ? GetChildren(item.Id, menuitems) : null
                                               }).ToList();

            return response;

        }

        private async Task fathers(NavigationMenu father) {
            if (father.Module_Father == null)
                return;
            NavigationMenu fathert = await GetFather((int)father.Module_Father);
            _modules.Add(fathert);
            await fathers(fathert);
        }

        public async Task<List<NavigationMenu>> MenuItemsGet(int idPosition)
        {
            var modules = new List<NavigationMenu>();
            var access = new List<NavigationMenu>();
            var menu = new List<NavigationMenu>();
            try
            {
                _modules = new List<NavigationMenu>();
                modules = await ModulesByAccess(idPosition);

                foreach (NavigationMenu module in modules){
                    await fathers(module);
                }

                List<NavigationMenu> uniqueFathers = _modules.Distinct().ToList();

                access = await AccessGetPosition(idPosition);
                menu = uniqueFathers.Concat(access.Concat(modules).ToList()).ToList();

                return menu;
            }
            catch (Exception e)
            {
                return menu;
                throw e;
            }
        }

        public async Task<List<NavigationMenu>> AccessGetPosition(int idPosition)
        {
            var response = new List<NavigationMenu>();
            try
            {
                SqlConnection conn = new SqlConnection(_context);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[WK].LoginMenuAccessPosition";

                cmd.Parameters.Add(new SqlParameter("@Position_ID", idPosition));

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        response.Add(MapToMenuAccess(reader));
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
        private UserAccount MapToLoginUser(SqlDataReader reader)
        {
            return new UserAccount()
            {
                UserAcc_ID = (int)reader["UserAcc_ID"],
                UserAcc_User = reader["UserAcc_User"].ToString(),
                UserAcc_Pass = reader["UserAcc_Pass"].ToString(),
                Creation_User = reader["Creation_User"].ToString(),
                Modified_User = reader["Modified_User"].ToString(),
                UserAcc_Status = reader["UserAcc_Status"].ToString(),
                Person_ID = (int)reader["Person_ID"],
                Person_DNI = reader["Person_DNI"].ToString(),
                Person_Name = reader["Person_Name"].ToString(),
                Person_LastName = reader["Person_LastName"].ToString(),
                Person_Number = reader["Person_Number"].ToString(),
                Person_Email = reader["Person_Email"].ToString()
            };
        }


        private Company MapToCompany(SqlDataReader reader, int index)
        {
            return new Company()
            {
                Company_ID = (int)reader["Company_ID"],
                Company_Cod = reader["Company_Cod"].ToString(),
                Company_Name = reader["Company_Name"].ToString(),
                Index = index
            };
        }

        private Position MapToPosition(SqlDataReader reader)
        {
            return new Position()
            {
                Position_ID = (int)reader["Position_ID"],
                Company_ID = (int)reader["Company_ID"],
                Position_Cod = reader["Position_Cod"].ToString(),
                Position_Name = reader["Position_Name"].ToString(),
            };
        }

        private NavigationMenu MapToMenuAccess(SqlDataReader reader)
        {
            return new NavigationMenu()
            {
                Id = (int)reader["Access_ID"],
                Title = reader["Access_Name"].ToString(),
                Url = reader["Access_Url"].ToString(),
                Module_Father = (int)reader["Module_ID"],
                Type = "item",
                Icon = reader["Access_IconName"].ToString(),
            };
        }   
        private NavigationMenu MapToMenuModule(SqlDataReader reader)
        {
            return new NavigationMenu()
            {
                Id = (int)reader["Module_ID"],
                Module_Father = reader["Module_Father"] == DBNull.Value ? new int?() : (int)reader["Module_Father"],
                Title = reader["Module_Name"].ToString(),
                Icon = "fa fa-folder-open",
                Type = "group",
                Url = reader["Module_Name"].ToString(),
            };
        }

    }
}
