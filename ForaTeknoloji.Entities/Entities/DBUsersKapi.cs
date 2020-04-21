using ForaTeknoloji.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.Entities
{
    [Table("DBUsersKapi")]
    public class DBUsersKapi : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Kullanici Adi")]
        [Required]
        [StringLength(50)]
        public string Kullanici_Adi { get; set; }

        [Column("Panel No")]
        public int? Panel_No { get; set; }

        [Column("Kapi 1")]
        public bool? Kapi_1 { get; set; }

        [Column("Kapi 2")]
        public bool? Kapi_2 { get; set; }

        [Column("Kapi 3")]
        public bool? Kapi_3 { get; set; }

        [Column("Kapi 4")]
        public bool? Kapi_4 { get; set; }

        [Column("Kapi 5")]
        public bool? Kapi_5 { get; set; }

        [Column("Kapi 6")]
        public bool? Kapi_6 { get; set; }

        [Column("Kapi 7")]
        public bool? Kapi_7 { get; set; }

        [Column("Kapi 8")]
        public bool? Kapi_8 { get; set; }

        [Column("Kapi 9")]
        public bool? Kapi_9 { get; set; }

        [Column("Kapi 10")]
        public bool? Kapi_10 { get; set; }

        [Column("Kapi 11")]
        public bool? Kapi_11 { get; set; }

        [Column("Kapi 12")]
        public bool? Kapi_12 { get; set; }

        [Column("Kapi 13")]
        public bool? Kapi_13 { get; set; }

        [Column("Kapi 14")]
        public bool? Kapi_14 { get; set; }

        [Column("Kapi 15")]
        public bool? Kapi_15 { get; set; }

        [Column("Kapi 16")]
        public bool? Kapi_16 { get; set; }


    }
}
