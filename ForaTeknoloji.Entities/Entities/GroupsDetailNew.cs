namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GroupsDetailNew")]
    public partial class GroupsDetailNew : IEntity
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

        [Column("Kapi Aktif")]
        public bool? Kapi_Aktif { get; set; }

        [Column("Kapi Zaman Grup No")]
        public int? Zaman_Grup_No { get; set; }

        [Column("Kapi No")]
        public int? Kapi_No { get; set; }

        [Column("Kapi Global Bolge No")]
        public int? Global_Bolge_No { get; set; }

        [Column("Kapi Asansor Bolge No")]
        public int? Asansor_Grup_No { get; set; }
    }
}
