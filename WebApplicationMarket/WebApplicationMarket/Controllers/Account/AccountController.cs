using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplicationMarket.Infrastructure;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Controllers.Account
{
    public class AccountController : Controller
    {
        [Inject]
        public IAuthentication Auth { get; set; }
       
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

       

        [HttpPost]
        public string Autentication(string args)
        {
            var jsSerializer = new JavaScriptSerializer();
            var argsAsObject = jsSerializer.Deserialize<Login>(args);
            if(argsAsObject != null)
            {
                var authUser = Auth.Login(argsAsObject.UserLogin, argsAsObject.UserPassword, argsAsObject.IsPersistent);
                if (authUser != null)
                {
                    if (authUser.RoleId != 0)
                    {
                        var role = Auth.GetCurrentRole(authUser);
                        var IsWritedLog = Auth.CreateLog(authUser, role, "Залогинился");
                    }
                    return jsSerializer.Serialize(authUser);
                }
            }
            return "1";
        }

        [HttpPost]
        public string WriteLog()
        {
            try
            {
                var currentUser = Auth.GetCurrentUser();
                if (currentUser != null)
                {
                    if (currentUser.RoleId != 0)
                    {
                        var role = Auth.GetCurrentRole(currentUser);
                        var IsWritedLog = Auth.CreateLog(currentUser, role, "Вышел с аккаунта");
                    }
                }
            }
            catch(Exception e)
            {

            }
            return "1";
        }

        [HttpPost]
        public string Logout()
        {
            Auth.LogOut();
            return "1";
        }
    }
}