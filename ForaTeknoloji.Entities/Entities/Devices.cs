namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Devices : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Cihaz ID")]
        public int? Cihaz_ID { get; set; }

        [Column("Cihaz Tipi")]
        public int? Cihaz_Tipi { get; set; }

        [Column("Com Port")]
        public int? Com_Port { get; set; }

        public bool TCPIP { get; set; }

        [Column("IP Adres")]
        [StringLength(50)]
        public string IP_Adres { get; set; }

        [Column("TCP Port")]
        public int? TCP_Port { get; set; }

        public bool Aktif { get; set; }

        [Column("Gecis Tipi")]
        public int? Gecis_Tipi { get; set; }
    }
}
