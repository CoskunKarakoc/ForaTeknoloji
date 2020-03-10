using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.BusinessLayer.Concrete;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using Ninject.Modules;
using System.Data.Entity;

namespace ForaTeknoloji.BusinessLayer.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            /*DataAccess-Layer-Binding*/
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
            Bind<IDepartmanDal>().To<EfDepartmanDal>().InSingletonScope();
            Bind<ISirketDal>().To<EfSirketDal>().InSingletonScope();
            Bind<IGroupsDetailDal>().To<EfGroupsDetailDal>().InSingletonScope();
            Bind<IBloklarDal>().To<EfBloklarDal>().InSingletonScope();
            Bind<IGlobalZoneDal>().To<EfGlobalZoneDal>().InSingletonScope();
            Bind<IGroupMasterDal>().To<EfGroupsMasterDal>().InSingletonScope();
            Bind<IAccessDatasDal>().To<EfAccessDatasDal>().InSingletonScope();
            Bind<IPanelSettingsDal>().To<EfPanelSettingsDal>().InSingletonScope();
            Bind<IUsersOLDDal>().To<EfUsersOLDDal>().InSingletonScope();
            Bind<ICodeOperationDal>().To<EfCodeOperationDal>().InSingletonScope();
            Bind<IGlobalZonesInterlockDal>().To<EfGlobalZonesInterlockDal>().InSingletonScope();
            Bind<IVisitorsDal>().To<EfVisitorsDal>().InSingletonScope();
            Bind<IDBUsersDal>().To<EfDBUsersDal>().InSingletonScope();
            Bind<IDBUsersSirketDal>().To<EfDBUsersSirketDal>().InSingletonScope();
            Bind<IReaderSettingDal>().To<EfReaderSettingsDal>().InSingletonScope();
            Bind<IDBUsersPanelsDal>().To<EfDBUsersPanelsDal>().InSingletonScope();
            Bind<IDBUsersDepartmanDal>().To<EfDBUsersDepartmanDal>().InSingletonScope();
            Bind<IDoorNamesDal>().To<EfDoorNamesDal>().InSingletonScope();
            Bind<IUserTypesDal>().To<EfUserTypesDal>().InSingletonScope();
            Bind<IAccessModesDal>().To<EfAccessModesDal>().InSingletonScope();
            Bind<ITimeZoneCalendarDal>().To<EfTimeZoneCalendarDal>().InSingletonScope();
            Bind<ITaskListDal>().To<EfTaskListDal>().InSingletonScope();
            Bind<IAlarmlarDal>().To<EfAlarmlarDal>().InSingletonScope();
            Bind<IAlarmTipleriDal>().To<EfAlarmTipleriDal>().InSingletonScope();
            Bind<ITimeGroupsDal>().To<EfTimeGroupsDal>().InSingletonScope();
            Bind<ITimeZoneIDsDal>().To<EfTimeZoneIDsDal>().InSingletonScope();
            Bind<IDBRolesDal>().To<EfDBRolesDal>().InSingletonScope();
            Bind<IReaderSettingsNewDal>().To<EfReaderSettingsNewDal>().InSingletonScope();
            Bind<IProgInitDal>().To<EfProgInitDal>().InSingletonScope();
            Bind<ICamerasDal>().To<EfCamerasDal>().InSingletonScope();
            Bind<ICameraTypesDal>().To<EfCameraTypesDal>().InSingletonScope();
            Bind<IFloorNamesDal>().To<EfFloorNamesDal>().InSingletonScope();
            Bind<ILiftGroupsDal>().To<EfLiftGroupsDal>().InSingletonScope();
            Bind<IProgRelay2Dal>().To<EfProgRelay2Dal>().InSingletonScope();
            Bind<IGroupsDetailNewDal>().To<EfGroupsDetailNewDal>().InSingletonScope();
            Bind<IStatusCodesDal>().To<EfStatusCodesDal>().InSingletonScope();
            Bind<ITaskCodesDal>().To<EfTaskCodeDal>().InSingletonScope();
            Bind<IEmailSettingsDal>().To<EfEmailSettingsDal>().InSingletonScope();
            Bind<ISMSSettingsDal>().To<EfSmsSettingsDal>().InSingletonScope();
            Bind<IRawUsersDal>().To<EfRawUsersDal>().InSingletonScope();
            Bind<IRawGroupsDal>().To<EfRawGorupsDal>().InSingletonScope();
            Bind<IGorevlerDal>().To<EfGorevlerDal>().InSingletonScope();
            Bind<IDoorGroupsDetailDal>().To<EfDoorGroupsDetailDal>().InSingletonScope();
            Bind<IDoorGroupsMasterDal>().To<EfDoorGroupsMasterDal>().InSingletonScope();
            Bind<IDoorStatusDal>().To<EfDoorStatusDal>().InSingletonScope();
            Bind<IUnvanDal>().To<EfUnvanDal>().InSingletonScope();
            Bind<IBolumDal>().To<EfBolumDal>().InSingletonScope();
            Bind<IAltDepartmanDal>().To<EfAltDepartmanDal>().InSingletonScope();
            Bind<IAccessDatasTempDal>().To<EfAccessDatasTempDal>().InSingletonScope();
            Bind<IReaderSettingsNewMSDal>().To<EfReaderSettingsNewMSDal>().InSingletonScope();
            Bind<ITatilGunuDal>().To<EfTatilGunuDal>().InSingletonScope();

            /*Business-Layer-Binding*/
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IDepartmanService>().To<DepartmanManager>().InSingletonScope();
            Bind<ISirketService>().To<SirketManager>().InSingletonScope();
            Bind<IGroupsDetailService>().To<GroupsDetailManager>().InSingletonScope();
            Bind<IBloklarService>().To<BloklarManager>().InSingletonScope();
            Bind<IGlobalZoneService>().To<GlobalZoneManager>().InSingletonScope();
            Bind<IGroupMasterService>().To<GroupsMasterManager>().InSingletonScope();
            Bind<IAccessDatasService>().To<AccessDatasManager>().InSingletonScope();
            Bind<IPanelSettingsService>().To<PanelSettingsManager>().InSingletonScope();
            Bind<IUsersOLDService>().To<UsersOLDManager>().InSingletonScope();
            Bind<ICodeOperationService>().To<CodeOperationManager>().InSingletonScope();
            Bind<IGlobalZonesInterlockService>().To<GlobalZonesInterlockManager>().InSingletonScope();
            Bind<IVisitorsService>().To<VisitorsManager>().InSingletonScope();
            Bind<IReportService>().To<ReportManager>().InSingletonScope();
            Bind<IDBUsersService>().To<DBUsersManager>().InSingletonScope();
            Bind<IDBUsersSirketService>().To<DBUsersSirketManager>().InSingletonScope();
            Bind<IReaderSettingsService>().To<ReaderSettingsManager>().InSingletonScope();
            Bind<IDBUsersPanelsService>().To<DBUsersPanelsManager>().InSingletonScope();
            Bind<IDBUsersDepartmanService>().To<DBUsersDepartmanManager>().InSingletonScope();
            Bind<IDoorNamesService>().To<DoorNamesManager>().InSingletonScope();
            Bind<IUserTypesService>().To<UserTypesManager>().InSingletonScope();
            Bind<IAccessModesService>().To<AccessModesManager>().InSingletonScope();
            Bind<ITimeZoneCalendarService>().To<TimeZoneCalendarManager>().InSingletonScope();
            Bind<ITaskListService>().To<TaskListManager>().InSingletonScope();
            Bind<IAlarmlarService>().To<AlarmlarManager>().InSingletonScope();
            Bind<IAlarmTipleriService>().To<AlarmTipleriManager>().InSingletonScope();
            Bind<ITimeGroupsService>().To<TimeGroupsManager>().InSingletonScope();
            Bind<ITimeZoneIDsService>().To<TimeZoneIDsManager>().InSingletonScope();
            Bind<IDBRolesService>().To<DBRolesManager>().InSingletonScope();
            Bind<IReaderSettingsNewService>().To<ReaderSettingsNewManager>().InSingletonScope();
            Bind<IProgInitService>().To<ProgInitManager>().InSingletonScope();
            Bind<ICamerasService>().To<CamerasManager>().InSingletonScope();
            Bind<ICameraTypesService>().To<CameraTypesManager>().InSingletonScope();
            Bind<IFloorNamesService>().To<FloorNamesManager>().InSingletonScope();
            Bind<ILiftGroupsService>().To<LiftGroupsManager>().InSingletonScope();
            Bind<IProgRelay2Service>().To<ProgRelay2Manager>().InSingletonScope();
            Bind<IGroupsDetailNewService>().To<GroupsDetailNewManager>().InSingletonScope();
            Bind<IStatusCodesService>().To<StatusCodesManager>().InSingletonScope();
            Bind<ITaskCodeService>().To<TaskCodeManager>().InSingletonScope();
            Bind<IEmailSettingsService>().To<EMailSettingsManager>().InSingletonScope();
            Bind<ISmsSettingsService>().To<SmsSettingsManager>().InSingletonScope();
            Bind<IRawUsersService>().To<RawUsersManager>().InSingletonScope();
            Bind<IRawGroupsService>().To<RawGroupsManager>().InSingletonScope();
            Bind<IGorevlerService>().To<GorevlerManager>().InSingletonScope();
            Bind<IDoorGroupsDetailService>().To<DoorGroupsDetailManager>().InSingletonScope();
            Bind<IDoorGroupsMasterService>().To<DoorGroupsMasterManager>().InSingletonScope();
            Bind<IDoorStatusService>().To<DoorStatusManager>().InSingletonScope();
            Bind<IUnvanService>().To<UnvanManager>().InSingletonScope();
            Bind<IBolumService>().To<BolumManager>().InSingletonScope();
            Bind<IAltDepartmanService>().To<AltDepartmanManager>().InSingletonScope();
            Bind<IAccessDatasTempService>().To<AccessDatasTempManager>().InSingletonScope();
            Bind<IReaderSettingsNewMSService>().To<ReaderSettingsNewMSManager>().InSingletonScope();
            Bind<ITatilGunuService>().To<TatilGunuManager>().InSingletonScope();

            /*Context*/
            Bind<DbContext>().To<ForaContext>();
        }
    }
}
