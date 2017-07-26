using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Infrastructure.Authorize
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] allowedUsers = new string[] { };
        private string[] allowedRoles = new string[] { };
        [Inject]
        private IAuthentication Auth { get; set; }
        public RedirectToRouteResult redirect;

        public delegate void AuthorizeDelegate();
        public event AuthorizeDelegate onAuth;
        

        public MyAuthorizeAttribute() {
            redirect = null;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Auth = new CustomAuthentication();
            var currentUser = Auth.GetCurrentUser();
            var IsAuthorized = currentUser != null ? true : false;
            if (!IsAuthorized)
            {
            }
            if (!String.IsNullOrEmpty(base.Users))
            {
                allowedUsers = base.Users.Split(new char[] { ',' });
                for (int i = 0; i < allowedUsers.Length; i++)
                {
                    allowedUsers[i] = allowedUsers[i].Trim();
                }
            }
            if (!String.IsNullOrEmpty(base.Roles))
            {
                allowedRoles = base.Roles.Split(new char[] { ',' });
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    allowedRoles[i] = allowedRoles[i].Trim();
                }
            }
            return IsAuthorized && User(currentUser) && Role(currentUser);
        }

        private bool User(User currentUser)
        {
            if (allowedUsers.Length > 0)
            {
                return allowedUsers.Contains(currentUser.Login);
            }
            return true;
        }

        private bool Role(User currentUser)
        {
            if (allowedRoles.Length > 0)
            {
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    if (currentUser.InRoles(allowedRoles[i]))
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        public ActionResult SomeMethod()
        {
            var res = new RedirectToRouteResult(
                            new System.Web.Routing.RouteValueDictionary {
                                {"controller", "Account"}, {"action", "Login" }
                            });
            return res;
        }

        //public void OnAuthorization(HttpContextBase filterContext)
        //{
        //    bool auth = filterContext.HttpContext.User.IsInRole("Admin");
        //    if (!auth)
        //    {
        //        var res = new RedirectToRouteResult(
        //            new System.Web.Routing.RouteValueDictionary {
        //                {"controller", "Account"}, {"action", "Login" }
        //            });
        //        //filterContext.Result = new RedirectToRouteResult(
        //        //    new System.Web.Routing.RouteValueDictionary {
        //        //        {"controller", "Account"}, {"action", "Login" }
        //        //    });
        //    }
        //}
    }
}