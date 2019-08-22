namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgInit")]
    public partial class ProgInit : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

        public int? Password { get; set; }

        [Column("User Name 1")]
        [StringLength(50)]
        public string User_Name_1 { get; set; }

        [Column("Password 1")]
        public int? Password_1 { get; set; }

        [Column("User Type 1")]
        public int? User_Type_1 { get; set; }

        [Column("User Name 2")]
        [StringLength(50)]
        public string User_Name_2 { get; set; }

        [Column("Password 2")]
        public int? Password_2 { get; set; }

        [Column("User Type 2")]
        public int? User_Type_2 { get; set; }

        [Column("User Name 3")]
        [StringLength(50)]
        public string User_Name_3 { get; set; }

        [Column("Password 3")]
        public int? Password_3 { get; set; }

        [Column("User Type 3")]
        public int? User_Type_3 { get; set; }

        [Column("User Name 4")]
        [StringLength(50)]
        public string User_Name_4 { get; set; }

        [Column("Password 4")]
        public int? Password_4 { get; set; }

        [Column("User Type 4")]
        public int? User_Type_4 { get; set; }

        [Column("User Name 5")]
        [StringLength(50)]
        public string User_Name_5 { get; set; }

        [Column("Password 5")]
        public int? Password_5 { get; set; }

        [Column("User Type 5")]
        public int? User_Type_5 { get; set; }

        [Column("User Name 6")]
        [StringLength(50)]
        public string User_Name_6 { get; set; }

        [Column("Password 6")]
        public int? Password_6 { get; set; }

        [Column("User Type 6")]
        public int? User_Type_6 { get; set; }

        [Column("User Name 7")]
        [StringLength(50)]
        public string User_Name_7 { get; set; }

        [Column("Password 7")]
        public int? Password_7 { get; set; }

        [Column("User Type 7")]
        public int? User_Type_7 { get; set; }

        [Column("User Name 8")]
        [StringLength(50)]
        public string User_Name_8 { get; set; }

        [Column("Password 8")]
        public int? Password_8 { get; set; }

        [Column("User Type 8")]
        public int? User_Type_8 { get; set; }

        [Column("User Name 9")]
        [StringLength(50)]
        public string User_Name_9 { get; set; }

        [Column("Password 9")]
        public int? Password_9 { get; set; }

        [Column("User Type 9")]
        public int? User_Type_9 { get; set; }

        [Column("User Name 10")]
        [StringLength(50)]
        public string User_Name_10 { get; set; }

        [Column("Password 10")]
        public int? Password_10 { get; set; }

        [Column("User Type 10")]
        public int? User_Type_10 { get; set; }

        public int? AdminPassword { get; set; }

        public int? UHFPower { get; set; }

        public int? BackupPeriode { get; set; }

        public int? BackupDay { get; set; }

        public DateTime? LastBackupDate { get; set; }

        public bool? LiveAPBInvalid { get; set; }

        public bool? LiveDeniedInvalid { get; set; }

        public bool? LiveUnknownInvalid { get; set; }

        public bool? LiveButtonInvalid { get; set; }

        public bool? LiveManuelInvalid { get; set; }

        public bool? LiveProgrammedInvalid { get; set; }

        public bool? UpdateAccessFile { get; set; }
    }
}
