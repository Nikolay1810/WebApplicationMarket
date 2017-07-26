using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    [Table("es5", Schema = "public")]
    public class Es5
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("controllerid")]
        public int ControllerId { get; set; }

        [Column("datewrite")]
        public DateTime DateWrite { get; set; }

        [Column("temperature0")]
        public int Temperature0 { get; set; }

        [Column("temperature1")]
        public int Temperature1 { get; set; }

        [Column("temperature2")]
        public int Temperature2 { get; set; }

        [Column("temperature3")]
        public int Temperature3 { get; set; }

        [Column("temperature4")]
        public int Temperature4 { get; set; }

        [Column("temperature5")]
        public int Temperature5 { get; set; }

        [Column("temperature6")]
        public int Temperature6 { get; set; }

        [Column("temperature7")]
        public int Temperature7 { get; set; }

        [Column("temperature8")]
        public int Temperature8 { get; set; }

        [Column("temperature9")]
        public int Temperature9 { get; set; }

        [Column("temperature10")]
        public int Temperature10 { get; set; }

        [Column("temperature11")]
        public int Temperature11 { get; set; }

        [Column("temperature12")]
        public int Temperature12 { get; set; }

        [Column("temperature13")]
        public int Temperature13 { get; set; }
    }
}