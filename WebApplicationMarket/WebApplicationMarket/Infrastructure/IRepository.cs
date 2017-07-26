using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Infrastructure
{
    interface IRepository: IDisposable
    {
        User Login(string login, string password);
        User Login(string login);
        User GetUser(string login);
        Roles GetRole(User currentUser);
        bool SetLogs(User currentUser, Roles role, string action);
    }
}
