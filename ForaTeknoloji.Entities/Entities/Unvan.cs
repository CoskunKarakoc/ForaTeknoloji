namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Unvan")]
    public partial class Unvan : IEntity
    {
        [Key]
        [Column("Unvan No")]
        public int Unvan_No { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }
    }
}
