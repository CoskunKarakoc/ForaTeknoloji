namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alarmlar")]
    public partial class Alarmlar : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Alarm No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Alarm_No { get; set; }

        [Column("Alarm Adi")]
        [StringLength(50)]
        public string Alarm_Adi { get; set; }

        [Column("Alarm Tipi")]
        public int? Alarm_Tipi { get; set; }

        [Column("Panel No")]
        public int? Panel_No { get; set; }

        [Column("Kapi No")]
        public int? Kapi_No { get; set; }

        [Column("User ID")]
        public int? User_ID { get; set; }

        [Column("Buton No")]
        public int? Buton_No { get; set; }

        [Column("Sensor No")]
        public int? Sensor_No { get; set; }

        [Column("Alarm Sure")]
        public int? Alarm_Sure { get; set; }

        [Column("Alarm Baslama Reset")]
        public int? Alarm_Baslama_Reset { get; set; }

        [Column("Alarm Baslama Zamani")]
        public DateTime? Alarm_Baslama_Zamani { get; set; }

        [Column("Alarm Bitis Zamani")]
        public DateTime? Alarm_Bitis_Zamani { get; set; }

        [Column("Alarm Rolesi")]
        public bool? Alarm_Rolesi { get; set; }

        [Column("Kapi Rolesi")]
        public bool? Kapi_Rolesi { get; set; }

        [Column("Kapi Role No")]
        public int? Kapi_Role_No { get; set; }

        [StringLength(255)]
        public string Aciklama { get; set; }

        public bool? Etkinlestir { get; set; }

        [Column("Acilir Pencere")]
        public bool? Acilir_Pencere { get; set; }

        [Column("Acilir Pencere Mesaji")]
        [StringLength(200)]
        public string Acilir_Pencere_Mesaji { get; set; }
    }
}
