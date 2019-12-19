namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UsersAPB")]
    public partial class UsersAPB : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        public int? ID { get; set; }

        [Column("Global Bolge No")]
        public int? Global_Bolge_No { get; set; }

        public int? APB { get; set; }
    }
}
