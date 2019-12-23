namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DoorStatus : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Panel ID")]
        public int? Panel_ID { get; set; }

        [Column("Kapi 1 Baglanti")]
        public bool? Kapi_1_Baglanti { get; set; }

        [Column("Kapi 2 Baglanti")]
        public bool? Kapi_2_Baglanti { get; set; }

        [Column("Kapi 3 Baglanti")]
        public bool? Kapi_3_Baglanti { get; set; }

        [Column("Kapi 4 Baglanti")]
        public bool? Kapi_4_Baglanti { get; set; }

        [Column("Kapi 5 Baglanti")]
        public bool? Kapi_5_Baglanti { get; set; }

        [Column("Kapi 6 Baglanti")]
        public bool? Kapi_6_Baglanti { get; set; }

        [Column("Kapi 7 Baglanti")]
        public bool? Kapi_7_Baglanti { get; set; }

        [Column("Kapi 8 Baglanti")]
        public bool? Kapi_8_Baglanti { get; set; }

        [Column("Kapi 9 Baglanti")]
        public bool? Kapi_9_Baglanti { get; set; }

        [Column("Kapi 10 Baglanti")]
        public bool? Kapi_10_Baglanti { get; set; }

        [Column("Kapi 11 Baglanti")]
        public bool? Kapi_11_Baglanti { get; set; }

        [Column("Kapi 12 Baglanti")]
        public bool? Kapi_12_Baglanti { get; set; }

        [Column("Kapi 13 Baglanti")]
        public bool? Kapi_13_Baglanti { get; set; }

        [Column("Kapi 14 Baglanti")]
        public bool? Kapi_14_Baglanti { get; set; }

        [Column("Kapi 15 Baglanti")]
        public bool? Kapi_15_Baglanti { get; set; }

        [Column("Kapi 16 Baglanti")]
        public bool? Kapi_16_Baglanti { get; set; }

        [Column("Kapi 1 Sensor")]
        public bool? Kapi_1_Sensor { get; set; }

        [Column("Kapi 2 Sensor")]
        public bool? Kapi_2_Sensor { get; set; }

        [Column("Kapi 3 Sensor")]
        public bool? Kapi_3_Sensor { get; set; }

        [Column("Kapi 4 Sensor")]
        public bool? Kapi_4_Sensor { get; set; }

        [Column("Kapi 5 Sensor")]
        public bool? Kapi_5_Sensor { get; set; }

        [Column("Kapi 6 Sensor")]
        public bool? Kapi_6_Sensor { get; set; }

        [Column("Kapi 7 Sensor")]
        public bool? Kapi_7_Sensor { get; set; }

        [Column("Kapi 8 Sensor")]
        public bool? Kapi_8_Sensor { get; set; }

        [Column("Kapi 9 Sensor")]
        public bool? Kapi_9_Sensor { get; set; }

        [Column("Kapi 10 Sensor")]
        public bool? Kapi_10_Sensor { get; set; }

        [Column("Kapi 11 Sensor")]
        public bool? Kapi_11_Sensor { get; set; }

        [Column("Kapi 12 Sensor")]
        public bool? Kapi_12_Sensor { get; set; }

        [Column("Kapi 13 Sensor")]
        public bool? Kapi_13_Sensor { get; set; }

        [Column("Kapi 14 Sensor")]
        public bool? Kapi_14_Sensor { get; set; }

        [Column("Kapi 15 Sensor")]
        public bool? Kapi_15_Sensor { get; set; }

        [Column("Kapi 16 Sensor")]
        public bool? Kapi_16_Sensor { get; set; }

        [Column("Kapi 1 Button")]
        public bool? Kapi_1_Button { get; set; }

        [Column("Kapi 2 Button")]
        public bool? Kapi_2_Button { get; set; }

        [Column("Kapi 3 Button")]
        public bool? Kapi_3_Button { get; set; }

        [Column("Kapi 4 Button")]
        public bool? Kapi_4_Button { get; set; }

        [Column("Kapi 5 Button")]
        public bool? Kapi_5_Button { get; set; }

        [Column("Kapi 6 Button")]
        public bool? Kapi_6_Button { get; set; }

        [Column("Kapi 7 Button")]
        public bool? Kapi_7_Button { get; set; }

        [Column("Kapi 8 Button")]
        public bool? Kapi_8_Button { get; set; }

        [Column("Kapi 10 Button")]
        public bool? Kapi_10_Button { get; set; }

        [Column("Kapi 11 Button")]
        public bool? Kapi_11_Button { get; set; }

        [Column("Kapi 12 Button")]
        public bool? Kapi_12_Button { get; set; }

        [Column("Kapi 13 Button")]
        public bool? Kapi_13_Button { get; set; }

        [Column("Kapi 14 Button")]
        public bool? Kapi_14_Button { get; set; }

        [Column("Kapi 15 Button")]
        public bool? Kapi_15_Button { get; set; }

        [Column("Kapi 16 Button")]
        public bool? Kapi_16_Button { get; set; }

        [Column("Hirsiz Alarm Durumu")]
        public bool? Hirsiz_Alarm_Durumu { get; set; }

        [Column("Yangin Alarm Durumu")]
        public bool? Yangin_Alarm_Durumu { get; set; }

        [Column("Kapi Alarm Durumu")]
        public bool? Kapi_Alarm_Durumu { get; set; }

        [Column("Seri No")]
        public int? Seri_No { get; set; }

        [Column("Kapi 9 Button")]
        public bool? Kapi_9_Button { get; set; }
    }
}
