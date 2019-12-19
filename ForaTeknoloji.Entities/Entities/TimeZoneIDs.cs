namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TimeZoneIDs : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Gecis Sinirlama Tipi")]
        public int? Gecis_Sinirlama_Tipi { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }
    }
}
