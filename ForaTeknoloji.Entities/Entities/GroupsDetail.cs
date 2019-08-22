namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupsDetail")]
    public partial class GroupsDetail : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Grup No")]
        public int Grup_No { get; set; }

        [Column("Grup Adi")]
        [StringLength(100)]
        public string Grup_Adi { get; set; }

        [Column("Seri No")]
        public int? Seri_No { get; set; }

        [Column("Panel No")]
        public short? Panel_No { get; set; }

        [Column("Panel Adi")]
        [StringLength(50)]
        public string Panel_Adi { get; set; }

        public bool? Kapi1 { get; set; }

        [Column("Kapi1 Zaman Grup No")]
        public int? Kapi1_Zaman_Grup_No { get; set; }

        public bool? Kapi2 { get; set; }

        [Column("Kapi2 Zaman Grup No")]
        public int? Kapi2_Zaman_Grup_No { get; set; }

        public bool? Kapi3 { get; set; }

        [Column("Kapi3 Zaman Grup No")]
        public int? Kapi3_Zaman_Grup_No { get; set; }

        public bool? Kapi4 { get; set; }

        [Column("Kapi4 Zaman Grup No")]
        public int? Kapi4_Zaman_Grup_No { get; set; }

        public bool? Kapi5 { get; set; }

        [Column("Kapi5 Zaman Grup No")]
        public int? Kapi5_Zaman_Grup_No { get; set; }

        public bool? Kapi6 { get; set; }

        [Column("Kapi6 Zaman Grup No")]
        public int? Kapi6_Zaman_Grup_No { get; set; }

        public bool? Kapi7 { get; set; }

        [Column("Kapi7 Zaman Grup No")]
        public int? Kapi7_Zaman_Grup_No { get; set; }

        public bool? Kapi8 { get; set; }

        [Column("Kapi8 Zaman Grup No")]
        public int? Kapi8_Zaman_Grup_No { get; set; }

        public bool? Kapi9 { get; set; }

        [Column("Kapi9 Zaman Grup No")]
        public int? Kapi9_Zaman_Grup_No { get; set; }

        public bool? Kapi10 { get; set; }

        [Column("Kapi10 Zaman Grup No")]
        public int? Kapi10_Zaman_Grup_No { get; set; }

        public bool? Kapi11 { get; set; }

        [Column("Kapi11 Zaman Grup No")]
        public int? Kapi11_Zaman_Grup_No { get; set; }

        public bool? Kapi12 { get; set; }

        [Column("Kapi12 Zaman Grup No")]
        public int? Kapi12_Zaman_Grup_No { get; set; }

        public bool? Kapi13 { get; set; }

        [Column("Kapi13 Zaman Grup No")]
        public int? Kapi13_Zaman_Grup_No { get; set; }

        public bool? Kapi14 { get; set; }

        [Column("Kapi14 Zaman Grup No")]
        public int? Kapi14_Zaman_Grup_No { get; set; }

        public bool? Kapi15 { get; set; }

        [Column("Kapi15 Zaman Grup No")]
        public int? Kapi15_Zaman_Grup_No { get; set; }

        public bool? Kapi16 { get; set; }

        [Column("Kapi16 Zaman Grup No")]
        public int? Kapi16_Zaman_Grup_No { get; set; }

        [Column("Kapi1 Global Bolge No")]
        public int? Kapi1_Global_Bolge_No { get; set; }

        [Column("Kapi2 Global Bolge No")]
        public int? Kapi2_Global_Bolge_No { get; set; }

        [Column("Kapi3 Global Bolge No")]
        public int? Kapi3_Global_Bolge_No { get; set; }

        [Column("Kapi4 Global Bolge No")]
        public int? Kapi4_Global_Bolge_No { get; set; }

        [Column("Kapi5 Global Bolge No")]
        public int? Kapi5_Global_Bolge_No { get; set; }

        [Column("Kapi6 Global Bolge No")]
        public int? Kapi6_Global_Bolge_No { get; set; }

        [Column("Kapi7 Global Bolge No")]
        public int? Kapi7_Global_Bolge_No { get; set; }

        [Column("Kapi8 Global Bolge No")]
        public int? Kapi8_Global_Bolge_No { get; set; }

        [Column("Kapi9 Global Bolge No")]
        public int? Kapi9_Global_Bolge_No { get; set; }

        [Column("Kapi10 Global Bolge No")]
        public int? Kapi10_Global_Bolge_No { get; set; }

        [Column("Kapi11 Global Bolge No")]
        public int? Kapi11_Global_Bolge_No { get; set; }

        [Column("Kapi12 Global Bolge No")]
        public int? Kapi12_Global_Bolge_No { get; set; }

        [Column("Kapi13 Global Bolge No")]
        public int? Kapi13_Global_Bolge_No { get; set; }

        [Column("Kapi14 Global Bolge No")]
        public int? Kapi14_Global_Bolge_No { get; set; }

        [Column("Kapi15 Global Bolge No")]
        public int? Kapi15_Global_Bolge_No { get; set; }

        [Column("Kapi16 Global Bolge No")]
        public int? Kapi16_Global_Bolge_No { get; set; }

        [Column("Kapi1 Asansor Bolge No")]
        public int? Kapi1_Asansor_Bolge_No { get; set; }

        [Column("Kapi2 Asansor Bolge No")]
        public int? Kapi2_Asansor_Bolge_No { get; set; }

        [Column("Kapi3 Asansor Bolge No")]
        public int? Kapi3_Asansor_Bolge_No { get; set; }

        [Column("Kapi4 Asansor Bolge No")]
        public int? Kapi4_Asansor_Bolge_No { get; set; }

        [Column("Kapi5 Asansor Bolge No")]
        public int? Kapi5_Asansor_Bolge_No { get; set; }

        [Column("Kapi6 Asansor Bolge No")]
        public int? Kapi6_Asansor_Bolge_No { get; set; }

        [Column("Kapi7 Asansor Bolge No")]
        public int? Kapi7_Asansor_Bolge_No { get; set; }

        [Column("Kapi8 Asansor Bolge No")]
        public int? Kapi8_Asansor_Bolge_No { get; set; }

        [Column("Kapi9 Asansor Bolge No")]
        public int? Kapi9_Asansor_Bolge_No { get; set; }

        [Column("Kapi10 Asansor Bolge No")]
        public int? Kapi10_Asansor_Bolge_No { get; set; }

        [Column("Kapi11 Asansor Bolge No")]
        public int? Kapi11_Asansor_Bolge_No { get; set; }

        [Column("Kapi12 Asansor Bolge No")]
        public int? Kapi12_Asansor_Bolge_No { get; set; }

        [Column("Kapi13 Asansor Bolge No")]
        public int? Kapi13_Asansor_Bolge_No { get; set; }

        [Column("Kapi14 Asansor Bolge No")]
        public int? Kapi14_Asansor_Bolge_No { get; set; }

        [Column("Kapi15 Asansor Bolge No")]
        public int? Kapi15_Asansor_Bolge_No { get; set; }

        [Column("Kapi16 Asansor Bolge No")]
        public int? Kapi16_Asansor_Bolge_No { get; set; }
    }
}
