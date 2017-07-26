using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    [Table("Es2", Schema = "public")]
    public class Es2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }

        [Column("ControllerId")]
        public int ControllerId { get; set; }

        [Column("DateWrite")]
        public DateTime DateWrite { get; set; }

        [Column("StateInput0")]
        public int StateInput0 { get; set; }

        [Column("StateInput1")]
        public int StateInput1 { get; set; }

        [Column("StateRelay0")]
        public int StateRelay0 { get; set; }

        [Column("StateRelay1")]
        public int StateRelay1 { get; set; }
    }
}