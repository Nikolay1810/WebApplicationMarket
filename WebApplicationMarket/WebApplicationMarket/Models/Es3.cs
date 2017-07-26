using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    [Table("es3", Schema = "public")]
    public class Es3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("controllerid")]
        public int ControllerId { get; set; }

        [Column("datewrite")]
        public DateTime DateWrite { get; set; }

        [Column("temperature")]
        public int Temperature { get; set; }

        [Column("stateinput")]
        public int StateInput { get; set; }

        [Column("staterelay0")]
        public int StateRelay0 { get; set; }

        [Column("staterelay1")]
        public int StateRelay1 { get; set; }
    }
}