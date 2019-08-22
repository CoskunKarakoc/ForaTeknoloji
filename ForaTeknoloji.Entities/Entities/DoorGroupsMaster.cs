namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoorGroupsMaster")]
    public partial class DoorGroupsMaster : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Kapi Grup No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Kapi_Grup_No { get; set; }

        [Column("Kapi Grup Adi")]
        [StringLength(50)]
        public string Kapi_Grup_Adi { get; set; }
    }
}
