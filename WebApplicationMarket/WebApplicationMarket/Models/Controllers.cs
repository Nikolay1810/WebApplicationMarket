using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    [Table("controllers", Schema = "public")]
    public class Controllers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("ipadres")]
        public string IpAdres { get; set; }

        [Column("port")]
        public int Port { get; set; }

        [Column("controllertypeid")]
        public int ControllerTypeId { get; set; }
    }
}