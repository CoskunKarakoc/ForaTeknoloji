namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReaderSettings : IEntity
    {
        [Key]
        [Column("Kayit No")]
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

        [Column("WKapi1 Aktif")]
        public bool? WKapi1_Aktif { get; set; }

        [Column("WKapi1 Lift Aktif")]
        public bool? WKapi1_Lift_Aktif { get; set; }

        [Column("WKapi1 Role No")]
        public int? WKapi1_Role_No { get; set; }

        [Column("WKapi1 Adi")]
        [StringLength(50)]
        public string WKapi1_Adi { get; set; }

        [Column("WKapi1 Kapi Tipi")]
        public int? WKapi1_Kapi_Tipi { get; set; }

        [Column("WKapi1 WIGType")]
        public int? WKapi1_WIGType { get; set; }

        [Column("WKapi1 Lokal Bolge")]
        public int? WKapi1_Lokal_Bolge { get; set; }

        [Column("WKapi1 Gecis Modu")]
        public int? WKapi1_Gecis_Modu { get; set; }

        [Column("WKapi1 Alarm Modu")]
        public int? WKapi1_Alarm_Modu { get; set; }

        [Column("WKapi1 Yangin Modu")]
        public int? WKapi1_Yangin_Modu { get; set; }

        [Column("WKapi1 Pin Dogrulama")]
        public int? WKapi1_Pin_Dogrulama { get; set; }

        [Column("WKapi1 Ana Alarm Rolesi")]
        public bool? WKapi1_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi1 Sirali Gecis Ana Kapi")]
        public bool? WKapi1_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi1 Coklu Onay")]
        public bool? WKapi1_Coklu_Onay { get; set; }

        [Column("WKapi1 Acik Sure")]
        public int? WKapi1_Acik_Sure { get; set; }

        [Column("WKapi1 Acik Sure Alarmi")]
        public bool? WKapi1_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi1 Zorlama Alarmi")]
        public bool? WKapi1_Zorlama_Alarmi { get; set; }

        [Column("WKapi1 Acilma Alarmi")]
        public bool? WKapi1_Acilma_Alarmi { get; set; }

        [Column("WKapi1 Harici Alarm Rolesi")]
        public int? WKapi1_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi1 Panik Buton Alarmi")]
        public bool? WKapi1_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi1 Itme Gecikmesi")]
        public int? WKapi1_Itme_Gecikmesi { get; set; }

        [Column("WKapi1 User Count")]
        public int? WKapi1_User_Count { get; set; }

        [Column("WKapi2 Aktif")]
        public bool? WKapi2_Aktif { get; set; }

        [Column("WKapi2 Lift Aktif")]
        public bool? WKapi2_Lift_Aktif { get; set; }

        [Column("WKapi2 Adi")]
        [StringLength(50)]
        public string WKapi2_Adi { get; set; }

        [Column("WKapi2 Role No")]
        public int? WKapi2_Role_No { get; set; }

        [Column("WKapi2 Kapi Tipi")]
        public int? WKapi2_Kapi_Tipi { get; set; }

        [Column("WKapi2 WIGType")]
        public int? WKapi2_WIGType { get; set; }

        [Column("WKapi2 Lokal Bolge")]
        public int? WKapi2_Lokal_Bolge { get; set; }

        [Column("WKapi2 Gecis Modu")]
        public int? WKapi2_Gecis_Modu { get; set; }

        [Column("WKapi2 Alarm Modu")]
        public int? WKapi2_Alarm_Modu { get; set; }

        [Column("WKapi2 Yangin Modu")]
        public int? WKapi2_Yangin_Modu { get; set; }

        [Column("WKapi2 Pin Dogrulama")]
        public int? WKapi2_Pin_Dogrulama { get; set; }

        [Column("WKapi2 Ana Alarm Rolesi")]
        public bool? WKapi2_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi2 Sirali Gecis Ana Kapi")]
        public bool? WKapi2_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi2 Coklu Onay")]
        public bool? WKapi2_Coklu_Onay { get; set; }

        [Column("WKapi2 Acik Sure")]
        public int? WKapi2_Acik_Sure { get; set; }

        [Column("WKapi2 Acik Sure Alarmi")]
        public bool? WKapi2_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi2 Zorlama Alarmi")]
        public bool? WKapi2_Zorlama_Alarmi { get; set; }

        [Column("WKapi2 Acilma Alarmi")]
        public bool? WKapi2_Acilma_Alarmi { get; set; }

        [Column("WKapi2 Harici Alarm Rolesi")]
        public int? WKapi2_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi2 Panik Buton Alarmi")]
        public bool? WKapi2_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi2 Itme Gecikmesi")]
        public int? WKapi2_Itme_Gecikmesi { get; set; }

        [Column("WKapi2 User Count")]
        public int? WKapi2_User_Count { get; set; }

        [Column("WKapi3 Aktif")]
        public bool? WKapi3_Aktif { get; set; }

        [Column("WKapi3 Lift Aktif")]
        public bool? WKapi3_Lift_Aktif { get; set; }

        [Column("WKapi3 Adi")]
        [StringLength(50)]
        public string WKapi3_Adi { get; set; }

        [Column("WKapi3 Role No")]
        public int? WKapi3_Role_No { get; set; }

        [Column("WKapi3 Kapi Tipi")]
        public int? WKapi3_Kapi_Tipi { get; set; }

        [Column("WKapi3 WIGType")]
        public int? WKapi3_WIGType { get; set; }

        [Column("WKapi3 Lokal Bolge")]
        public int? WKapi3_Lokal_Bolge { get; set; }

        [Column("WKapi3 Gecis Modu")]
        public int? WKapi3_Gecis_Modu { get; set; }

        [Column("WKapi3 Alarm Modu")]
        public int? WKapi3_Alarm_Modu { get; set; }

        [Column("WKapi3 Yangin Modu")]
        public int? WKapi3_Yangin_Modu { get; set; }

        [Column("WKapi3 Pin Dogrulama")]
        public int? WKapi3_Pin_Dogrulama { get; set; }

        [Column("WKapi3 Ana Alarm Rolesi")]
        public bool? WKapi3_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi3 Sirali Gecis Ana Kapi")]
        public bool? WKapi3_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi3 Coklu Onay")]
        public bool? WKapi3_Coklu_Onay { get; set; }

        [Column("WKapi3 Acik Sure")]
        public int? WKapi3_Acik_Sure { get; set; }

        [Column("WKapi3 Acik Sure Alarmi")]
        public bool? WKapi3_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi3 Zorlama Alarmi")]
        public bool? WKapi3_Zorlama_Alarmi { get; set; }

        [Column("WKapi3 Acilma Alarmi")]
        public bool? WKapi3_Acilma_Alarmi { get; set; }

        [Column("WKapi3 Harici Alarm Rolesi")]
        public int? WKapi3_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi3 Panik Buton Alarmi")]
        public bool? WKapi3_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi3 Itme Gecikmesi")]
        public int? WKapi3_Itme_Gecikmesi { get; set; }

        [Column("WKapi3 User Count")]
        public int? WKapi3_User_Count { get; set; }

        [Column("WKapi4 Aktif")]
        public bool? WKapi4_Aktif { get; set; }

        [Column("WKapi4 Lift Aktif")]
        public bool? WKapi4_Lift_Aktif { get; set; }

        [Column("WKapi4 Adi")]
        [StringLength(50)]
        public string WKapi4_Adi { get; set; }

        [Column("WKapi4 Role No")]
        public int? WKapi4_Role_No { get; set; }

        [Column("WKapi4 Kapi Tipi")]
        public int? WKapi4_Kapi_Tipi { get; set; }

        [Column("WKapi4 WIGType")]
        public int? WKapi4_WIGType { get; set; }

        [Column("WKapi4 Lokal Bolge")]
        public int? WKapi4_Lokal_Bolge { get; set; }

        [Column("WKapi4 Gecis Modu")]
        public int? WKapi4_Gecis_Modu { get; set; }

        [Column("WKapi4 Alarm Modu")]
        public int? WKapi4_Alarm_Modu { get; set; }

        [Column("WKapi4 Yangin Modu")]
        public int? WKapi4_Yangin_Modu { get; set; }

        [Column("WKapi4 Pin Dogrulama")]
        public int? WKapi4_Pin_Dogrulama { get; set; }

        [Column("WKapi4 Ana Alarm Rolesi")]
        public bool? WKapi4_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi4 Sirali Gecis Ana Kapi")]
        public bool? WKapi4_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi4 Coklu Onay")]
        public bool? WKapi4_Coklu_Onay { get; set; }

        [Column("WKapi4 Acik Sure")]
        public int? WKapi4_Acik_Sure { get; set; }

        [Column("WKapi4 Acik Sure Alarmi")]
        public bool? WKapi4_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi4 Zorlama Alarmi")]
        public bool? WKapi4_Zorlama_Alarmi { get; set; }

        [Column("WKapi4 Acilma Alarmi")]
        public bool? WKapi4_Acilma_Alarmi { get; set; }

        [Column("WKapi4 Harici Alarm Rolesi")]
        public int? WKapi4_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi4 Panik Buton Alarmi")]
        public bool? WKapi4_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi4 Itme Gecikmesi")]
        public int? WKapi4_Itme_Gecikmesi { get; set; }

        [Column("WKapi4 User Count")]
        public int? WKapi4_User_Count { get; set; }

        [Column("WKapi5 Aktif")]
        public bool? WKapi5_Aktif { get; set; }

        [Column("WKapi5 Lift Aktif")]
        public bool? WKapi5_Lift_Aktif { get; set; }

        [Column("WKapi5 Adi")]
        [StringLength(50)]
        public string WKapi5_Adi { get; set; }

        [Column("WKapi5 Role No")]
        public int? WKapi5_Role_No { get; set; }

        [Column("WKapi5 Kapi Tipi")]
        public int? WKapi5_Kapi_Tipi { get; set; }

        [Column("WKapi5 WIGType")]
        public int? WKapi5_WIGType { get; set; }

        [Column("WKapi5 Lokal Bolge")]
        public int? WKapi5_Lokal_Bolge { get; set; }

        [Column("WKapi5 Gecis Modu")]
        public int? WKapi5_Gecis_Modu { get; set; }

        [Column("WKapi5 Alarm Modu")]
        public int? WKapi5_Alarm_Modu { get; set; }

        [Column("WKapi5 Yangin Modu")]
        public int? WKapi5_Yangin_Modu { get; set; }

        [Column("WKapi5 Pin Dogrulama")]
        public int? WKapi5_Pin_Dogrulama { get; set; }

        [Column("WKapi5 Ana Alarm Rolesi")]
        public bool? WKapi5_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi5 Sirali Gecis Ana Kapi")]
        public bool? WKapi5_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi5 Coklu Onay")]
        public bool? WKapi5_Coklu_Onay { get; set; }

        [Column("WKapi5 Acik Sure")]
        public int? WKapi5_Acik_Sure { get; set; }

        [Column("WKapi5 Acik Sure Alarmi")]
        public bool? WKapi5_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi5 Zorlama Alarmi")]
        public bool? WKapi5_Zorlama_Alarmi { get; set; }

        [Column("WKapi5 Acilma Alarmi")]
        public bool? WKapi5_Acilma_Alarmi { get; set; }

        [Column("WKapi5 Harici Alarm Rolesi")]
        public int? WKapi5_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi5 Panik Buton Alarmi")]
        public bool? WKapi5_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi5 Itme Gecikmesi")]
        public int? WKapi5_Itme_Gecikmesi { get; set; }

        [Column("WKapi5 User Count")]
        public int? WKapi5_User_Count { get; set; }

        [Column("WKapi6 Aktif")]
        public bool? WKapi6_Aktif { get; set; }

        [Column("WKapi6 Lift Aktif")]
        public bool? WKapi6_Lift_Aktif { get; set; }

        [Column("WKapi6 Adi")]
        [StringLength(50)]
        public string WKapi6_Adi { get; set; }

        [Column("WKapi6 Role No")]
        public int? WKapi6_Role_No { get; set; }

        [Column("WKapi6 Kapi Tipi")]
        public int? WKapi6_Kapi_Tipi { get; set; }

        [Column("WKapi6 WIGType")]
        public int? WKapi6_WIGType { get; set; }

        [Column("WKapi6 Lokal Bolge")]
        public int? WKapi6_Lokal_Bolge { get; set; }

        [Column("WKapi6 Gecis Modu")]
        public int? WKapi6_Gecis_Modu { get; set; }

        [Column("WKapi6 Alarm Modu")]
        public int? WKapi6_Alarm_Modu { get; set; }

        [Column("WKapi6 Yangin Modu")]
        public int? WKapi6_Yangin_Modu { get; set; }

        [Column("WKapi6 Pin Dogrulama")]
        public int? WKapi6_Pin_Dogrulama { get; set; }

        [Column("WKapi6 Ana Alarm Rolesi")]
        public bool? WKapi6_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi6 Sirali Gecis Ana Kapi")]
        public bool? WKapi6_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi6 Coklu Onay")]
        public bool? WKapi6_Coklu_Onay { get; set; }

        [Column("WKapi6 Acik Sure")]
        public int? WKapi6_Acik_Sure { get; set; }

        [Column("WKapi6 Acik Sure Alarmi")]
        public bool? WKapi6_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi6 Zorlama Alarmi")]
        public bool? WKapi6_Zorlama_Alarmi { get; set; }

        [Column("WKapi6 Acilma Alarmi")]
        public bool? WKapi6_Acilma_Alarmi { get; set; }

        [Column("WKapi6 Harici Alarm Rolesi")]
        public int? WKapi6_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi6 Panik Buton Alarmi")]
        public bool? WKapi6_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi6 Itme Gecikmesi")]
        public int? WKapi6_Itme_Gecikmesi { get; set; }

        [Column("WKapi6 User Count")]
        public int? WKapi6_User_Count { get; set; }

        [Column("WKapi7 Aktif")]
        public bool? WKapi7_Aktif { get; set; }

        [Column("WKapi7 Lift Aktif")]
        public bool? WKapi7_Lift_Aktif { get; set; }

        [Column("WKapi7 Adi")]
        [StringLength(50)]
        public string WKapi7_Adi { get; set; }

        [Column("WKapi7 Role No")]
        public int? WKapi7_Role_No { get; set; }

        [Column("WKapi7 Kapi Tipi")]
        public int? WKapi7_Kapi_Tipi { get; set; }

        [Column("WKapi7 WIGType")]
        public int? WKapi7_WIGType { get; set; }

        [Column("WKapi7 Lokal Bolge")]
        public int? WKapi7_Lokal_Bolge { get; set; }

        [Column("WKapi7 Gecis Modu")]
        public int? WKapi7_Gecis_Modu { get; set; }

        [Column("WKapi7 Alarm Modu")]
        public int? WKapi7_Alarm_Modu { get; set; }

        [Column("WKapi7 Yangin Modu")]
        public int? WKapi7_Yangin_Modu { get; set; }

        [Column("WKapi7 Pin Dogrulama")]
        public int? WKapi7_Pin_Dogrulama { get; set; }

        [Column("WKapi7 Ana Alarm Rolesi")]
        public bool? WKapi7_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi7 Sirali Gecis Ana Kapi")]
        public bool? WKapi7_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi7 Coklu Onay")]
        public bool? WKapi7_Coklu_Onay { get; set; }

        [Column("WKapi7 Acik Sure")]
        public int? WKapi7_Acik_Sure { get; set; }

        [Column("WKapi7 Acik Sure Alarmi")]
        public bool? WKapi7_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi7 Zorlama Alarmi")]
        public bool? WKapi7_Zorlama_Alarmi { get; set; }

        [Column("WKapi7 Acilma Alarmi")]
        public bool? WKapi7_Acilma_Alarmi { get; set; }

        [Column("WKapi7 Harici Alarm Rolesi")]
        public int? WKapi7_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi7 Panik Buton Alarmi")]
        public bool? WKapi7_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi7 Itme Gecikmesi")]
        public int? WKapi7_Itme_Gecikmesi { get; set; }

        [Column("WKapi7 User Count")]
        public int? WKapi7_User_Count { get; set; }

        [Column("WKapi8 Aktif")]
        public bool? WKapi8_Aktif { get; set; }

        [Column("WKapi8 Lift Aktif")]
        public bool? WKapi8_Lift_Aktif { get; set; }

        [Column("WKapi8 Adi")]
        [StringLength(50)]
        public string WKapi8_Adi { get; set; }

        [Column("WKapi8 Role No")]
        public int? WKapi8_Role_No { get; set; }

        [Column("WKapi8 Kapi Tipi")]
        public int? WKapi8_Kapi_Tipi { get; set; }

        [Column("WKapi8 WIGType")]
        public int? WKapi8_WIGType { get; set; }

        [Column("WKapi8 Lokal Bolge")]
        public int? WKapi8_Lokal_Bolge { get; set; }

        [Column("WKapi8 Gecis Modu")]
        public int? WKapi8_Gecis_Modu { get; set; }

        [Column("WKapi8 Alarm Modu")]
        public int? WKapi8_Alarm_Modu { get; set; }

        [Column("WKapi8 Yangin Modu")]
        public int? WKapi8_Yangin_Modu { get; set; }

        [Column("WKapi8 Pin Dogrulama")]
        public int? WKapi8_Pin_Dogrulama { get; set; }

        [Column("WKapi8 Ana Alarm Rolesi")]
        public bool? WKapi8_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi8 Sirali Gecis Ana Kapi")]
        public bool? WKapi8_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi8 Coklu Onay")]
        public bool? WKapi8_Coklu_Onay { get; set; }

        [Column("WKapi8 Acik Sure")]
        public int? WKapi8_Acik_Sure { get; set; }

        [Column("WKapi8 Acik Sure Alarmi")]
        public bool? WKapi8_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi8 Zorlama Alarmi")]
        public bool? WKapi8_Zorlama_Alarmi { get; set; }

        [Column("WKapi8 Acilma Alarmi")]
        public bool? WKapi8_Acilma_Alarmi { get; set; }

        [Column("WKapi8 Harici Alarm Rolesi")]
        public int? WKapi8_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi8 Panik Buton Alarmi")]
        public bool? WKapi8_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi8 Itme Gecikmesi")]
        public int? WKapi8_Itme_Gecikmesi { get; set; }

        [Column("WKapi8 User Count")]
        public int? WKapi8_User_Count { get; set; }

        [Column("WKapi9 Aktif")]
        public bool? WKapi9_Aktif { get; set; }

        [Column("WKapi9 Lift Aktif")]
        public bool? WKapi9_Lift_Aktif { get; set; }

        [Column("WKapi9 Adi")]
        [StringLength(50)]
        public string WKapi9_Adi { get; set; }

        [Column("WKapi9 Role No")]
        public int? WKapi9_Role_No { get; set; }

        [Column("WKapi9 Kapi Tipi")]
        public int? WKapi9_Kapi_Tipi { get; set; }

        [Column("WKapi9 WIGType")]
        public int? WKapi9_WIGType { get; set; }

        [Column("WKapi9 Lokal Bolge")]
        public int? WKapi9_Lokal_Bolge { get; set; }

        [Column("WKapi9 Gecis Modu")]
        public int? WKapi9_Gecis_Modu { get; set; }

        [Column("WKapi9 Alarm Modu")]
        public int? WKapi9_Alarm_Modu { get; set; }

        [Column("WKapi9 Yangin Modu")]
        public int? WKapi9_Yangin_Modu { get; set; }

        [Column("WKapi9 Pin Dogrulama")]
        public int? WKapi9_Pin_Dogrulama { get; set; }

        [Column("WKapi9 Ana Alarm Rolesi")]
        public bool? WKapi9_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi9 Sirali Gecis Ana Kapi")]
        public bool? WKapi9_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi9 Coklu Onay")]
        public bool? WKapi9_Coklu_Onay { get; set; }

        [Column("WKapi9 Acik Sure")]
        public int? WKapi9_Acik_Sure { get; set; }

        [Column("WKapi9 Acik Sure Alarmi")]
        public bool? WKapi9_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi9 Zorlama Alarmi")]
        public bool? WKapi9_Zorlama_Alarmi { get; set; }

        [Column("WKapi9 Acilma Alarmi")]
        public bool? WKapi9_Acilma_Alarmi { get; set; }

        [Column("WKapi9 Harici Alarm Rolesi")]
        public int? WKapi9_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi9 Panik Buton Alarmi")]
        public bool? WKapi9_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi9 Itme Gecikmesi")]
        public int? WKapi9_Itme_Gecikmesi { get; set; }

        [Column("WKapi9 User Count")]
        public int? WKapi9_User_Count { get; set; }

        [Column("WKapi10 Aktif")]
        public bool? WKapi10_Aktif { get; set; }

        [Column("WKapi10 Lift Aktif")]
        public bool? WKapi10_Lift_Aktif { get; set; }

        [Column("WKapi10 Adi")]
        [StringLength(50)]
        public string WKapi10_Adi { get; set; }

        [Column("WKapi10 Role No")]
        public int? WKapi10_Role_No { get; set; }

        [Column("WKapi10 Kapi Tipi")]
        public int? WKapi10_Kapi_Tipi { get; set; }

        [Column("WKapi10 WIGType")]
        public int? WKapi10_WIGType { get; set; }

        [Column("WKapi10 Lokal Bolge")]
        public int? WKapi10_Lokal_Bolge { get; set; }

        [Column("WKapi10 Gecis Modu")]
        public int? WKapi10_Gecis_Modu { get; set; }

        [Column("WKapi10 Alarm Modu")]
        public int? WKapi10_Alarm_Modu { get; set; }

        [Column("WKapi10 Yangin Modu")]
        public int? WKapi10_Yangin_Modu { get; set; }

        [Column("WKapi10 Pin Dogrulama")]
        public int? WKapi10_Pin_Dogrulama { get; set; }

        [Column("WKapi10 Ana Alarm Rolesi")]
        public bool? WKapi10_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi10 Sirali Gecis Ana Kapi")]
        public bool? WKapi10_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi10 Coklu Onay")]
        public bool? WKapi10_Coklu_Onay { get; set; }

        [Column("WKapi10 Acik Sure")]
        public int? WKapi10_Acik_Sure { get; set; }

        [Column("WKapi10 Acik Sure Alarmi")]
        public bool? WKapi10_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi10 Zorlama Alarmi")]
        public bool? WKapi10_Zorlama_Alarmi { get; set; }

        [Column("WKapi10 Acilma Alarmi")]
        public bool? WKapi10_Acilma_Alarmi { get; set; }

        [Column("WKapi10 Harici Alarm Rolesi")]
        public int? WKapi10_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi10 Panik Buton Alarmi")]
        public bool? WKapi10_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi10 Itme Gecikmesi")]
        public int? WKapi10_Itme_Gecikmesi { get; set; }

        [Column("WKapi10 User Count")]
        public int? WKapi10_User_Count { get; set; }

        [Column("WKapi11 Aktif")]
        public bool? WKapi11_Aktif { get; set; }

        [Column("WKapi11 Lift Aktif")]
        public bool? WKapi11_Lift_Aktif { get; set; }

        [Column("WKapi11 Adi")]
        [StringLength(50)]
        public string WKapi11_Adi { get; set; }

        [Column("WKapi11 Role No")]
        public int? WKapi11_Role_No { get; set; }

        [Column("WKapi11 Kapi Tipi")]
        public int? WKapi11_Kapi_Tipi { get; set; }

        [Column("WKapi11 WIGType")]
        public int? WKapi11_WIGType { get; set; }

        [Column("WKapi11 Lokal Bolge")]
        public int? WKapi11_Lokal_Bolge { get; set; }

        [Column("WKapi11 Gecis Modu")]
        public int? WKapi11_Gecis_Modu { get; set; }

        [Column("WKapi11 Alarm Modu")]
        public int? WKapi11_Alarm_Modu { get; set; }

        [Column("WKapi11 Yangin Modu")]
        public int? WKapi11_Yangin_Modu { get; set; }

        [Column("WKapi11 Pin Dogrulama")]
        public int? WKapi11_Pin_Dogrulama { get; set; }

        [Column("WKapi11 Ana Alarm Rolesi")]
        public bool? WKapi11_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi11 Sirali Gecis Ana Kapi")]
        public bool? WKapi11_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi11 Coklu Onay")]
        public bool? WKapi11_Coklu_Onay { get; set; }

        [Column("WKapi11 Acik Sure")]
        public int? WKapi11_Acik_Sure { get; set; }

        [Column("WKapi11 Acik Sure Alarmi")]
        public bool? WKapi11_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi11 Zorlama Alarmi")]
        public bool? WKapi11_Zorlama_Alarmi { get; set; }

        [Column("WKapi11 Acilma Alarmi")]
        public bool? WKapi11_Acilma_Alarmi { get; set; }

        [Column("WKapi11 Harici Alarm Rolesi")]
        public int? WKapi11_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi11 Panik Buton Alarmi")]
        public bool? WKapi11_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi11 Itme Gecikmesi")]
        public int? WKapi11_Itme_Gecikmesi { get; set; }

        [Column("WKapi11 User Count")]
        public int? WKapi11_User_Count { get; set; }

        [Column("WKapi12 Aktif")]
        public bool? WKapi12_Aktif { get; set; }

        [Column("WKapi12 Lift Aktif")]
        public bool? WKapi12_Lift_Aktif { get; set; }

        [Column("WKapi12 Adi")]
        [StringLength(50)]
        public string WKapi12_Adi { get; set; }

        [Column("WKapi12 Role No")]
        public int? WKapi12_Role_No { get; set; }

        [Column("WKapi12 Kapi Tipi")]
        public int? WKapi12_Kapi_Tipi { get; set; }

        [Column("WKapi12 WIGType")]
        public int? WKapi12_WIGType { get; set; }

        [Column("WKapi12 Lokal Bolge")]
        public int? WKapi12_Lokal_Bolge { get; set; }

        [Column("WKapi12 Gecis Modu")]
        public int? WKapi12_Gecis_Modu { get; set; }

        [Column("WKapi12 Alarm Modu")]
        public int? WKapi12_Alarm_Modu { get; set; }

        [Column("WKapi12 Yangin Modu")]
        public int? WKapi12_Yangin_Modu { get; set; }

        [Column("WKapi12 Pin Dogrulama")]
        public int? WKapi12_Pin_Dogrulama { get; set; }

        [Column("WKapi12 Ana Alarm Rolesi")]
        public bool? WKapi12_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi12 Sirali Gecis Ana Kapi")]
        public bool? WKapi12_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi12 Coklu Onay")]
        public bool? WKapi12_Coklu_Onay { get; set; }

        [Column("WKapi12 Acik Sure")]
        public int? WKapi12_Acik_Sure { get; set; }

        [Column("WKapi12 Acik Sure Alarmi")]
        public bool? WKapi12_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi12 Zorlama Alarmi")]
        public bool? WKapi12_Zorlama_Alarmi { get; set; }

        [Column("WKapi12 Acilma Alarmi")]
        public bool? WKapi12_Acilma_Alarmi { get; set; }

        [Column("WKapi12 Harici Alarm Rolesi")]
        public int? WKapi12_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi12 Panik Buton Alarmi")]
        public bool? WKapi12_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi12 Itme Gecikmesi")]
        public int? WKapi12_Itme_Gecikmesi { get; set; }

        [Column("WKapi12 User Count")]
        public int? WKapi12_User_Count { get; set; }

        [Column("WKapi13 Aktif")]
        public bool? WKapi13_Aktif { get; set; }

        [Column("WKapi13 Lift Aktif")]
        public bool? WKapi13_Lift_Aktif { get; set; }

        [Column("WKapi13 Adi")]
        [StringLength(50)]
        public string WKapi13_Adi { get; set; }

        [Column("WKapi13 Role No")]
        public int? WKapi13_Role_No { get; set; }

        [Column("WKapi13 Kapi Tipi")]
        public int? WKapi13_Kapi_Tipi { get; set; }

        [Column("WKapi13 WIGType")]
        public int? WKapi13_WIGType { get; set; }

        [Column("WKapi13 Lokal Bolge")]
        public int? WKapi13_Lokal_Bolge { get; set; }

        [Column("WKapi13 Gecis Modu")]
        public int? WKapi13_Gecis_Modu { get; set; }

        [Column("WKapi13 Alarm Modu")]
        public int? WKapi13_Alarm_Modu { get; set; }

        [Column("WKapi13 Yangin Modu")]
        public int? WKapi13_Yangin_Modu { get; set; }

        [Column("WKapi13 Pin Dogrulama")]
        public int? WKapi13_Pin_Dogrulama { get; set; }

        [Column("WKapi13 Ana Alarm Rolesi")]
        public bool? WKapi13_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi13 Sirali Gecis Ana Kapi")]
        public bool? WKapi13_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi13 Coklu Onay")]
        public bool? WKapi13_Coklu_Onay { get; set; }

        [Column("WKapi13 Acik Sure")]
        public int? WKapi13_Acik_Sure { get; set; }

        [Column("WKapi13 Acik Sure Alarmi")]
        public bool? WKapi13_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi13 Zorlama Alarmi")]
        public bool? WKapi13_Zorlama_Alarmi { get; set; }

        [Column("WKapi13 Acilma Alarmi")]
        public bool? WKapi13_Acilma_Alarmi { get; set; }

        [Column("WKapi13 Harici Alarm Rolesi")]
        public int? WKapi13_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi13 Panik Buton Alarmi")]
        public bool? WKapi13_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi13 Itme Gecikmesi")]
        public int? WKapi13_Itme_Gecikmesi { get; set; }

        [Column("WKapi13 User Count")]
        public int? WKapi13_User_Count { get; set; }

        [Column("WKapi14 Aktif")]
        public bool? WKapi14_Aktif { get; set; }

        [Column("WKapi14 Lift Aktif")]
        public bool? WKapi14_Lift_Aktif { get; set; }

        [Column("WKapi14 Adi")]
        [StringLength(50)]
        public string WKapi14_Adi { get; set; }

        [Column("WKapi14 Role No")]
        public int? WKapi14_Role_No { get; set; }

        [Column("WKapi14 Kapi Tipi")]
        public int? WKapi14_Kapi_Tipi { get; set; }

        [Column("WKapi14 WIGType")]
        public int? WKapi14_WIGType { get; set; }

        [Column("WKapi14 Lokal Bolge")]
        public int? WKapi14_Lokal_Bolge { get; set; }

        [Column("WKapi14 Gecis Modu")]
        public int? WKapi14_Gecis_Modu { get; set; }

        [Column("WKapi14 Alarm Modu")]
        public int? WKapi14_Alarm_Modu { get; set; }

        [Column("WKapi14 Yangin Modu")]
        public int? WKapi14_Yangin_Modu { get; set; }

        [Column("WKapi14 Pin Dogrulama")]
        public int? WKapi14_Pin_Dogrulama { get; set; }

        [Column("WKapi14 Ana Alarm Rolesi")]
        public bool? WKapi14_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi14 Sirali Gecis Ana Kapi")]
        public bool? WKapi14_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi14 Coklu Onay")]
        public bool? WKapi14_Coklu_Onay { get; set; }

        [Column("WKapi14 Acik Sure")]
        public int? WKapi14_Acik_Sure { get; set; }

        [Column("WKapi14 Acik Sure Alarmi")]
        public bool? WKapi14_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi14 Zorlama Alarmi")]
        public bool? WKapi14_Zorlama_Alarmi { get; set; }

        [Column("WKapi14 Acilma Alarmi")]
        public bool? WKapi14_Acilma_Alarmi { get; set; }

        [Column("WKapi14 Harici Alarm Rolesi")]
        public int? WKapi14_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi14 Panik Buton Alarmi")]
        public bool? WKapi14_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi14 Itme Gecikmesi")]
        public int? WKapi14_Itme_Gecikmesi { get; set; }

        [Column("WKapi14 User Count")]
        public int? WKapi14_User_Count { get; set; }

        [Column("WKapi15 Aktif")]
        public bool? WKapi15_Aktif { get; set; }

        [Column("WKapi15 Lift Aktif")]
        public bool? WKapi15_Lift_Aktif { get; set; }

        [Column("WKapi15 Adi")]
        [StringLength(50)]
        public string WKapi15_Adi { get; set; }

        [Column("WKapi15 Role No")]
        public int? WKapi15_Role_No { get; set; }

        [Column("WKapi15 Kapi Tipi")]
        public int? WKapi15_Kapi_Tipi { get; set; }

        [Column("WKapi15 WIGType")]
        public int? WKapi15_WIGType { get; set; }

        [Column("WKapi15 Lokal Bolge")]
        public int? WKapi15_Lokal_Bolge { get; set; }

        [Column("WKapi15 Gecis Modu")]
        public int? WKapi15_Gecis_Modu { get; set; }

        [Column("WKapi15 Alarm Modu")]
        public int? WKapi15_Alarm_Modu { get; set; }

        [Column("WKapi15 Yangin Modu")]
        public int? WKapi15_Yangin_Modu { get; set; }

        [Column("WKapi15 Pin Dogrulama")]
        public int? WKapi15_Pin_Dogrulama { get; set; }

        [Column("WKapi15 Ana Alarm Rolesi")]
        public bool? WKapi15_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi15 Sirali Gecis Ana Kapi")]
        public bool? WKapi15_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi15 Coklu Onay")]
        public bool? WKapi15_Coklu_Onay { get; set; }

        [Column("WKapi15 Acik Sure")]
        public int? WKapi15_Acik_Sure { get; set; }

        [Column("WKapi15 Acik Sure Alarmi")]
        public bool? WKapi15_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi15 Zorlama Alarmi")]
        public bool? WKapi15_Zorlama_Alarmi { get; set; }

        [Column("WKapi15 Acilma Alarmi")]
        public bool? WKapi15_Acilma_Alarmi { get; set; }

        [Column("WKapi15 Harici Alarm Rolesi")]
        public int? WKapi15_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi15 Panik Buton Alarmi")]
        public bool? WKapi15_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi15 Itme Gecikmesi")]
        public int? WKapi15_Itme_Gecikmesi { get; set; }

        [Column("WKapi15 User Count")]
        public int? WKapi15_User_Count { get; set; }

        [Column("WKapi16 Aktif")]
        public bool? WKapi16_Aktif { get; set; }

        [Column("WKapi16 Lift Aktif")]
        public bool? WKapi16_Lift_Aktif { get; set; }

        [Column("WKapi16 Adi")]
        [StringLength(50)]
        public string WKapi16_Adi { get; set; }

        [Column("WKapi16 Role No")]
        public int? WKapi16_Role_No { get; set; }

        [Column("WKapi16 Kapi Tipi")]
        public int? WKapi16_Kapi_Tipi { get; set; }

        [Column("WKapi16 WIGType")]
        public int? WKapi16_WIGType { get; set; }

        [Column("WKapi16 Lokal Bolge")]
        public int? WKapi16_Lokal_Bolge { get; set; }

        [Column("WKapi16 Gecis Modu")]
        public int? WKapi16_Gecis_Modu { get; set; }

        [Column("WKapi16 Alarm Modu")]
        public int? WKapi16_Alarm_Modu { get; set; }

        [Column("WKapi16 Yangin Modu")]
        public int? WKapi16_Yangin_Modu { get; set; }

        [Column("WKapi16 Pin Dogrulama")]
        public int? WKapi16_Pin_Dogrulama { get; set; }

        [Column("WKapi16 Ana Alarm Rolesi")]
        public bool? WKapi16_Ana_Alarm_Rolesi { get; set; }

        [Column("WKapi16 Sirali Gecis Ana Kapi")]
        public bool? WKapi16_Sirali_Gecis_Ana_Kapi { get; set; }

        [Column("WKapi16 Coklu Onay")]
        public bool? WKapi16_Coklu_Onay { get; set; }

        [Column("WKapi16 Acik Sure")]
        public int? WKapi16_Acik_Sure { get; set; }

        [Column("WKapi16 Acik Sure Alarmi")]
        public bool? WKapi16_Acik_Sure_Alarmi { get; set; }

        [Column("WKapi16 Zorlama Alarmi")]
        public bool? WKapi16_Zorlama_Alarmi { get; set; }

        [Column("WKapi16 Acilma Alarmi")]
        public bool? WKapi16_Acilma_Alarmi { get; set; }

        [Column("WKapi16 Harici Alarm Rolesi")]
        public int? WKapi16_Harici_Alarm_Rolesi { get; set; }

        [Column("WKapi16 Panik Buton Alarmi")]
        public bool? WKapi16_Panik_Buton_Alarmi { get; set; }

        [Column("WKapi16 Itme Gecikmesi")]
        public int? WKapi16_Itme_Gecikmesi { get; set; }

        [Column("WKapi16 User Count")]
        public int? WKapi16_User_Count { get; set; }
    }
}
