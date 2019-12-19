namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AlarmTipleri")]
    public partial class AlarmTipleri : IEntity
    {
        [Column("Kayit No")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kayit_No { get; set; }

        [Key]
        [Column("Alarm Tipi")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Alarm_Tipi { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }
    }
}
