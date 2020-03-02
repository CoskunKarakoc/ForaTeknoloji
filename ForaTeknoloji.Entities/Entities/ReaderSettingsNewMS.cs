using ForaTeknoloji.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForaTeknoloji.Entities.Entities
{
    [Table("ReaderSettingsNewMS")]
    public class ReaderSettingsNewMS : IEntity
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

        [Column("WKapi ID")]
        public int? WKapi_ID { get; set; }

        [Column("New Device ID")]
        public int? New_Device_ID { get; set; }

        [Column("WKapi Kapi Tipi")]
        public int? WKapi_Kapi_Tipi { get; set; }

        [Column("WKapi Kapi Kontrol Modu")]
        public int? WKapi_Kapi_Kontrol_Modu { get; set; }

        [Column("WKapi Kapi Gecis Modu")]
        public int? WKapi_Kapi_Gecis_Modu { get; set; }

        [Column("RS485 Reader Type")]
        public int? RS485_Reader_Type { get; set; }

        [Column("LCD Row Message")]
        [StringLength(20)]
        public string LCD_Row_Message { get; set; }

        [Column("WKapi Keypad Status")]
        public bool? WKapi_Keypad_Status { get; set; }

        [Column("WKapi Keypad Menu Password")]
        public int? WKapi_Keypad_Menu_Password { get; set; }

        [Column("RS485 Reader Status")]
        public bool? RS485_Reader_Status { get; set; }

        [Column("Wiegand Reader Status")]
        public bool? Wiegand_Reader_Status { get; set; }

        [Column("Wiegand Reader Type")]
        public int? Wiegand_Reader_Type { get; set; }

        [Column("Mifare Reader Status")]
        public bool? Mifare_Reader_Status { get; set; }

        [Column("Mifare Kart Data Type")]
        public int? Mifare_Kart_Data_Type { get; set; }

        [Column("UDP Haberlesme")]
        public bool? UDP_Haberlesme { get; set; }

        [Column("Multiple Clock Mode Counter Usage")]
        public bool? Multiple_Clock_Mode_Counter_Usage { get; set; }

        [Column("Kart ID 32 Bit Clear")]
        public bool? Kart_ID_32_Bit_Clear { get; set; }

        [Column("Pass Counter Auto Delete Cancel")]
        public bool? Pass_Counter_Auto_Delete_Cancel { get; set; }

        [Column("Access Counter Kontrol")]
        public bool? Access_Counter_Kontrol { get; set; }

        [Column("Turnstile Arm Tracking")]
        public bool? Turnstile_Arm_Tracking { get; set; }


    }
}
