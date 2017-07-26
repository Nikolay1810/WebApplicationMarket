using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    [Table("logs", Schema = "public")]
    public class Logs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("userid")]
        public int UserId { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("actions")]
        public string Actions { get; set; }

        [Column("dateofactions")]
        public DateTime Dateofactions { get; set; }

        [Column("rolename")]
        public string Rolename { get; set; }
    }
}