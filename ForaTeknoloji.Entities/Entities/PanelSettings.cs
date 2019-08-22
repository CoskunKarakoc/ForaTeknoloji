namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        public int? Lokal_APB1 { get; set; }

        [Column("Lokal APB2")]
        public int? Lokal_APB2 { get; set; }

        [Column("Lokal APB3")]
        public int? Lokal_APB3 { get; set; }

        [Column("Lokal APB4")]
        public int? Lokal_APB4 { get; set; }

        [Column("Lokal APB5")]
        public int? Lokal_APB5 { get; set; }

        [Column("Lokal APB6")]
        public int? Lokal_APB6 { get; set; }

        [Column("Lokal APB7")]
        public int? Lokal_APB7 { get; set; }

        [Column("Lokal APB8")]
        public int? Lokal_APB8 { get; set; }

        [Column("Global APB")]
        public int? Global_APB { get; set; }

        [Column("Global Bolge No")]
        public int? Global_Bolge_No { get; set; }

        [Column("Global Capacity Control")]
        public int? Global_Capacity_Control { get; set; }

        [Column("Global Access Count Control")]
        public int? Global_Access_Count_Control { get; set; }

        [Column("Global MaxIn Count Control")]
        public int? Global_MaxIn_Count_Control { get; set; }

        [Column("Global Sequental Access Control")]
        public int? Global_Sequental_Access_Control { get; set; }

        [Column("Panel Same Tag Block")]
        public int? Panel_Same_Tag_Block { get; set; }

        [Column("Panel Same Tag Block Type")]
        public int? Panel_Same_Tag_Block_Type { get; set; }

        [Column("Panel Same Tag Block HourMinSec")]
        public int? Panel_Same_Tag_Block_HourMinSec { get; set; }

        [Column("Status Data Update")]
        public int? Status_Data_Update { get; set; }

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
        public int? Panel_Alarm_Mode_Role_Ok { get; set; }

        [Column("Panel Alarm Mode")]
        public int? Panel_Alarm_Mode { get; set; }

        [Column("Panel Fire Mode Role Ok")]
        public int? Panel_Fire_Mode_Role_Ok { get; set; }

        [Column("Panel Fire Mode")]
        public int? Panel_Fire_Mode { get; set; }

        [Column("Panel Door Alarm Role Ok")]
        public int? Panel_Door_Alarm_Role_Ok { get; set; }

        [Column("Panel Alarm Broadcast Ok")]
        public int? Panel_Alarm_Broadcast_Ok { get; set; }

        [Column("Panel Fire Broadcast Ok")]
        public int? Panel_Fire_Broadcast_Ok { get; set; }

        [Column("Panel Door Alarm Broadcast Ok")]
        public int? Panel_Door_Alarm_Broadcast_Ok { get; set; }

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
        public int? Panel_Local_Capacity1 { get; set; }

        [Column("Panel Local Capacity Clear1")]
        public int? Panel_Local_Capacity_Clear1 { get; set; }

        [Column("Panel Local Capacity Value1")]
        public int? Panel_Local_Capacity_Value1 { get; set; }

        [Column("Panel Local Capacity2")]
        public int? Panel_Local_Capacity2 { get; set; }

        [Column("Panel Local Capacity Clear2")]
        public int? Panel_Local_Capacity_Clear2 { get; set; }

        [Column("Panel Local Capacity Value2")]
        public int? Panel_Local_Capacity_Value2 { get; set; }

        [Column("Panel Local Capacity3")]
        public int? Panel_Local_Capacity3 { get; set; }

        [Column("Panel Local Capacity Clear3")]
        public int? Panel_Local_Capacity_Clear3 { get; set; }

        [Column("Panel Local Capacity Value3")]
        public int? Panel_Local_Capacity_Value3 { get; set; }

        [Column("Panel Local Capacity4")]
        public int? Panel_Local_Capacity4 { get; set; }

        [Column("Panel Local Capacity Clear4")]
        public int? Panel_Local_Capacity_Clear4 { get; set; }

        [Column("Panel Local Capacity Value4")]
        public int? Panel_Local_Capacity_Value4 { get; set; }

        [Column("Panel Local Capacity5")]
        public int? Panel_Local_Capacity5 { get; set; }

        [Column("Panel Local Capacity Clear5")]
        public int? Panel_Local_Capacity_Clear5 { get; set; }

        [Column("Panel Local Capacity Value5")]
        public int? Panel_Local_Capacity_Value5 { get; set; }

        [Column("Panel Local Capacity6")]
        public int? Panel_Local_Capacity6 { get; set; }

        [Column("Panel Local Capacity Clear6")]
        public int? Panel_Local_Capacity_Clear6 { get; set; }

        [Column("Panel Local Capacity Value6")]
        public int? Panel_Local_Capacity_Value6 { get; set; }

        [Column("Panel Local Capacity7")]
        public int? Panel_Local_Capacity7 { get; set; }

        [Column("Panel Local Capacity Clear7")]
        public int? Panel_Local_Capacity_Clear7 { get; set; }

        [Column("Panel Local Capacity Value7")]
        public int? Panel_Local_Capacity_Value7 { get; set; }

        [Column("Panel Local Capacity8")]
        public int? Panel_Local_Capacity8 { get; set; }

        [Column("Panel Local Capacity Clear8")]
        public int? Panel_Local_Capacity_Clear8 { get; set; }

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
        public int? Interlock_Active { get; set; }

        [Column("Same Door Multiple Reader")]
        public int? Same_Door_Multiple_Reader { get; set; }

        [Column("Global Zone Interlock Active")]
        public int? Global_Zone_Interlock_Active { get; set; }

        [Column("Panel Button Detector")]
        public int? Panel_Button_Detector { get; set; }

        [Column("Panel Button Detector Time")]
        public int? Panel_Button_Detector_Time { get; set; }
    }
}
