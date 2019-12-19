using ForaTeknoloji.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForaTeknoloji.Entities.Entities
{
    [Table("DBUsersDepartman")]
    public partial class DBUsersDepartman : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Kullanici Adi")]
        [Required]
        [StringLength(50)]
        public string Kullanici_Adi { get; set; }

        [Column("Departman No")]
        public int? Departman_No { get; set; }
    }
}
