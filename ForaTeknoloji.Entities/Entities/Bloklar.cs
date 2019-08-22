namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bloklar")]
    public partial class Bloklar : IEntity
    {
        [Key]
        [Column("Blok No")]
        public int Blok_No { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }
    }
}
