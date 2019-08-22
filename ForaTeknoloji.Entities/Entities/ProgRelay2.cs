namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProgRelay2 : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Panel No")]
        public int? Panel_No { get; set; }

        [Column("Haftanin Gunu")]
        public int? Haftanin_Gunu { get; set; }

        [Column("Zaman Dilimi")]
        public int? Zaman_Dilimi { get; set; }

        public bool? Aktif { get; set; }

        [Column("Saat 1")]
        public DateTime? Saat_1 { get; set; }

        [Column("Saat 2")]
        public DateTime? Saat_2 { get; set; }

        [Column("Cihaz 1")]
        public bool? Cihaz_1 { get; set; }

        [Column("Cihaz 2")]
        public bool? Cihaz_2 { get; set; }

        [Column("Cihaz 3")]
        public bool? Cihaz_3 { get; set; }

        [Column("Cihaz 4")]
        public bool? Cihaz_4 { get; set; }

        [Column("Cihaz 5")]
        public bool? Cihaz_5 { get; set; }

        [Column("Cihaz 6")]
        public bool? Cihaz_6 { get; set; }

        [Column("Cihaz 7")]
        public bool? Cihaz_7 { get; set; }

        [Column("Cihaz 8")]
        public bool? Cihaz_8 { get; set; }

        [Column("Role 1")]
        public bool? Role_1 { get; set; }

        [Column("Durum 1")]
        public bool? Durum_1 { get; set; }

        [Column("Role 2")]
        public bool? Role_2 { get; set; }

        [Column("Durum 2")]
        public bool? Durum_2 { get; set; }

        [Column("Role 3")]
        public bool? Role_3 { get; set; }

        [Column("Durum 3")]
        public bool? Durum_3 { get; set; }

        [Column("Role 4")]
        public bool? Role_4 { get; set; }

        [Column("Durum 4")]
        public bool? Durum_4 { get; set; }

        [Column("Role 5")]
        public bool? Role_5 { get; set; }

        [Column("Durum 5")]
        public bool? Durum_5 { get; set; }

        [Column("Role 6")]
        public bool? Role_6 { get; set; }

        [Column("Durum 6")]
        public bool? Durum_6 { get; set; }

        [Column("Role 7")]
        public bool? Role_7 { get; set; }

        [Column("Durum 7")]
        public bool? Durum_7 { get; set; }

        [Column("Role 8")]
        public bool? Role_8 { get; set; }

        [Column("Durum 8")]
        public bool? Durum_8 { get; set; }

        [Column("Role 9")]
        public bool? Role_9 { get; set; }

        [Column("Durum 9")]
        public bool? Durum_9 { get; set; }

        [Column("Role 10")]
        public bool? Role_10 { get; set; }

        [Column("Durum 10")]
        public bool? Durum_10 { get; set; }

        [Column("Role 11")]
        public bool? Role_11 { get; set; }

        [Column("Durum 11")]
        public bool? Durum_11 { get; set; }

        [Column("Role 12")]
        public bool? Role_12 { get; set; }

        [Column("Durum 12")]
        public bool? Durum_12 { get; set; }

        [Column("Role 13")]
        public bool? Role_13 { get; set; }

        [Column("Durum 13")]
        public bool? Durum_13 { get; set; }

        [Column("Role 14")]
        public bool? Role_14 { get; set; }

        [Column("Durum 14")]
        public bool? Durum_14 { get; set; }

        [Column("Role 15")]
        public bool? Role_15 { get; set; }

        [Column("Durum 15")]
        public bool? Durum_15 { get; set; }

        [Column("Role 16")]
        public bool? Role_16 { get; set; }

        [Column("Durum 16")]
        public bool? Durum_16 { get; set; }
    }
}
