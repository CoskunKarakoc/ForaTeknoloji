namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DoorGroupsDetail")]
    public partial class DoorGroupsDetail : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Kapi Grup No")]
        public int? Kapi_Grup_No { get; set; }

        [Column("Panel ID")]
        public int? Panel_ID { get; set; }

        [Column("Kapi ID")]
        public int? Kapi_ID { get; set; }
    }
}
