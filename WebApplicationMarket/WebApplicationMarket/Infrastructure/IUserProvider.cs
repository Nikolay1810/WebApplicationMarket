using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMarket.Models;

namespace WebApplicationMarket.Infrastructure
{
    interface IUserProvider
    {
        User User { get; set; }
    }
}
