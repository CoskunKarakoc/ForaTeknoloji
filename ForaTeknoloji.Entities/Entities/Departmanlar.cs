namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Departmanlar")]
    public partial class Departmanlar : IEntity
    {
        [Key]
        [Column("Departman No")]
        public int Departman_No { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }
    }
}
