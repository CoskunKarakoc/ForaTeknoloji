namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sirketler")]
    public partial class Sirketler : IEntity
    {
        [Key]
        [Column("Sirket No")]
        public int Sirket_No { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }
    }
}
