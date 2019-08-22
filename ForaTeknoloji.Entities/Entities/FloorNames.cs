namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FloorNames : IEntity
    {
        [Key]
        [Column("Kat No")]
        public int Kat_No { get; set; }

        [Column("Kat Adi")]
        [StringLength(50)]
        public string Kat_Adi { get; set; }
    }
}
