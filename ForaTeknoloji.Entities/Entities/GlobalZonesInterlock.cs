namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GlobalZonesInterlock")]
    public partial class GlobalZonesInterlock : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Pair No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pair_No { get; set; }

        [Column("Global Zone 1")]
        public int? Global_Zone_1 { get; set; }

        [Column("Global Zone 2")]
        public int? Global_Zone_2 { get; set; }
    }
}
