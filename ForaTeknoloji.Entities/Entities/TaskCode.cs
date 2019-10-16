namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaskCode:IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Gorev Adi")]
        [Required]
        [StringLength(150)]
        public string Gorev_Adi { get; set; }

        [Column("Gorev Kodu")]
        public int Gorev_Kodu { get; set; }
    }
}
