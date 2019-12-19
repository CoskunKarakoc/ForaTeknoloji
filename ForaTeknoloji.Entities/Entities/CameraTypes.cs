namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CameraTypes : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Kamera Tipi")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Kamera_Tipi { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Marka { get; set; }

        [StringLength(50)]
        public string Model { get; set; }
    }
}
