namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskList")]
    public partial class TaskList : IEntity
    {
        [Key]
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Column("Gorev Kodu")]
        public int Gorev_Kodu { get; set; }

        [Column("IntParam 1")]
        public int IntParam_1 { get; set; }

        [Column("IntParam 2")]
        public int? IntParam_2 { get; set; }

        [Column("IntParam 3")]
        public int? IntParam_3 { get; set; }

        [Column("IntParam 4")]
        public int? IntParam_4 { get; set; }

        [Column("IntParam 5")]
        public int? IntParam_5 { get; set; }

        [Column("Panel No")]
        public int? Panel_No { get; set; }

        [Column("Tum Panel")]
        public bool? Tum_Panel { get; set; }

        [Column("Panel Grup 1")]
        public int? Panel_Grup_1 { get; set; }

        [Column("Panel Grup 2")]
        public int? Panel_Grup_2 { get; set; }

        [Column("Panel Grup 3")]
        public int? Panel_Grup_3 { get; set; }

        [Column("Deneme Sayisi")]
        public int? Deneme_Sayisi { get; set; }

        [Column("Durum Kodu")]
        public int Durum_Kodu { get; set; }

        public DateTime Tarih { get; set; }

        [Column("Kullanici Adi")]
        [Required]
        [StringLength(50)]
        public string Kullanici_Adi { get; set; }

        [Column("Tablo Guncelle")]
        public bool? Tablo_Guncelle { get; set; }

        [Column("StrParam 1")]
        [StringLength(250)]
        public string StrParam_1 { get; set; }

        [Column("StrParam 2")]
        [StringLength(250)]
        public string StrParam_2 { get; set; }

        [Column("StrParam 3")]
        [StringLength(250)]
        public string StrParam_3 { get; set; }
    }
}

