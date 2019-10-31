namespace ForaTeknoloji.Entities.Entities
{

    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReaderSettingsNew")]
    public partial class ReaderSettingsNew : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Column("Seri No")]
        public int? Seri_No { get; set; }

        [Column("Sira No")]
        public int? Sira_No { get; set; }

        [Column("Panel ID")]
        public int? Panel_ID { get; set; }

        [Column("Panel Name")]
        [StringLength(50)]
        public string Panel_Name { get; set; }

        [Key]
        [Column("WKapi ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WKapi_ID { get; set; }

        [Column("WKapi Aktif")]
        public bool? WKapi_Aktif { get; set; }

        [Column("WKapi Lift Aktif")]
        public bool? WKapi_Lift_Aktif { get; set; }

        [Column("WKapi Role No")]
        public int? WKapi_Role_No { get; set; }

        [Column("WKapi Adi")]
        [StringLength(50)]
        public string WKapi_Adi { get; set; }

        [Column("WKapi Kapi Tipi")]
        public int? WKapi_Kapi_Tipi { get; set; }

        [Column("WKapi WIGType")]
        public int? WKapi_WIGType { get; set; }

        [Column("WKapi Lokal Bolge")]
        public int? WKapi_Lokal_Bolge { get; set; }

        [Column("WKapi Gecis Modu")]
        public int? WKapi_Gecis_Modu { get; set; }

        [Column("WKapi Alarm Modu")]
        public int? WKapi_Alarm_Modu { get; set; }

        [Column("WKapi Yangin Modu")]
        public bool? WKapi_Yangin_Modu { get; set; }

        [Column("WKapi Pin Dogrulama")]
        public bool? WKapi_Pin_Dogrulama { get; set; }

        [Column("WKapi Ana Alarm Rolesi")]
        public bool? WKapi_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi Sirali Gecis Ana Kapi")]
        public bool? WKapi_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi Coklu Onay")]
        public bool? WKapi_Coklu_Onay { get; set; }

        [Column("WKapi Acik Sure")]
        public int? WKapi_Acik_Sure { get; set; }

        [Column("WKapi Acik Sure Alarmi")]
        public bool? WKapi_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi Zorlama Alarmi")]
        public bool? WKapi_Zorlama_Alarmi { get; set; }

        [Column("WKapi Acilma Alarmi")]
        public bool? WKapi_Acilma_Alarmi { get; set; }

        [Column("WKapi Harici Alarm Rolesi")]
        public int? WKapi_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi Panik Buton Alarmi")]
        public bool? WKapi_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi Itme Gecikmesi")]
        public int? WKapi_Itme_Gecikmesi { get; set; }

        [Column("WKapi User Count")]
        public int? WKapi_User_Count { get; set; }
    }
}
