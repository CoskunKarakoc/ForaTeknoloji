namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class StatusCode : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Durum Adi")]
        [Required]
        [StringLength(150)]
        public string Durum_Adi { get; set; }

        [Column("Durum Kodu")]
        public int Durum_Kodu { get; set; }
    }
}
