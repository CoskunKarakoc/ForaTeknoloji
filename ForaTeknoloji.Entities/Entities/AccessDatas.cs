namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccessDatas : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        public int? ID { get; set; }

        [Column("Kart ID")]
        [StringLength(50)]
        public string Kart_ID { get; set; }

        public DateTime? Tarih { get; set; }

        [Column("Lokal Bolge No")]
        public int? Lokal_Bolge_No { get; set; }

        [Column("Global Bolge No")]
        public int? Global_Bolge_No { get; set; }

        [Column("Panel ID")]
        public int? Panel_ID { get; set; }

        [Column("Kapi ID")]
        public int? Kapi_ID { get; set; }

        [Column("Gecis Tipi")]
        public int? Gecis_Tipi { get; set; }

        public int? Kod { get; set; }

        [Column("Kullanici Tipi")]
        public int? Kullanici_Tipi { get; set; }

        [Column("Visitor Kayit No")]
        public int? Visitor_Kayit_No { get; set; }

        [Column("User Kayit No")]
        public int? User_Kayit_No { get; set; }

        public int? Kontrol { get; set; }

        [Column("Kontrol Tarihi")]
        public DateTime? Kontrol_Tarihi { get; set; }

        [Column("Canli Resim")]
        [StringLength(50)]
        public string Canli_Resim { get; set; }

        [StringLength(50)]
        public string Plaka { get; set; }
    }
}
