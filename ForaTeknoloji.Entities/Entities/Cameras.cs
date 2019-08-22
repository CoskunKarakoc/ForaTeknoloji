namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cameras : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Kamera No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Kamera_No { get; set; }

        [Column("Kamera Adi")]
        [StringLength(100)]
        public string Kamera_Adi { get; set; }

        [Column("Kamera Tipi")]
        public int? Kamera_Tipi { get; set; }

        [Column("IP Adres")]
        [StringLength(50)]
        public string IP_Adres { get; set; }

        [Column("TCP Port")]
        public int? TCP_Port { get; set; }

        [Column("UDP Port")]
        public int? UDP_Port { get; set; }

        [Column("Kamera Admin")]
        [StringLength(50)]
        public string Kamera_Admin { get; set; }

        [Column("Kamera Password")]
        [StringLength(50)]
        public string Kamera_Password { get; set; }

        [StringLength(255)]
        public string Aciklama { get; set; }

        [Column("Geciste Resim Kayit")]
        public bool? Geciste_Resim_Kayit { get; set; }

        [Column("Geciste Video Kayit")]
        public bool? Geciste_Video_Kayit { get; set; }

        [Column("Antipassback Resim Kayit")]
        public bool? Antipassback_Resim_Kayit { get; set; }

        [Column("Antipassback Video Kayit")]
        public bool? Antipassback_Video_Kayit { get; set; }

        [Column("Engellenen Resim Kayit")]
        public bool? Engellenen_Resim_Kayit { get; set; }

        [Column("Engellenen Video Kayit")]
        public bool? Engellenen_Video_Kayit { get; set; }

        [Column("Tanimsiz Resim Kayit")]
        public bool? Tanimsiz_Resim_Kayit { get; set; }

        [Column("Tanimsiz Video Kayit")]
        public bool? Tanimsiz_Video_Kayit { get; set; }

        [Column("Panel ID")]
        public int? Panel_ID { get; set; }

        [Column("Kapi ID")]
        public int? Kapi_ID { get; set; }
    }
}
