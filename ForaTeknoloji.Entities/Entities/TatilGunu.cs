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
    public class TatilGunu:IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Ozel Gun No")]
        public int Ozel_Gun_No { get; set; }

        public string Ozel_Gun_Adi { get; set; }

        [Column("Haftanin Gunu")]
        public int? Haftanin_Gunu { get; set; }

        [Column("Tarih")]
        public DateTime? Tarih { get; set; }

    }
}
