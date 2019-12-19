namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DBRoles : IEntity
    {
        [Key]
        [Column("Yetki Tipi")]
        public int Yetki_Tipi { get; set; }

        [Column("Yetki Adi")]
        [Required]
        [StringLength(50)]
        public string Yetki_Adi { get; set; }
    }
}
