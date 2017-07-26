using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplicationMarket.Infrastructure;
using WebApplicationMarket.Infrastructure.Authorize;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Controllers.Graphics
{
    public class GraphicsController : Controller
    {

        [Inject]
        public IAuthentication Auth { get; set; }


        public void WriteLog(string message)
        {
            try
            {
                var currentUser = Auth.GetCurrentUser();
                if (currentUser != null)
                {
                    if (currentUser.RoleId != 0)
                    {
                        var role = Auth.GetCurrentRole(currentUser);
                        var IsWritedLog = Auth.CreateLog(currentUser, role, message);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        // GET: Graphics
        [MyAuthorizeAttribute(Roles = "Admin")]
        public ActionResult Temperature()
        {
            string message = "Зашел на страницу с графиками";
            WriteLog(message);
            return View();
        }


        [HttpPost]
        public string GetDataByTemp(string args)
        {
            var jsSerializer = new JavaScriptSerializer();
            List<Temperature> es3List = new List<Temperature>();

            if (args != null)
            {
                try
                {
                    var Id = jsSerializer.Deserialize<Es3>(args).ID;
                    using (var dbContext = new MarketContext())
                    {
                        var socket3 = dbContext.Es3.Where(u => u.ID > Id && u.ID < (Id + 50)).ToList();
                        var socket5 = dbContext.Es5.Where(u => u.ID > Id && u.ID < (Id + 50)).ToList();

                        for (int i = 0; i < socket3.Count; i++)
                        {
                            es3List.Add(new Temperature()
                            {
                                DateWrite = (socket5[i].DateWrite.Year+"."+socket5[i].DateWrite.Month+"."+socket5[i].DateWrite.Day+" "+
                                socket5[i].DateWrite.Hour+":"+socket5[i].DateWrite.Minute+":"+socket5[i].DateWrite.Second),//.ToString("yyyy.MM.dd"),// HH:mm"),
                                Temperature0 = socket3[i].Temperature,
                                Temperature1 = socket5[i].Temperature0,
                                Temperature2 = socket5[i].Temperature1,
                                Temperature3 = socket5[i].Temperature2,
                                Temperature4 = socket5[i].Temperature3,
                                Temperature5 = socket5[i].Temperature4,
                                Temperature6 = socket5[i].Temperature5,
                                Temperature7 = socket5[i].Temperature6,
                                Temperature8 = socket5[i].Temperature7,
                                Temperature9 = socket5[i].Temperature8,
                                Temperature10 = socket5[i].Temperature9,
                                Temperature11 = socket5[i].Temperature10,
                                Temperature12 = socket5[i].Temperature11,
                                Temperature13 = socket5[i].Temperature12,
                                Temperature14 = socket5[i].Temperature13
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return jsSerializer.Serialize(es3List);
        }
    }
}