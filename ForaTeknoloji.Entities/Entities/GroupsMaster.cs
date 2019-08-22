namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupsMaster")]
    public partial class GroupsMaster : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Grup No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Grup_No { get; set; }

        [Column("Grup Adi")]
        [StringLength(100)]
        public string Grup_Adi { get; set; }

        [StringLength(255)]
        public string Aciklama { get; set; }

        [Column("Grup Gecis Sayisi")]
        public int? Grup_Gecis_Sayisi { get; set; }

        [Column("Grup Gecis Sayisi Global Bolge No")]
        public int? Grup_Gecis_Sayisi_Global_Bolge_No { get; set; }

        [Column("Grup Icerdeki Kisi Sayisi")]
        public int? Grup_Icerdeki_Kisi_Sayisi { get; set; }

        [Column("Grup Icerdeki Kisi Sayisi Global Bolge No")]
        public int? Grup_Icerdeki_Kisi_Sayisi_Global_Bolge_No { get; set; }

        [Column("Lokal Bolge")]
        public int? Lokal_Bolge { get; set; }

        [Column("Mukerrer Engelleme Gecersiz")]
        public bool? Mukerrer_Engelleme_Gecersiz { get; set; }

        [Column("Lokal Kapasite Gecersiz")]
        public bool? Lokal_Kapasite_Gecersiz { get; set; }

        [Column("Antipassback Gecersiz")]
        public bool? Antipassback_Gecersiz { get; set; }

        [Column("Gece Icerdeki Kisi Sayisini Sil")]
        public bool? Gece_Icerdeki_Kisi_Sayisini_Sil { get; set; }

        [Column("Gunluk Aylik")]
        public int? Gunluk_Aylik { get; set; }

        [Column("Gece Antipassback Sil")]
        public bool? Gece_Antipassback_Sil { get; set; }
    }
}
