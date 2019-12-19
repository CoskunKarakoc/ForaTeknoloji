namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DoorNames : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        [Column("Panel No")]
        public int Panel_No { get; set; }

        [Column("Kapi No")]
        public int Kapi_No { get; set; }

        [Column("Panel Adi")]
        [StringLength(50)]
        public string Panel_Adi { get; set; }

        [Column("Kapi Adi")]
        [StringLength(50)]
        public string Kapi_Adi { get; set; }
    }
}
