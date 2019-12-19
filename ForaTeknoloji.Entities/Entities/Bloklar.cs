namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bloklar")]
    public partial class Bloklar : IEntity
    {
        [Key]
        [Column("Blok No")]
        public int Blok_No { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }
    }
}
