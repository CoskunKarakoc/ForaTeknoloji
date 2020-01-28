namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EMailSettings")]
    public partial class EMailSetting : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("E-Mail Adres")]
        [StringLength(150)]
        public string E_Mail_Adres { get; set; }

        [Column("Kullanici Adi")]
        [StringLength(50)]
        public string Kullanici_Adi { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }

        [Column("SMPT Server")]
        [StringLength(150)]
        public string SMPT_Server { get; set; }

        [Column("SMPT Server Port")]
        public int? SMPT_Server_Port { get; set; }

        [Column("SSL Kullan")]
        public bool? SSL_Kullan { get; set; }

        [Column("Authentication")]
        public int? Authentication { get; set; }

        [Column("Gonderme Saati")]
        public DateTime? Gonderme_Saati { get; set; }

        [Column("Gelmeyenler Raporu")]
        public bool? Gelmeyenler_Raporu { get; set; }

        [Column("Yemekhane Raporu")]
        public bool? Yemekhane_Raporu { get; set; }

        [Column("Kapi Grup No")]
        public int? Kapi_Grup_No { get; set; }

        [Column("Kapi Grup Baslangic Saati")]
        public DateTime? Kapi_Grup_Baslangic_Saati { get; set; }

        [Column("Kapi Grup Bitis Saati")]
        public DateTime? Kapi_Grup_Bitis_Saati { get; set; }

        [Column("Kapi Grup Gonderme Saati")]
        public DateTime? Kapi_Grup_Gonderme_Saati { get; set; }

        [Column("Alici 1 E-Mail Adres")]
        [StringLength(150)]
        public string Alici_1_E_Mail_Adres { get; set; }

        [Column("Alici 1 E-Mail Gonder")]
        public bool? Alici_1_E_Mail_Gonder { get; set; }

        [Column("Alici 2 E-Mail Adres")]
        [StringLength(150)]
        public string Alici_2_E_Mail_Adres { get; set; }

        [Column("Alici 2 E-Mail Gonder")]
        public bool? Alici_2_E_Mail_Gonder { get; set; }

        [Column("Alici 3 E-Mail Adres")]
        [StringLength(150)]
        public string Alici_3_E_Mail_Adres { get; set; }

        [Column("Alici 3 E-Mail Gonder")]
        public bool? Alici_3_E_Mail_Gonder { get; set; }
    }
}
