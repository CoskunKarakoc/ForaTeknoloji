namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserTypes : IEntity
    {
        [Key]
        [Column("Kullanici Tipi")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Kullanici_Tipi { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }
    }
}
