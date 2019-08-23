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
            Bind<IDevicesDal>().To<EfDeviceDal>().InSingletonScope();
            Bind<IUsersOLDDal>().To<EfUsersOLDDal>().InSingletonScope();
            Bind<ICodeOperationDal>().To<EfCodeOperationDal>().InSingletonScope();
            Bind<IAccessModesDal>().To<EfAccessModesDal>().InSingletonScope();
            Bind<IRawUsersDal>().To<EfRawUsersDal>().InSingletonScope();
            Bind<ITimeGroupsDal>().To<EfTimeGroupsDal>().InSingletonScope();
            Bind<IGlobalZonesInterlockDal>().To<EfGlobalZonesInterlockDal>().InSingletonScope();
            Bind<IDBUsersDal>().To<EfDBUsersDal>().InSingletonScope();
            Bind<IDBRolesDal>().To<EfDBRolesDal>().InSingletonScope();
            Bind<IDBUsersSirketDal>().To<EfDBUsersSirketDal>().InSingletonScope();
            Bind<IAlarmlarDal>().To<EfAlarmlarDal>().InSingletonScope();
            Bind<IAlarmTipleriDal>().To<EfAlarmTipleriDal>().InSingletonScope();
            Bind<IAccessCountTypesDal>().To<EfAccessCountTypesDal>().InSingletonScope();
            Bind<ICamerasDal>().To<EfCamerasDal>().InSingletonScope();
            Bind<IDoorGroupsDetailDal>().To<EfDoorGroupsDetailDal>().InSingletonScope();
            Bind<IDoorGroupsMasterDal>().To<EfDoorGroupsMasterDal>().InSingletonScope();
            Bind<IFloorNamesDal>().To<EfFloorNamesDal>().InSingletonScope();
            Bind<ILiftGroupsDal>().To<EfLiftGroupsDal>().InSingletonScope();
            Bind<IRawGroupsDal>().To<EfRawGroupsDal>().InSingletonScope();
            Bind<IReaderSettingsDal>().To<EfReaderSettingsDal>().InSingletonScope();
            Bind<IMapsDal>().To<EfMapsDal>().InSingletonScope();
            Bind<IMapsObjectsDal>().To<EfMapsObjectsDal>().InSingletonScope();
            Bind<IVisitorsDal>().To<EfVisitorsDal>().InSingletonScope();

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
            Bind<IDevicesService>().To<DevicesManager>().InSingletonScope();
            Bind<IUsersOLDService>().To<UsersOLDManager>().InSingletonScope();
            Bind<ICodeOperationService>().To<CodeOperationManager>().InSingletonScope();
            Bind<IAccessModesService>().To<AccessModesManager>().InSingletonScope();
            Bind<IRawUsersService>().To<RawUsersManager>().InSingletonScope();
            Bind<ITimeGroupsService>().To<TimeGroupsManager>().InSingletonScope();
            Bind<IGlobalZonesInterlockService>().To<GlobalZonesInterlockManager>().InSingletonScope();
            Bind<IDBUsersService>().To<DBUsersManager>().InSingletonScope();
            Bind<IDBRolesService>().To<DBRolesManager>().InSingletonScope();
            Bind<IDBUsersSirketService>().To<DBUsersSirketManager>().InSingletonScope();
            Bind<IAlarmlarService>().To<AlarmlarManager>().InSingletonScope();
            Bind<IAlarmTipleriService>().To<AlarmTipleriManager>().InSingletonScope();
            Bind<IAccessCountTypesService>().To<AccessCountTypesManager>().InSingletonScope();
            Bind<ICamerasService>().To<CamerasManager>().InSingletonScope();
            Bind<IDoorGroupsDetailService>().To<DoorGroupsDetailManager>().InSingletonScope();
            Bind<IDoorGroupsMasterService>().To<DoorGroupsMasterManager>().InSingletonScope();
            Bind<IFloorNamesService>().To<FloorNamesManager>().InSingletonScope();
            Bind<ILiftGroupsService>().To<LiftGroupsManager>().InSingletonScope();
            Bind<IRawGroupsService>().To<RawGroupsManager>().InSingletonScope();
            Bind<IReaderSettingsService>().To<ReaderSettingsManager>().InSingletonScope();
            Bind<IMapsService>().To<MapsManager>().InSingletonScope();
            Bind<IMapsObjectsService>().To<MapsObjectsManager>().InSingletonScope();
            Bind<IVisitorsService>().To<VisitorsManager>().InSingletonScope();
            /*Context*/
            Bind<DbContext>().To<ForaContext>();
        }
    }
}
