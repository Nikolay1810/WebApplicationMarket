using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    [Table("users", Schema = "public")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("firstname")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Column("patronymic")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Column("lastname")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Column("roleid")]
        [Display(Name = "Роль")]
        public int RoleId { get; set; }

        [Required]
        [Column("login")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Column("personpassword")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string PersonPassword { get; set; }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            using (var dbContext = new MarketContext())
            {
                var userRoles = dbContext.Roles.ToList();

                foreach (var role in rolesArray)
                {
                    var hasRole = userRoles.Any(p => string.Compare(p.RoleName.Trim(), role, true) == 0);
                    if (hasRole)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}