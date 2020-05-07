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
    [Table("DBUsersBolum")]
    public class DBUsersBolum:IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Kullanici Adi")]
        [Required]
        [StringLength(50)]
        public string Kullanici_Adi { get; set; }

        [Column("Departman No")]
        public int? Departman_No { get; set; }

        [Column("Alt Departman No")]
        public int? Alt_Departman_No { get; set; }

        [Column("Bolum No")]
        public int? Bolum_No { get; set; }
    }
}
