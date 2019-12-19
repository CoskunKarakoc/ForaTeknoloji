namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PanelSettings : IEntity
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

        [Column("Panel Model")]
        public int? Panel_Model { get; set; }

        [Column("Panel Expansion")]
        public int? Panel_Expansion { get; set; }

        [Column("Panel Expansion 2")]
        public int? Panel_Expansion_2 { get; set; }

        [Column("Kontrol Modu")]
        public int? Kontrol_Modu { get; set; }

        [Column("Lokal APB")]
        public int? Lokal_APB { get; set; }

        [Column("Lokal APB1")]
        public bool? Lokal_APB1 { get; set; }

        [Column("Lokal APB2")]
        public bool? Lokal_APB2 { get; set; }

        [Column("Lokal APB3")]
        public bool? Lokal_APB3 { get; set; }

        [Column("Lokal APB4")]
        public bool? Lokal_APB4 { get; set; }

        [Column("Lokal APB5")]
        public bool? Lokal_APB5 { get; set; }

        [Column("Lokal APB6")]
        public bool? Lokal_APB6 { get; set; }

        [Column("Lokal APB7")]
        public bool? Lokal_APB7 { get; set; }

        [Column("Lokal APB8")]
        public bool? Lokal_APB8 { get; set; }

        [Column("Global APB")]
        public bool? Global_APB { get; set; }

        [Column("Global Bolge No")]
        public int? Global_Bolge_No { get; set; }

        [Column("Global Capacity Control")]
        public bool? Global_Capacity_Control { get; set; }

        [Column("Global Access Count Control")]
        public bool? Global_Access_Count_Control { get; set; }

        [Column("Global MaxIn Count Control")]
        public bool? Global_MaxIn_Count_Control { get; set; }

        [Column("Global Sequental Access Control")]
        public bool? Global_Sequental_Access_Control { get; set; }

        [Column("Panel Same Tag Block")]
        public int? Panel_Same_Tag_Block { get; set; }

        [Column("Panel Same Tag Block Type")]
        public int? Panel_Same_Tag_Block_Type { get; set; }

        [Column("Panel Same Tag Block HourMinSec")]
        public int? Panel_Same_Tag_Block_HourMinSec { get; set; }

        [Column("Status Data Update")]
        public bool? Status_Data_Update { get; set; }

        [Column("Status Data Update Type")]
        public int? Status_Data_Update_Type { get; set; }

        [Column("Status Data Update Time")]
        public int? Status_Data_Update_Time { get; set; }

        [Column("Panel M1 Role")]
        public int? Panel_M1_Role { get; set; }

        [Column("Panel M2 Role")]
        public int? Panel_M2_Role { get; set; }

        [Column("Panel M3 Role")]
        public int? Panel_M3_Role { get; set; }

        [Column("Panel M4 Role")]
        public int? Panel_M4_Role { get; set; }

        [Column("Panel M5 Role")]
        public int? Panel_M5_Role { get; set; }

        [Column("Panel M6 Role")]
        public int? Panel_M6_Role { get; set; }

        [Column("Panel M7 Role")]
        public int? Panel_M7_Role { get; set; }

        [Column("Panel M8 Role")]
        public int? Panel_M8_Role { get; set; }

        [Column("Panel Alarm Role")]
        public int? Panel_Alarm_Role { get; set; }

        [Column("Panel Alarm Mode Role Ok")]
        public bool? Panel_Alarm_Mode_Role_Ok { get; set; }

        [Column("Panel Alarm Mode")]
        public bool? Panel_Alarm_Mode { get; set; }

        [Column("Panel Fire Mode Role Ok")]
        public bool? Panel_Fire_Mode_Role_Ok { get; set; }

        [Column("Panel Fire Mode")]
        public bool? Panel_Fire_Mode { get; set; }

        [Column("Panel Door Alarm Role Ok")]
        public bool? Panel_Door_Alarm_Role_Ok { get; set; }

        [Column("Panel Alarm Broadcast Ok")]
        public bool? Panel_Alarm_Broadcast_Ok { get; set; }

        [Column("Panel Fire Broadcast Ok")]
        public bool? Panel_Fire_Broadcast_Ok { get; set; }

        [Column("Panel Door Alarm Broadcast Ok")]
        public bool? Panel_Door_Alarm_Broadcast_Ok { get; set; }

        [Column("Panel Global Bolge1")]
        public int? Panel_Global_Bolge1 { get; set; }

        [Column("Panel Global Bolge2")]
        public int? Panel_Global_Bolge2 { get; set; }

        [Column("Panel Global Bolge3")]
        public int? Panel_Global_Bolge3 { get; set; }

        [Column("Panel Global Bolge4")]
        public int? Panel_Global_Bolge4 { get; set; }

        [Column("Panel Global Bolge5")]
        public int? Panel_Global_Bolge5 { get; set; }

        [Column("Panel Global Bolge6")]
        public int? Panel_Global_Bolge6 { get; set; }

        [Column("Panel Global Bolge7")]
        public int? Panel_Global_Bolge7 { get; set; }

        [Column("Panel Global Bolge8")]
        public int? Panel_Global_Bolge8 { get; set; }

        [Column("Panel Local Capacity1")]
        public bool? Panel_Local_Capacity1 { get; set; }

        [Column("Panel Local Capacity Clear1")]
        public bool? Panel_Local_Capacity_Clear1 { get; set; }

        [Column("Panel Local Capacity Value1")]
        public int? Panel_Local_Capacity_Value1 { get; set; }

        [Column("Panel Local Capacity2")]
        public bool? Panel_Local_Capacity2 { get; set; }

        [Column("Panel Local Capacity Clear2")]
        public bool? Panel_Local_Capacity_Clear2 { get; set; }

        [Column("Panel Local Capacity Value2")]
        public int? Panel_Local_Capacity_Value2 { get; set; }

        [Column("Panel Local Capacity3")]
        public bool? Panel_Local_Capacity3 { get; set; }

        [Column("Panel Local Capacity Clear3")]
        public bool? Panel_Local_Capacity_Clear3 { get; set; }

        [Column("Panel Local Capacity Value3")]
        public int? Panel_Local_Capacity_Value3 { get; set; }

        [Column("Panel Local Capacity4")]
        public bool? Panel_Local_Capacity4 { get; set; }

        [Column("Panel Local Capacity Clear4")]
        public bool? Panel_Local_Capacity_Clear4 { get; set; }

        [Column("Panel Local Capacity Value4")]
        public int? Panel_Local_Capacity_Value4 { get; set; }

        [Column("Panel Local Capacity5")]
        public bool? Panel_Local_Capacity5 { get; set; }

        [Column("Panel Local Capacity Clear5")]
        public bool? Panel_Local_Capacity_Clear5 { get; set; }

        [Column("Panel Local Capacity Value5")]
        public int? Panel_Local_Capacity_Value5 { get; set; }

        [Column("Panel Local Capacity6")]
        public bool? Panel_Local_Capacity6 { get; set; }

        [Column("Panel Local Capacity Clear6")]
        public bool? Panel_Local_Capacity_Clear6 { get; set; }

        [Column("Panel Local Capacity Value6")]
        public int? Panel_Local_Capacity_Value6 { get; set; }

        [Column("Panel Local Capacity7")]
        public bool? Panel_Local_Capacity7 { get; set; }

        [Column("Panel Local Capacity Clear7")]
        public bool? Panel_Local_Capacity_Clear7 { get; set; }

        [Column("Panel Local Capacity Value7")]
        public int? Panel_Local_Capacity_Value7 { get; set; }

        [Column("Panel Local Capacity8")]
        public bool? Panel_Local_Capacity8 { get; set; }

        [Column("Panel Local Capacity Clear8")]
        public bool? Panel_Local_Capacity_Clear8 { get; set; }

        [Column("Panel Local Capacity Value8")]
        public int? Panel_Local_Capacity_Value8 { get; set; }

        [Column("Panel GW1")]
        public int? Panel_GW1 { get; set; }

        [Column("Panel GW2")]
        public int? Panel_GW2 { get; set; }

        [Column("Panel GW3")]
        public int? Panel_GW3 { get; set; }

        [Column("Panel GW4")]
        public int? Panel_GW4 { get; set; }

        [Column("Panel IP1")]
        public int? Panel_IP1 { get; set; }

        [Column("Panel IP2")]
        public int? Panel_IP2 { get; set; }

        [Column("Panel IP3")]
        public int? Panel_IP3 { get; set; }

        [Column("Panel IP4")]
        public int? Panel_IP4 { get; set; }

        [Column("Panel TCP Port")]
        public int? Panel_TCP_Port { get; set; }

        [Column("Panel Subnet1")]
        public int? Panel_Subnet1 { get; set; }

        [Column("Panel Subnet2")]
        public int? Panel_Subnet2 { get; set; }

        [Column("Panel Subnet3")]
        public int? Panel_Subnet3 { get; set; }

        [Column("Panel Subnet4")]
        public int? Panel_Subnet4 { get; set; }

        [Column("Panel Remote IP1")]
        public int? Panel_Remote_IP1 { get; set; }

        [Column("Panel Remote IP2")]
        public int? Panel_Remote_IP2 { get; set; }

        [Column("Panel Remote IP3")]
        public int? Panel_Remote_IP3 { get; set; }

        [Column("Panel Remote IP4")]
        public int? Panel_Remote_IP4 { get; set; }

        [Column("Lift Capacity")]
        public int? Lift_Capacity { get; set; }

        [Column("Interlock Active")]
        public bool? Interlock_Active { get; set; }

        [Column("Same Door Multiple Reader")]
        public bool? Same_Door_Multiple_Reader { get; set; }

        [Column("Global Zone Interlock Active")]
        public bool? Global_Zone_Interlock_Active { get; set; }

        [Column("Panel Button Detector")]
        public bool? Panel_Button_Detector { get; set; }

        [Column("Panel Button Detector Time")]
        public int? Panel_Button_Detector_Time { get; set; }

        [Column("Offline Antipassback")]
        public bool? Offline_Antipassback { get; set; }

        [Column("Offline Blocked Request")]
        public bool? Offline_Blocked_Request { get; set; }

        [Column("Offline Undefined Transition")]
        public bool? Offline_Undefined_Transition { get; set; }

        [Column("Offline Manuel Operations")]
        public bool? Offline_Manuel_Operations { get; set; }

        [Column("Offline Button Triggering")]
        public bool? Offline_Button_Triggering { get; set; }

        [Column("Offline Scheduled Transactions")]
        public bool? Offline_Scheduled_Transactions { get; set; }

        [Column("LocalInterlock G1-1")]
        public int? LocalInterlock_G1_1 { get; set; }

        [Column("LocalInterlock G1-2")]
        public int? LocalInterlock_G1_2 { get; set; }

        [Column("LocalInterlock G2-1")]
        public int? LocalInterlock_G2_1 { get; set; }

        [Column("LocalInterlock G2-2")]
        public int? LocalInterlock_G2_2 { get; set; }

        [Column("LocalInterlock G3-1")]
        public int? LocalInterlock_G3_1 { get; set; }

        [Column("LocalInterlock G3-2")]
        public int? LocalInterlock_G3_2 { get; set; }

        [Column("LocalInterlock G4-1")]
        public int? LocalInterlock_G4_1 { get; set; }

        [Column("LocalInterlock G4-2")]
        public int? LocalInterlock_G4_2 { get; set; }

        [Column("DHCP Enabled")]
        public bool? DHCP_Enabled { get; set; }

        [Column("Hastane Aktif")]
        public bool? Hastane_Aktif { get; set; }

        [Column("Hastane IP1")]
        public int? Hastane_IP1 { get; set; }

        [Column("Hastane IP2")]
        public int? Hastane_IP2 { get; set; }

        [Column("Hastane IP3")]
        public int? Hastane_IP3 { get; set; }

        [Column("Hastane IP4")]
        public int? Hastane_IP4 { get; set; }

        [Column("Hastane Server TCP Port")]
        public int? Hastane_Server_TCP_Port { get; set; }

        [Column("Hastane Lokal TCP Port")]
        public int? Hastane_Lokal_TCP_Port { get; set; }

        [Column("Hastane Acil Durum Yesil Kod")]
        public bool? Hastane_Acil_Durum_Yesil_Kod { get; set; }

        [Column("Hastane Yesil Kod Suresi")]
        public int? Hastane_Yesil_Kod_Suresi { get; set; }
    }
}
