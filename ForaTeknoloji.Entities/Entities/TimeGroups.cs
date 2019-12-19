namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TimeGroups : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Zaman Grup No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Zaman_Grup_No { get; set; }

        [Column("Zaman Grup Adi")]
        [StringLength(100)]
        public string Zaman_Grup_Adi { get; set; }

        [Column("Gecis Sinirlama Tipi")]
        public int? Gecis_Sinirlama_Tipi { get; set; }

        [Column("Baslangic Tarihi")]
        public DateTime? Baslangic_Tarihi { get; set; }

        [Column("Bitis Tarihi")]
        public DateTime? Bitis_Tarihi { get; set; }

        [Column("Baslangic Saati")]
        public DateTime? Baslangic_Saati { get; set; }

        [Column("Bitis Saati")]
        public DateTime? Bitis_Saati { get; set; }

        public bool? Pazartesi { get; set; }
                 
        public bool? Sali { get; set; }
                  
        public bool? Carsamba { get; set; }
                 
        public bool? Persembe { get; set; }
                 
        public bool? Cuma { get; set; }
                 
        public bool? Cumartesi { get; set; }
                 
        public bool? Pazar { get; set; }

        public bool? Gun1 { get; set; }

        public bool? Gun2 { get; set; }

        public bool? Gun3 { get; set; }

        public bool? Gun4 { get; set; }

        public bool? Gun5 { get; set; }

        public bool? Gun6 { get; set; }

        public bool? Gun7 { get; set; }

        public bool? Gun8 { get; set; }

        public bool? Gun9 { get; set; }

        public bool? Gun10 { get; set; }

        public bool? Gun11 { get; set; }

        public bool? Gun12 { get; set; }

        public bool? Gun13 { get; set; }

        public bool? Gun14 { get; set; }

        public bool? Gun15 { get; set; }

        public bool? Gun16 { get; set; }

        public bool? Gun17 { get; set; }

        public bool? Gun18 { get; set; }

        public bool? Gun19 { get; set; }

        public bool? Gun20 { get; set; }

        public bool? Gun21 { get; set; }

        public bool? Gun22 { get; set; }

        public bool? Gun23 { get; set; }

        public bool? Gun24 { get; set; }

        public bool? Gun25 { get; set; }

        public bool? Gun26 { get; set; }

        public bool? Gun27 { get; set; }

        public bool? Gun28 { get; set; }

        public bool? Gun29 { get; set; }

        public bool? Gun30 { get; set; }

        public bool? Gun31 { get; set; }

        [Column("Baslangic Saati 1")]
        public DateTime? Baslangic_Saati_1 { get; set; }

        [Column("Baslangic Saati 2")]
        public DateTime? Baslangic_Saati_2 { get; set; }

        [Column("Baslangic Saati 3")]
        public DateTime? Baslangic_Saati_3 { get; set; }

        [Column("Ek Saat")]
        public int? Ek_Saat { get; set; }

        [StringLength(255)]
        public string Aciklama { get; set; }

        [Column("Ilave Saat Kontrolu")]
        public bool? Ilave_Saat_Kontrolu { get; set; }

        [Column("Ilave Baslangic Saati")]
        public DateTime? Ilave_Baslangic_Saati { get; set; }

        [Column("Ilave Bitis Saati")]
        public DateTime? Ilave_Bitis_Saati { get; set; }

        [Column("Baslama Saat 1")]
        public DateTime? Baslama_Saat_1 { get; set; }

        [Column("Bitis Saat 1")]
        public DateTime? Bitis_Saat_1 { get; set; }

        [Column("Baslama Saat 2")]
        public DateTime? Baslama_Saat_2 { get; set; }

        [Column("Bitis Saat 2")]
        public DateTime? Bitis_Saat_2 { get; set; }

        [Column("Baslama Saat 3")]
        public DateTime? Baslama_Saat_3 { get; set; }

        [Column("Bitis Saat 3")]
        public DateTime? Bitis_Saat_3 { get; set; }

        [Column("Baslama Saat 4")]
        public DateTime? Baslama_Saat_4 { get; set; }

        [Column("Bitis Saat 4")]
        public DateTime? Bitis_Saat_4 { get; set; }

        [Column("Baslama Saat 5")]
        public DateTime? Baslama_Saat_5 { get; set; }

        [Column("Bitis Saat 5")]
        public DateTime? Bitis_Saat_5 { get; set; }

        [Column("Baslama Saat 6")]
        public DateTime? Baslama_Saat_6 { get; set; }

        [Column("Bitis Saat 6")]
        public DateTime? Bitis_Saat_6 { get; set; }

        [Column("Pazartesi Baslangic Saati")]
        public DateTime? Pazartesi_Baslangic_Saati { get; set; }

        [Column("Pazartesi Bitis Saati")]
        public DateTime? Pazartesi_Bitis_Saati { get; set; }

        [Column("Sali Baslangic Saati")]
        public DateTime? Sali_Baslangic_Saati { get; set; }

        [Column("Sali Bitis Saati")]
        public DateTime? Sali_Bitis_Saati { get; set; }

        [Column("Carsamba Baslangic Saati")]
        public DateTime? Carsamba_Baslangic_Saati { get; set; }

        [Column("Carsamba Bitis Saati")]
        public DateTime? Carsamba_Bitis_Saati { get; set; }

        [Column("Persembe Baslangic Saati")]
        public DateTime? Persembe_Baslangic_Saati { get; set; }

        [Column("Persembe Bitis Saati")]
        public DateTime? Persembe_Bitis_Saati { get; set; }

        [Column("Cuma Baslangic Saati")]
        public DateTime? Cuma_Baslangic_Saati { get; set; }

        [Column("Cuma Bitis Saati")]
        public DateTime? Cuma_Bitis_Saati { get; set; }

        [Column("Cumartesi Baslangic Saati")]
        public DateTime? Cumartesi_Baslangic_Saati { get; set; }

        [Column("Cumartesi Bitis Saati")]
        public DateTime? Cumartesi_Bitis_Saati { get; set; }

        [Column("Pazar Baslangic Saati")]
        public DateTime? Pazar_Baslangic_Saati { get; set; }

        [Column("Pazar Bitis Saati")]
        public DateTime? Pazar_Bitis_Saati { get; set; }
    }
}
