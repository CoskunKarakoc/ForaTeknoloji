namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AccessCountTypes : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Gecis Sayisi Tipi")]
        [StringLength(50)]
        public string Gecis_Sayisi_Tipi { get; set; }
    }
}
