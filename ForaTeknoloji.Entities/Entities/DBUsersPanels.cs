namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DBUsersPanels : IEntity
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
    }
}
