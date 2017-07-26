using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    public class UserResponce
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "ФИО")]
        public string DisplayName { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Column("Patronymic")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Column("LastName")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Роль")]
        public string RoleName { get; set; }

        public int RoleId { get; set; }

        [Display(Name = "Логин")]
        public string Login { get; set; }

        public string Message { get; set; }

    }
}