namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GlobalZones : IEntity
    {
        [Key]
        [Column("Global Bolge No")]
        public int Global_Bolge_No { get; set; }

        [Column("Global Bolge Adi")]
        [StringLength(255)]
        public string Global_Bolge_Adi { get; set; }
    }
}
