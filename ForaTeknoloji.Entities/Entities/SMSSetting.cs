namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SMSSettings")]
    public partial class SMSSetting : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Kullanici Adi")]
        [StringLength(150)]
        public string Kullanici_Adi { get; set; }

        [StringLength(150)]
        public string Sifre { get; set; }

        [StringLength(150)]
        public string Originator { get; set; }

        [StringLength(150)]
        public string UserCode { get; set; }

        [StringLength(150)]
        public string AccountID { get; set; }

        [Column("Gelmeyenler Gonder")]
        public bool? Gelmeyenler_Gonder { get; set; }

        [Column("Gelmeyenler Mesaj")]
        [StringLength(250)]
        public string Gelmeyenler_Mesaj { get; set; }

        [Column("Gelmeyenler Saat")]
        public DateTime? Gelmeyenler_Saat { get; set; }

        [Column("Gelmeyenler Global Bolge")]
        public int? Gelmeyenler_Global_Bolge { get; set; }

        [Column("IcerdeDisarda Gonder")]
        public bool? IcerdeDisarda_Gonder { get; set; }

        [Column("Icerde Mesaj")]
        [StringLength(250)]
        public string Icerde_Mesaj { get; set; }

        [Column("Disarda Mesaj")]
        [StringLength(250)]
        public string Disarda_Mesaj { get; set; }

        [Column("IcerdeDisarda Saat")]
        public DateTime? IcerdeDisarda_Saat { get; set; }

        [Column("IcerdeDisarda Global Bolge")]
        public int? IcerdeDisarda_Global_Bolge { get; set; }

        [Column("HerGirisCikista Gonder")]
        public bool? HerGirisCikista_Gonder { get; set; }

        [Column("HerGirisCikista Mesaj")]
        [StringLength(250)]
        public string HerGirisCikista_Mesaj { get; set; }

        [Column("PanelBaglantiDurumu Gonder")]
        public bool? PanelBaglantiDurumu_Gonder { get; set; }


    }
}
