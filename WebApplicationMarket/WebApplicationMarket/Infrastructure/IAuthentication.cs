using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMarket.Models;
using System.Web.Http;
using System.Web;

namespace WebApplicationMarket.Infrastructure
{
    public interface IAuthentication
    {
        /// <summary>
        /// Конекст (тут мы получаем доступ к запросу и кукисам)
        /// </summary>
        HttpContext HttpContext { get; set; }

        User Login(string login, string password, bool isPersistent);

        User Login(string login);

        void LogOut();

        Models.Roles GetCurrentRole(User user);

        bool CreateLog(User authUser, Models.Roles role, string action);

        User GetCurrentUser();

        IPrincipal CurrentUser { get; }
    }
}
