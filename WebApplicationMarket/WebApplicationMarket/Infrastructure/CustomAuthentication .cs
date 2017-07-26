using Ninject;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Repository;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using WebApplicationMarket.Models;
using System.Web.Http;

namespace WebApplicationMarket.Infrastructure
{
    public class CustomAuthentication : IAuthentication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const string cookieName = "_AUTH_COOKIE";
        private const string cookieUserName = "_USER_NAME";

        public HttpContext HttpContext { get; set; }

        [Inject]
        public Repository repository { get; set; }
        private UserIdentity userIdentity;
        private UserProvider userProvider;

        public CustomAuthentication()
        {
            HttpContext = HttpContext.Current;
            repository = new Repository();
            userIdentity = new UserIdentity();
        }

        #region IAuthentication Members

        public User Login(string userName, string Password, bool isPersistent)
        {
            User retUser = repository.Login(userName, Password);
            if (retUser != null)
            {
                userProvider = new UserProvider(userName, repository);
                userIdentity.User = retUser;
                CreateCookie(retUser.Login, isPersistent);



            }
            return retUser;
        }

        public User GetCurrentUser()

        {
            var user = ((IUserProvider)CurrentUser.Identity).User;
            return user;
        }

        public User Login(string userName)
        {
            User retUser = repository.Login(userName);
            if (retUser != null)
            {
                CreateCookie(retUser.Login);
                //userIdentity.User = retUser;
            }
            return retUser;
        }

        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                1,
                userName,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                isPersistent,
                string.Empty,
                FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var AuthCookie = new HttpCookie(cookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(AuthCookie);

            var UserCookie = new HttpCookie(cookieUserName)
            {
                Value = userName,
                Path = FormsAuthentication.FormsCookiePath,
                //Name = cookieUserName
            };
            HttpContext.Response.Cookies.Add(UserCookie);
            //HttpContext.Response.Cookies.Set(UserCookie);
            //HttpContext.Request.Cookies.Add(UserCookie);
            //HttpContext.Request.Cookies.Set(UserCookie);
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[cookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
                httpCookie.Expires = DateTime.Now.AddDays(-1);
                //HttpContext.Response.Cookies.Remove(httpCookie.Name);
                //HttpContext.Request.Cookies.Remove(httpCookie.Name);
            }
            var userCookie = HttpContext.Response.Cookies[cookieUserName];
            if (userCookie != null)
            {
                userCookie.Value = string.Empty;
                userCookie.Expires = DateTime.Now.AddDays(-1);
            }
        }

        public Models.Roles GetCurrentRole(User user)
        {
            Models.Roles role = new Models.Roles();
            try
            {
                var currentUser = user;
                if (currentUser != null)
                {
                    role = repository.GetRole(currentUser);
                }
            }
            catch (Exception ex)
            {

            }
            return role;
        }

        public bool CreateLog(User authUser, Models.Roles role, string action) 
        {
            return repository.SetLogs(authUser, role, action);
        }

        private IPrincipal _currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            _currentUser = new UserProvider(ticket.Name, repository);
                        }
                        else
                        {
                            _currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed authentification: " + ex.Message);
                        _currentUser = new UserProvider(null, null);
                    }
                }
                return _currentUser;
            }
        }
    }
    #endregion
}