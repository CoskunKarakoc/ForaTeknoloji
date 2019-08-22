namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DBUsers : IEntity
    {
        [Key]
        [Column("Kullanici Adi")]
        [StringLength(50)]
        public string Kullanici_Adi { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifre { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        public bool? SysAdmin { get; set; }

        [Column("Kullanici Islemleri")]
        public int? Kullanici_Islemleri { get; set; }

        [Column("Grup Islemleri")]
        public int? Grup_Islemleri { get; set; }

        [Column("Programli Kapi Islemleri")]
        public int? Programli_Kapi_Islemleri { get; set; }

        [Column("Gecis Verileri Rapor Islemleri")]
        public int? Gecis_Verileri_Rapor_Islemleri { get; set; }

        [Column("Ziyaretci Islemleri")]
        public int? Ziyaretci_Islemleri { get; set; }

        [Column("Canli Izleme")]
        public int? Canli_Izleme { get; set; }

        [Column("Alarm Islemleri")]
        public int? Alarm_Islemleri { get; set; }

        public bool? OtherDeviceReports { get; set; }
    }
}
