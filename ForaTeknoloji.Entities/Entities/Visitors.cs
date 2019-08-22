namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Visitors:IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Kart ID")]
        [StringLength(50)]
        public string Kart_ID { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        [StringLength(50)]
        public string TCKimlik { get; set; }

        [StringLength(25)]
        public string Plaka { get; set; }

        public DateTime? Tarih { get; set; }

        public DateTime? Saat { get; set; }

        [Column("Ziyaret Sebebi")]
        [StringLength(255)]
        public string Ziyaret_Sebebi { get; set; }

        [Column("Grup No")]
        public int? Grup_No { get; set; }

        public int? ID { get; set; }

        [Column("User ID")]
        public int? User_ID { get; set; }

        public bool? UseUserGroup { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string Resim { get; set; }
    }
}
