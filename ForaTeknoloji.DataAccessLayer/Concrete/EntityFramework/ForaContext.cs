namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ForaTeknoloji.Entities.Entities;

    public partial class ForaContext : DbContext
    {
        public ForaContext() : base("name=ForaContext")
        {

        }

        public virtual DbSet<AccessCountTypes> AccessCountTypes { get; set; }
        public virtual DbSet<AccessDatas> AccessDatas { get; set; }
        public virtual DbSet<AccessModes> AccessModes { get; set; }
        public virtual DbSet<Alarmlar> Alarmlar { get; set; }
        public virtual DbSet<AlarmTipleri> AlarmTipleri { get; set; }
        public virtual DbSet<Bloklar> Bloklar { get; set; }
        public virtual DbSet<Cameras> Cameras { get; set; }
        public virtual DbSet<CameraTypes> CameraTypes { get; set; }
        public virtual DbSet<CodeOperation> CodeOperation { get; set; }
        public virtual DbSet<DBRoles> DBRoles { get; set; }
        public virtual DbSet<DBUsers> DBUsers { get; set; }
        public virtual DbSet<DBUsersPanels> DBUsersPanels { get; set; }
        public virtual DbSet<DBUsersSirket> DBUsersSirket { get; set; }
        public virtual DbSet<DBUsersDepartman> DBUsersDepartman { get; set; }
        public virtual DbSet<Departmanlar> Departmanlar { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<DevicesSelected> DevicesSelected { get; set; }
        public virtual DbSet<DoorGroupsDetail> DoorGroupsDetail { get; set; }
        public virtual DbSet<DoorGroupsMaster> DoorGroupsMaster { get; set; }
        public virtual DbSet<DoorNames> DoorNames { get; set; }
        public virtual DbSet<FloorNames> FloorNames { get; set; }
        public virtual DbSet<GlobalZones> GlobalZones { get; set; }
        public virtual DbSet<GlobalZonesInterlock> GlobalZonesInterlock { get; set; }
        public virtual DbSet<GroupsDetail> GroupsDetail { get; set; }
        public virtual DbSet<GroupsMaster> GroupsMaster { get; set; }
        public virtual DbSet<LiftGroups> LiftGroups { get; set; }
        public virtual DbSet<MapObjects> MapObjects { get; set; }
        public virtual DbSet<Maps> Maps { get; set; }
        public virtual DbSet<PanelSettings> PanelSettings { get; set; }
        public virtual DbSet<ProgInit> ProgInit { get; set; }
        public virtual DbSet<ProgRelay2> ProgRelay2 { get; set; }
        public virtual DbSet<RawGroups> RawGroups { get; set; }
        public virtual DbSet<RawUsers> RawUsers { get; set; }
        public virtual DbSet<ReaderSettings> ReaderSettings { get; set; }
        public virtual DbSet<ReaderSettingsNew> ReaderSettingsNews { get; set; }
        public virtual DbSet<Sirketler> Sirketler { get; set; }
        public virtual DbSet<TimeGroups> TimeGroups { get; set; }
        public virtual DbSet<TimeZoneCalendar> TimeZoneCalendar { get; set; }
        public virtual DbSet<TimeZoneIDs> TimeZoneIDs { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAPB> UsersAPB { get; set; }
        public virtual DbSet<UsersLocalAPB> UsersLocalAPB { get; set; }
        public virtual DbSet<UsersOLD> UsersOLD { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<Visitors> Visitors { get; set; }
        public virtual DbSet<StatusCode> StatusCodes { get; set; }
        public virtual DbSet<TaskCode> TaskCodes { get; set; }
        public virtual DbSet<TaskList> TaskLists { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
