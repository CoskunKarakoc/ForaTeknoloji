namespace ForaTeknoloji.Entities.Entities
{
    using ForaTeknoloji.Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProgInit")]
    public partial class ProgInit : IEntity
    {
        [Key]
        [Column("Kayit No")]
        public int Kayit_No { get; set; }

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

        public bool? NoOpLogUser { get; set; }

        public bool? NoOpLogTimeZone { get; set; }

        public bool? NoOpLogGroup { get; set; }

        public bool? NoOpLogPanelLogs { get; set; }

        public bool? NoOpLogVisitor { get; set; }

        public bool? NoOpLogUserAlarm { get; set; }

        public bool? NoOpLogCamera { get; set; }

        public bool? NoOpLogLift { get; set; }

        public bool? NoOpLogProgrammedRelay { get; set; }

        public bool? NoOpLogCompany { get; set; }

        public bool? NoOpLogDepartment { get; set; }

        public bool? NoOpLogBlock { get; set; }

        public bool? NoOpLogImport { get; set; }

        public bool? NoOpLogEmailSMS { get; set; }

        public bool? NoOpLogUserGlobalInterlock { get; set; }

        public bool? NoOpLogGroupCalendar { get; set; }

        public bool? NoOpLogReports { get; set; }

        public bool? NoOpLogDatabase { get; set; }

        public bool? NoOpPanelSettings { get; set; }

        public bool? NoOpOther { get; set; }
    }
}
