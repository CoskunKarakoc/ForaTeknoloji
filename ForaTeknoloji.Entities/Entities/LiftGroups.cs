namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LiftGroups : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Asansor Grup No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Asansor_Grup_No { get; set; }

        [Column("Asansor Grup Adi")]
        [StringLength(100)]
        public string Asansor_Grup_Adi { get; set; }

        [Column("Asansor No")]
        public int? Asansor_No { get; set; }

        [Column("Kat Sayisi")]
        public int? Kat_Sayisi { get; set; }

        [Column("Kat 1")]
        public bool? Kat_1 { get; set; }

        [Column("Kat 2")]
        public bool? Kat_2 { get; set; }

        [Column("Kat 3")]
        public bool? Kat_3 { get; set; }

        [Column("Kat 4")]
        public bool? Kat_4 { get; set; }

        [Column("Kat 5")]
        public bool? Kat_5 { get; set; }

        [Column("Kat 6")]
        public bool? Kat_6 { get; set; }

        [Column("Kat 7")]
        public bool? Kat_7 { get; set; }

        [Column("Kat 8")]
        public bool? Kat_8 { get; set; }

        [Column("Kat 9")]
        public bool? Kat_9 { get; set; }

        [Column("Kat 10")]
        public bool? Kat_10 { get; set; }

        [Column("Kat 11")]
        public bool? Kat_11 { get; set; }

        [Column("Kat 12")]
        public bool? Kat_12 { get; set; }

        [Column("Kat 13")]
        public bool? Kat_13 { get; set; }

        [Column("Kat 14")]
        public bool? Kat_14 { get; set; }

        [Column("Kat 15")]
        public bool? Kat_15 { get; set; }

        [Column("Kat 16")]
        public bool? Kat_16 { get; set; }

        [Column("Kat 17")]
        public bool? Kat_17 { get; set; }

        [Column("Kat 18")]
        public bool? Kat_18 { get; set; }

        [Column("Kat 19")]
        public bool? Kat_19 { get; set; }

        [Column("Kat 20")]
        public bool? Kat_20 { get; set; }

        [Column("Kat 21")]
        public bool? Kat_21 { get; set; }

        [Column("Kat 22")]
        public bool? Kat_22 { get; set; }

        [Column("Kat 23")]
        public bool? Kat_23 { get; set; }

        [Column("Kat 24")]
        public bool? Kat_24 { get; set; }

        [Column("Kat 25")]
        public bool? Kat_25 { get; set; }

        [Column("Kat 26")]
        public bool? Kat_26 { get; set; }

        [Column("Kat 27")]
        public bool? Kat_27 { get; set; }

        [Column("Kat 28")]
        public bool? Kat_28 { get; set; }

        [Column("Kat 29")]
        public bool? Kat_29 { get; set; }

        [Column("Kat 30")]
        public bool? Kat_30 { get; set; }

        [Column("Kat 31")]
        public bool? Kat_31 { get; set; }

        [Column("Kat 32")]
        public bool? Kat_32 { get; set; }

        [Column("Kat 33")]
        public bool? Kat_33 { get; set; }

        [Column("Kat 34")]
        public bool? Kat_34 { get; set; }

        [Column("Kat 35")]
        public bool? Kat_35 { get; set; }

        [Column("Kat 36")]
        public bool? Kat_36 { get; set; }

        [Column("Kat 37")]
        public bool? Kat_37 { get; set; }

        [Column("Kat 38")]
        public bool? Kat_38 { get; set; }

        [Column("Kat 39")]
        public bool? Kat_39 { get; set; }

        [Column("Kat 40")]
        public bool? Kat_40 { get; set; }

        [Column("Kat 41")]
        public bool? Kat_41 { get; set; }

        [Column("Kat 42")]
        public bool? Kat_42 { get; set; }

        [Column("Kat 43")]
        public bool? Kat_43 { get; set; }

        [Column("Kat 44")]
        public bool? Kat_44 { get; set; }

        [Column("Kat 45")]
        public bool? Kat_45 { get; set; }

        [Column("Kat 46")]
        public bool? Kat_46 { get; set; }

        [Column("Kat 47")]
        public bool? Kat_47 { get; set; }

        [Column("Kat 48")]
        public bool? Kat_48 { get; set; }

        [Column("Kat 49")]
        public bool? Kat_49 { get; set; }

        [Column("Kat 50")]
        public bool? Kat_50 { get; set; }

        [Column("Kat 51")]
        public bool? Kat_51 { get; set; }

        [Column("Kat 52")]
        public bool? Kat_52 { get; set; }

        [Column("Kat 53")]
        public bool? Kat_53 { get; set; }

        [Column("Kat 54")]
        public bool? Kat_54 { get; set; }

        [Column("Kat 55")]
        public bool? Kat_55 { get; set; }

        [Column("Kat 56")]
        public bool? Kat_56 { get; set; }

        [Column("Kat 57")]
        public bool? Kat_57 { get; set; }

        [Column("Kat 58")]
        public bool? Kat_58 { get; set; }

        [Column("Kat 59")]
        public bool? Kat_59 { get; set; }

        [Column("Kat 60")]
        public bool? Kat_60 { get; set; }

        [Column("Kat 61")]
        public bool? Kat_61 { get; set; }

        [Column("Kat 62")]
        public bool? Kat_62 { get; set; }

        [Column("Kat 63")]
        public bool? Kat_63 { get; set; }

        [Column("Kat 64")]
        public bool? Kat_64 { get; set; }
    }
}
