using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    [Table("Es4", Schema = "public")]
    public class Es4
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }

        [Column("ControllerId")]
        public int ControllerId { get; set; }

        [Column("DateWrite")]
        public DateTime DateWrite { get; set; }

        [Column("StateRelay0")]
        public int StateRelay0 { get; set; }

        [Column("StateRelay1")]
        public int StateRelay1 { get; set; }

        [Column("StateRelay2")]
        public int StateRelay2 { get; set; }

        [Column("StateRelay3")]
        public int StateRelay3 { get; set; }

        [Column("StateRelay4")]
        public int StateRelay4 { get; set; }

        [Column("StateRelay5")]
        public int StateRelay5 { get; set; }

        [Column("StateRelay6")]
        public int StateRelay6 { get; set; }

        [Column("StateRelay7")]
        public int StateRelay7 { get; set; }
    }
}