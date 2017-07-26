using System;
using System.Collections.Generic;
using System.Data.Repository;
using System.Linq;
using System.Web;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Infrastructure
{
    public class Repository : IRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User Login(string login, string password)
        {
            using(var db = new MarketContext())
            {
                var passwordMD5 = db.EncryptPassword(password);
                return db.Users.FirstOrDefault(p => string.Compare(p.Login, login, true) == 0 && p.PersonPassword == passwordMD5);
            }
        }
        public User Login(string login)
        {
            using (var db = new MarketContext())
            {
                return db.Users.FirstOrDefault(p => string.Compare(p.Login, login, true) == 0);
            }
        }

        public User GetUser(string login)
        {
            using (var db = new MarketContext())
            {
                return db.Users.FirstOrDefault(p => string.Compare(p.Login, login, true) == 0);
            }
        }
        public Roles GetRole(User currentUser)
        {
            using (var dbContext = new MarketContext())
            {
                return dbContext.Roles.FirstOrDefault(u => u.ID == currentUser.RoleId);
            }
        }

        public bool SetLogs(User authUser, Roles role, string action)
        {
            try
            {
                using (var dbContext = new MarketContext())
                {
                    Logs log = new Logs()
                    {
                        UserId = authUser.ID,
                        Username = authUser.LastName + authUser.FirstName + authUser.Patronymic,
                        Dateofactions = DateTime.Now,
                        Actions = action,
                        Rolename = role != null ? role.RoleName : "Не задан"
                    };
                    dbContext.Logs.Add(log);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}