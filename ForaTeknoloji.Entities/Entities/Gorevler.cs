using ForaTeknoloji.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForaTeknoloji.Entities.Entities
{
    [Table("Gorevler")]
    public class Gorevler : IEntity
    {
        [Key]
        [Column("Gorev No")]
        public int Gorev_No { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }

    }
}
