namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UsersLocalAPB")]
    public partial class UsersLocalAPB : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        public int? ID { get; set; }

        [Column("Panel No")]
        public int? Panel_No { get; set; }

        [Column("Local Bolge No")]
        public int? Local_Bolge_No { get; set; }

        public int? APB { get; set; }

        [Column("Local Bolge 1 APB")]
        public int? Local_Bolge_1_APB { get; set; }

        [Column("Local Bolge 2 APB")]
        public int? Local_Bolge_2_APB { get; set; }

        [Column("Local Bolge 3 APB")]
        public int? Local_Bolge_3_APB { get; set; }

        [Column("Local Bolge 4 APB")]
        public int? Local_Bolge_4_APB { get; set; }

        [Column("Local Bolge 5 APB")]
        public int? Local_Bolge_5_APB { get; set; }

        [Column("Local Bolge 6 APB")]
        public int? Local_Bolge_6_APB { get; set; }

        [Column("Local Bolge 7 APB")]
        public int? Local_Bolge_7_APB { get; set; }

        [Column("Local Bolge 8 APB")]
        public int? Local_Bolge_8_APB { get; set; }
    }
}
