using System;
using System.Collections.Generic;
using System.Data.Repository;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApplicationMarket.Infrastructure
{
    public class UserProvider : IPrincipal
    {
        private UserIdentity userIdentity { get; set; }

        #region IPrincipal Members


        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            return userIdentity.User.InRoles(role);
        }

        #endregion

        public UserProvider(string name, Repository repository)
        {
            userIdentity = new UserIdentity();
            userIdentity.Init(name, repository);
        }

        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}