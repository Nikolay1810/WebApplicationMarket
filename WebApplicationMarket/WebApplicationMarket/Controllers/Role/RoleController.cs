using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplicationMarket.Infrastructure;
using WebApplicationMarket.Infrastructure.Authorize;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Controllers.Role
{
    public class RoleController : Controller
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

        // GET: Home
        [MyAuthorizeAttribute(Roles = "Admin")]
        public ActionResult ListRoles()
        {
            string message = "Зашел в список ролей";
            WriteLog(message);
            List<Roles> listRoles = new List<Roles>();
            try
            {
                using (var dbContext = new MarketContext())
                {
                    //dbContext.Configuration.AutoDetectChangesEnabled = false;
                    listRoles = dbContext.Roles.ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return View(listRoles);
        }

        [MyAuthorizeAttribute(Roles = "Admin")]
        public ActionResult Create()
        {
            string message = "Зашел на страницу для cоздания или редактирования ролей";
            WriteLog(message);
            return View();
        }

       [HttpPost]
       public string GetAllRoles()
        {
            List<Roles> roles = new List<Roles>();
            var jsSerializer = new JavaScriptSerializer();
            try
            {
                using(var dbContext = new MarketContext())
                {
                    roles = dbContext.Roles.ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return jsSerializer.Serialize(roles);
        }

        [HttpPost]
        public string CreateRole(string args)
        {
            var jsSerializer = new JavaScriptSerializer();
            string message = "Добавил новую роль";
            
            try
            {
                using (var dbContext = new MarketContext())
                {
                    dbContext.Configuration.AutoDetectChangesEnabled = false;
                    var argsAsObject = jsSerializer.Deserialize<Roles>(args);
                    //var newRole = new Roles();

                    //newRole.RoleName = argsAsObject.RoleName;
                    //dbContext.Entry(newRole).State = EntityState.Added;
                    dbContext.Roles.Add(new Roles()
                    {
                        RoleName = argsAsObject.RoleName
                    });
                    dbContext.ChangeTracker.DetectChanges();
                    dbContext.SaveChanges();
                    WriteLog(message);
                }
            }
            catch(Exception ex)
            {

            }
            return "1";
        }

        [HttpPost]
        public string GetRoleById(string args)
        {
            Roles role = new Roles();
            var jsSerializer = new JavaScriptSerializer();
            try
            {
                var argsAsObject = jsSerializer.Deserialize<Roles>(args);
                using (var dbContext = new MarketContext())
                {
                    role = dbContext.Roles.FirstOrDefault(u => u.ID == argsAsObject.ID);
                    if(role == null)
                    {
                        return "";
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return jsSerializer.Serialize(role);
        }

        [HttpPost]
        public string Edit(string args)
        {
            var jsSerializer = new JavaScriptSerializer();
            string message = "Изменил существующую роль";
            try
            {
                using (var dbContext = new MarketContext())
                {
                    var argsAsObject = jsSerializer.Deserialize<Roles>(args);
                    var role = dbContext.Roles.FirstOrDefault(u => u.ID == argsAsObject.ID);
                    if (role != null)
                    {
                        role.RoleName = argsAsObject.RoleName;
                    }

                    dbContext.SaveChanges();
                    WriteLog(message);
                }
            }
            catch (Exception ex)
            {

            }
            return "1";
        }

        [HttpPost]
        public string Delete(string args)
        {
            var jsSerializer = new JavaScriptSerializer();
            string message = "Удалил роль";
            try
            {
                var argsAsObject = jsSerializer.Deserialize<Roles>(args);
                using (var dbContext = new MarketContext())
                {
                    var role = dbContext.Roles.FirstOrDefault(u => u.ID == argsAsObject.ID);
                    if (role != null)
                    {
                        dbContext.Roles.Remove(role);
                        dbContext.SaveChanges();
                        WriteLog(message);
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return "1";
        }
    }
}