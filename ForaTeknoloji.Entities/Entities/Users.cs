namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Users : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column("Kart ID")]
        [Required]
        [StringLength(50)]
        public string Kart_ID { get; set; }

        [Column("Kart ID 2")]
        [StringLength(50)]
        public string Kart_ID_2 { get; set; }

        [Column("Kart ID 3")]
        [StringLength(50)]
        public string Kart_ID_3 { get; set; }

        [Column("Dogrulama PIN")]
        [StringLength(50)]
        public string Dogrulama_PIN { get; set; }

        [Column("Kimlik PIN")]
        public int? Kimlik_PIN { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        [Column("Kullanici Tipi")]
        public int? Kullanici_Tipi { get; set; }

        public int? Sifre { get; set; }

        [Column("Gecis Modu")]
        public int? Gecis_Modu { get; set; }

        [Column("Grup No")]
        public int? Grup_No { get; set; }

        [Column("Visitor Grup No")]
        public int? Visitor_Grup_No { get; set; }

        [StringLength(255)]
        public string Resim { get; set; }

        [StringLength(50)]
        public string Plaka { get; set; }

        [StringLength(50)]
        public string TCKimlik { get; set; }

        [Column("Blok No")]
        public int? Blok_No { get; set; }

        public int? Daire { get; set; }

        [StringLength(255)]
        public string Adres { get; set; }

        public int? Gorev { get; set; }

        [Column("Departman No")]
        public int? Departman_No { get; set; }

        [Column("Alt Departman No")]
        public int? Alt_Departman_No { get; set; }

        [Column("Unvan No")]
        public int? Unvan_No { get; set; }

        [Column("Bolum No")]
        public int? Bolum_No { get; set; }

        [Column("Sirket No")]
        public int? Sirket_No { get; set; }

        [Column("Gorev No")]
        public int? Gorev_No { get; set; }

        [Column("Birim No")]
        public int? Birim_No { get; set; }

        [StringLength(255)]
        public string Aciklama { get; set; }

        public bool? Iptal { get; set; }

        [Column("Grup Takvimi Aktif")]
        public bool? Grup_Takvimi_Aktif { get; set; }

        [Column("Grup Takvimi No")]
        public int? Grup_Takvimi_No { get; set; }

        [Column("Saat 1")]
        public DateTime? Saat_1 { get; set; }

        [Column("Grup No 1")]
        public int? Grup_No_1 { get; set; }

        [Column("Saat 2")]
        public DateTime? Saat_2 { get; set; }

        [Column("Grup No 2")]
        public int? Grup_No_2 { get; set; }

        [Column("Saat 3")]
        public DateTime? Saat_3 { get; set; }

        [Column("Grup No 3")]
        public int? Grup_No_3 { get; set; }

        [StringLength(50)]
        public string Tmp { get; set; }

        [Column("Sureli Kullanici")]
        public bool? Sureli_Kullanici { get; set; }

        [Column("Bitis Tarihi")]
        public DateTime? Bitis_Tarihi { get; set; }

        [Column("Bitis Saati")]
        public DateTime? Bitis_Saati { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        [Column("3 Grup")]
        public bool? C3_Grup { get; set; }

        [StringLength(5)]
        [Column("Kan Grubu")]
        public string Kan_Grubu { get; set; }

    }
}
