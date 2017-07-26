using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMarket.Models
{
    [Table("Es6", Schema = "public")]
    public class Es6
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }

        [Column("ControllerId")]
        public int ControllerId { get; set; }

        [Column("DateWrite")]
        public DateTime DateWrite { get; set; }

        [Column("BinaryInput0")]
        public int BinaryInput0 { get; set; }

        [Column("BinaryInput1")]
        public int BinaryInput1 { get; set; }

        [Column("BinaryInput2")]
        public int BinaryInput2 { get; set; }

        [Column("BinaryInput3")]
        public int BinaryInput3 { get; set; }

        [Column("BinaryInput4")]
        public int BinaryInput4 { get; set; }

        [Column("BinaryInput5")]
        public int BinaryInput5 { get; set; }

        [Column("BinaryInput6")]
        public int BinaryInput6 { get; set; }

        [Column("BinaryInput7")]
        public int BinaryInput7 { get; set; }

        [Column("BinaryInput8")]
        public int BinaryInput8 { get; set; }

        [Column("BinaryInput9")]
        public int BinaryInput9 { get; set; }

        [Column("BinaryInput10")]
        public int BinaryInput10 { get; set; }

        [Column("BinaryInput11")]
        public int BinaryInput11 { get; set; }

        [Column("BinaryInput12")]
        public int BinaryInput12 { get; set; }

        [Column("BinaryInput13")]
        public int BinaryInput13 { get; set; }

        [Column("BinaryInput14")]
        public int BinaryInput14 { get; set; }

        [Column("BinaryInput15")]
        public int BinaryInput15 { get; set; }

        [Column("BinaryInput16")]
        public int BinaryInput16 { get; set; }

        [Column("BinaryInput17")]
        public int BinaryInput17 { get; set; }

        [Column("BinaryInput18")]
        public int BinaryInput18 { get; set; }

        [Column("BinaryInput19")]
        public int BinaryInput19 { get; set; }

        [Column("BinaryInput20")]
        public int BinaryInput20 { get; set; }

        [Column("BinaryInput21")]
        public int BinaryInput21 { get; set; }

    }
}