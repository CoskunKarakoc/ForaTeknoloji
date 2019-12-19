namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DevicesSelected")]
    public partial class DevicesSelected : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        public int? ID { get; set; }

        [Column("Kart No")]
        public int? Kart_No { get; set; }

        [Column("Cihaz ID")]
        public int? Cihaz_ID { get; set; }
    }
}
