using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    public class LogsRequest
    {
        public int UserId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Username { get; set; }

        public string Actions { get; set; }

        public string Rolename { get; set; }

        public string DateofactionsStr { get; set; }
    }
}