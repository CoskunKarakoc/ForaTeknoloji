namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Maps : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Harita No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Harita_No { get; set; }

        [Column("Harita Adi")]
        [StringLength(100)]
        public string Harita_Adi { get; set; }

        [StringLength(255)]
        public string Resim { get; set; }
    }
}
