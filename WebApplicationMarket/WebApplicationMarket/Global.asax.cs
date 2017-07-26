using Ninject;
using Ninject.Web.Common;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplicationMarket.App_Start;
using WebApplicationMarket.Infrastructure;

namespace WebApplicationMarket
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //kernal.Bind<IAuthentication>().To<CustomAuthentication>().InRequestScope();
            //NinjectWebCommon.Start();



        }
    }
}
