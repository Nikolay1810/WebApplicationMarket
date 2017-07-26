using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Infrastructure
{
    public class UserIdentity: IIdentity, IUserProvider
    {
        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if(User != null)
                {
                    return User.Login;
                }
                return "anonym";
            }
        }

        public void Init(string login, Repository repository)
        {
            if (!string.IsNullOrEmpty(login))
            {
                User = repository.GetUser(login);
            }
        }

        //[Inject]
        //public IAuthentication Auth { get; set; }

        //public User CurrentUser
        //{
        //    get
        //    {
        //        return ((IUserProvider)Auth.CurrentUser.Identity).User;
        //    }
        //}

       
    }
}