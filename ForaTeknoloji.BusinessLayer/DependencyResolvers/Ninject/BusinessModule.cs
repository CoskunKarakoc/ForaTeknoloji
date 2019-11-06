using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.BusinessLayer.Concrete;
using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            /*Context*/
            Bind<DbContext>().To<ForaContext>();
        }
    }
}
