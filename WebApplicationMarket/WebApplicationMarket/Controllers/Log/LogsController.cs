using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplicationMarket.Infrastructure;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Controllers.Log
{
    public class LogsController : Controller
    {

        // GET: Logs
        public ActionResult Logs()
        {
            return View();
        }
        [Inject]
        public IAuthentication Auth { get; set; }


        public void WriteLog()
        {
            try
            {
                var currentUser = Auth.GetCurrentUser();
                if (currentUser != null)
                {
                    if (currentUser.RoleId != 0)
                    {
                        var role = Auth.GetCurrentRole(currentUser);
                        var IsWritedLog = Auth.CreateLog(currentUser, role, "Посмотрел журнал");
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        [HttpPost]
        public string GetLogs(string args)
        {
            WriteLog();
            var jsSerializer = new JavaScriptSerializer();
            List<LogsRequest> logs = new List<LogsRequest>(); 
            try
            {
                var argsAsObject = jsSerializer.Deserialize<LogsRequest>(args);
                DateTime fromDate = new DateTime();
                DateTime endDate = new DateTime();
                if(argsAsObject != null)
                {

                    if (!string.IsNullOrEmpty(argsAsObject.StartDate))
                    {
                        if (DateTime.TryParse(argsAsObject.StartDate, out fromDate) == false)
                        {
                            fromDate = DateTime.Now.AddDays(-1);
                        }
                    }
                    else
                    {
                        fromDate = DateTime.Now.AddDays(-1);
                    }

                    if (!string.IsNullOrEmpty(argsAsObject.EndDate))
                    {
                        if (DateTime.TryParse(argsAsObject.EndDate, out endDate) == false)
                        {
                            endDate = DateTime.Now;
                        }
                    }
                    else
                    {
                        endDate = DateTime.Now;
                    }

                    using (var dbContext = new MarketContext())
                    {
                        if(argsAsObject.UserId != 0)
                        {
                            var logsList = dbContext.Logs.Where(u=>u.Dateofactions >= fromDate && u.Dateofactions <= endDate && u.UserId == argsAsObject.UserId).ToList();
                        }
                        else
                        {
                           var logsList = dbContext.Logs.Where(u => u.Dateofactions >= fromDate && u.Dateofactions <= endDate).ToList();
                            logs.AddRange(logsList.Select(u => new LogsRequest()
                            {
                                Username = u.Username,
                                Actions = u.Actions,
                                DateofactionsStr = u.Dateofactions.ToString("dd.MM.yy HH:mm"),
                                Rolename = u.Rolename
                            }));
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return jsSerializer.Serialize(logs);
        }


    }
}