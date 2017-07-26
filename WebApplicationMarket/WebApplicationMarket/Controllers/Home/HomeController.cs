using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMarket.Infrastructure;
using WebApplicationMarket.Infrastructure.Authorize;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Controllers.Home
{
    public class HomeController : Controller
    {
        [Inject]
        public IAuthentication Auth { get; set; }
        // GET: Home
        //[MyAuthorizeAttribute(Roles = "Admin")]
        public ActionResult Index()
        {
            try
            {
                var currentUser = Auth.GetCurrentUser();
                if (currentUser != null)
                {
                    if (currentUser.RoleId != 0)
                    {
                        var role = Auth.GetCurrentRole(currentUser);
                        var IsWritedLog = Auth.CreateLog(currentUser, role, "Зашел на главную страницу");
                    }
                }
                else
                {
                    return Redirect("/Account/Login");
                }
            }
            catch (Exception e)
            {

            }
            return View();
        }

    }

   
}