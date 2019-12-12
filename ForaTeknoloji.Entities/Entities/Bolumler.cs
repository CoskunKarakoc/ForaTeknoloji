using ForaTeknoloji.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.Entities
{
    [Table("Bolumler")]
    public class Bolumler : IEntity
    {
        [Key]
        [Column("Bolum No")]
        public int Bolum_No { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }
    }
}
