using ForaTeknoloji.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForaTeknoloji.Entities.Entities
{
    [Table("AltDepartmanlar")]
    public class AltDepartman : IEntity
    {
        [Key]
        [Column("Alt Departman No")]
        public int Alt_Departman_No { get; set; }

        [Column("Departman No")]
        public int Departman_No { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }
    }
}
