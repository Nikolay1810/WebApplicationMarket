using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplicationMarket.Infrastructure;
using WebApplicationMarket.Infrastructure.Authorize;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Controllers.AllUsers
{
    public class AllUsersController : Controller
    {

        [Inject]
        public IAuthentication Auth { get; set; }


        public void WriteLog(string message)
        {
            try
            {
                var currentUser = Auth.GetCurrentUser();
                if (currentUser != null)
                {
                    if (currentUser.RoleId != 0)
                    {
                        var role = Auth.GetCurrentRole(currentUser);
                        var IsWritedLog = Auth.CreateLog(currentUser, role, message);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        // GET: AllUsers
        [MyAuthorizeAttribute(Roles = "Admin")]
        public ActionResult AllUsers()
        {
            string message = "Зашел в список пользователей";
            WriteLog(message);
            List<UserResponce> usersResponceList = new List<UserResponce>();
            try
            {
                using (var dbContext = new MarketContext())
                {
                   var usersList = dbContext.Users.ToList();
                    var rolesList = dbContext.Roles.ToList();
                    Roles role;
                    foreach (var user in usersList)
                    {
                        role = rolesList.FirstOrDefault(u => u.ID == user.RoleId);
                        usersResponceList.Add(new UserResponce()
                        {
                            ID = user.ID,
                            DisplayName = user.LastName + " " + user.FirstName + " " + user.Patronymic,
                            Login = user.Login,
                            RoleName = role != null ? role.RoleName : "&mdash"
                        });
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return View(usersResponceList);
        }

        [MyAuthorizeAttribute(Roles = "Admin")]
        public ActionResult CreateUser()
        {
            string message = "Зашел на страницу создание и редактирования пользователей";
            WriteLog(message);
            return View();
        }

        [HttpPost]
        public string GetAllUsers()
        {
            List<UserResponce> userList = new List<UserResponce>();
            var jsSerializer = new JavaScriptSerializer();
            try
            {
                using (var dbContext = new MarketContext())
                {
                    var users = dbContext.Users.ToList();
                    userList.AddRange(users.Select(u => new UserResponce()
                    {
                        ID = u.ID,
                        DisplayName = u.LastName + " " + u.FirstName +" "+ u.Patronymic,
                    }));
                }
            }
            catch(Exception ex)
            {

            }
            return jsSerializer.Serialize(userList);
        }

        [HttpPost]
        public string GetUerById(string args)
        {
            var jsSerializer = new JavaScriptSerializer();
            User user = new User();
            try
            {
                var argsAsObject = jsSerializer.Deserialize<User>(args);
                using (var dbContext = new MarketContext())
                {
                    user = dbContext.Users.FirstOrDefault(u=>u.ID == argsAsObject.ID);
                    if(user == null)
                    {
                        return "";
                    }
                }

            }
            catch(Exception ex)
            {

            }
            return jsSerializer.Serialize(user);
        }

        [HttpPost]
        public string AddUser(string args)
        {
            UserResponce user = new UserResponce();
            user.Message = "";
            var jsSerializer = new JavaScriptSerializer();
            try
            {
                var argsAsObject = jsSerializer.Deserialize<User>(args);
                if (argsAsObject != null)
                {
                    user.FirstName = argsAsObject.FirstName;
                    user.Patronymic = argsAsObject.Patronymic;
                    user.LastName = argsAsObject.LastName;
                    user.RoleId = argsAsObject.RoleId;
                    user.Login = argsAsObject.Login;

                    string message;

                    using (var dbContext = new MarketContext())
                    {
                        var newPasswordHash = dbContext.EncryptPassword(argsAsObject.PersonPassword);
                        var messageLogin = dbContext.ValidLogin(argsAsObject.Login);
                        var userEdit = dbContext.Users.FirstOrDefault(u => u.ID == argsAsObject.ID);
                        if(userEdit != null)
                        {
                            if (messageLogin == "" && newPasswordHash != "")
                            {
                                userEdit.FirstName = argsAsObject.FirstName;
                                userEdit.Patronymic = argsAsObject.Patronymic;
                                userEdit.LastName = argsAsObject.LastName;
                                userEdit.RoleId = argsAsObject.RoleId;
                                userEdit.Login = argsAsObject.Login;
                                userEdit.PersonPassword = newPasswordHash;
                                dbContext.Entry(userEdit).State = EntityState.Modified;
                                dbContext.SaveChanges();
                                message = "Изменил данный существующего пользователя";
                                WriteLog(message);
                            }
                            else if (messageLogin != "")
                            {
                                user.Message += " " + messageLogin + " ";
                            }
                        }
                        else
                        {
                            if (messageLogin == "" && newPasswordHash != "")
                            {
                                argsAsObject.PersonPassword = newPasswordHash;
                                dbContext.Users.Add(argsAsObject);
                                dbContext.SaveChanges();
                                message = "Добавил нового пользователя";
                                WriteLog(message);
                            }
                            else if (messageLogin != "")
                            {
                                user.Message += " " + messageLogin + " ";
                            }
                        }
                    }
                }
                else
                {
                    user.Message += " Объект не передается на сервер ";
                }

            }
            catch (Exception ex)
            {
                user.Message += " " + ex.Message;
            }
            return jsSerializer.Serialize(user);
        }


        [HttpPost]
        public string DeleteUser(string args)
        {
            var jsSerializer = new JavaScriptSerializer();
            string message = "Удалил пользователя";
            try
            {
                var argsAsObject = jsSerializer.Deserialize<Roles>(args);
                using (var dbContext = new MarketContext())
                {
                    var user = dbContext.Users.FirstOrDefault(u => u.ID == argsAsObject.ID);
                    if (user != null)
                    {
                        dbContext.Users.Remove(user);
                        dbContext.SaveChanges();
                        WriteLog(message);
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "1";
        }
    }
}