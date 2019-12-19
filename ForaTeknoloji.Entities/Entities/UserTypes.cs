namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserTypes : IEntity
    {
        [Key]
        [Column("Kullanici Tipi")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Kullanici_Tipi { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }
    }
}
