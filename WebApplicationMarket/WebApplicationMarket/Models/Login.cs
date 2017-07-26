using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Введите логин")]
        public string UserLogin { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string UserPassword{ get; set; }

        public bool IsPersistent { get; set; }
    }
}