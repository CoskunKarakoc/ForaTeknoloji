namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bolum")]
    public partial class Bolum : IEntity
    {
        [Key]
        [Column("Bolum No")]
        public int Bolum_No { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }

        [Column("Departman No")]
        public int? Departman_No { get; set; }

        [Column("Alt Departman No")]
        public int? Alt_Departman_No { get; set; }

    }
}
