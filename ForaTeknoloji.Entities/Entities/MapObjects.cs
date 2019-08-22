namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MapObjects : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Nesne No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Nesne_No { get; set; }

        [Column("Nesne Adi")]
        [StringLength(100)]
        public string Nesne_Adi { get; set; }

        [Column("Nesne Tipi")]
        public int? Nesne_Tipi { get; set; }

        public int? TopPos { get; set; }

        public int? LeftPos { get; set; }

        [Column("Harita No")]
        public int? Harita_No { get; set; }

        [Column("Kamera No")]
        public int? Kamera_No { get; set; }

        [Column("Panel ID")]
        public int? Panel_ID { get; set; }

        [Column("Kapi ID")]
        public int? Kapi_ID { get; set; }

        [Column("Buton ID")]
        public int? Buton_ID { get; set; }

        [Column("Sensor ID")]
        public int? Sensor_ID { get; set; }
    }
}
