namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeZoneCalendar")]
    public partial class TimeZoneCalendar : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Grup Takvimi No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Grup_Takvimi_No { get; set; }

        [Column("Grup Takvimi Adi")]
        [StringLength(50)]
        public string Grup_Takvimi_Adi { get; set; }

        [Column("Grup Takvimi Tipi")]
        [StringLength(50)]
        public string Grup_Takvimi_Tipi { get; set; }

        [Column("Grup No 1")]
        public int? Grup_No_1 { get; set; }

        [Column("Tarih 1")]
        public DateTime? Tarih_1 { get; set; }

        [Column("Saat 1")]
        public DateTime? Saat_1 { get; set; }

        [Column("Grup No 2")]
        public int? Grup_No_2 { get; set; }

        [Column("Tarih 2")]
        public DateTime? Tarih_2 { get; set; }

        [Column("Saat 2")]
        public DateTime? Saat_2 { get; set; }

        [Column("Grup No 3")]
        public int? Grup_No_3 { get; set; }
    }
}
