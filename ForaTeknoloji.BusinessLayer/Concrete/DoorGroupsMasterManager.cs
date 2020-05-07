using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DoorGroupsMasterManager : IDoorGroupsMasterService
    {

        private IDoorGroupsMasterDal _doorGroupsMasterDal;
        public DoorGroupsMasterManager(IDoorGroupsMasterDal doorGroupsMasterDal)
        {
            _doorGroupsMasterDal = doorGroupsMasterDal;
        }


        public DoorGroupsMaster AddDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster)
        {
            return _doorGroupsMasterDal.Add(doorGroupsMaster);
        }

        public void DeletDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster)
        {
            _doorGroupsMasterDal.Delete(doorGroupsMaster);
        }

        public void DeleteAll()
        {
            _doorGroupsMasterDal.DeleteAll();
        }

        public List<DoorGroupsMaster> GetAllDoorGroupsMaster(Expression<Func<DoorGroupsMaster, bool>> filter = null)
        {
            return filter == null ? _doorGroupsMasterDal.GetList() : _doorGroupsMasterDal.GetList(filter);
        }

        public DoorGroupsMaster GetById(int id)
        {
            return _doorGroupsMasterDal.Get(x => x.Kayit_No == id);
        }

        public DoorGroupsMaster GetByKapiGrupNo(int Kapi_Grup_No)
        {
            return _doorGroupsMasterDal.Get(x => x.Kapi_Grup_No == Kapi_Grup_No);
        }


        public DoorGroupsMaster UpdateDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster)
        {
            return _doorGroupsMasterDal.Update(doorGroupsMaster);
        }

        public void DeleteByKapiGrupNo(int Kapi_Grup_No)
        {
            _doorGroupsMasterDal.DeleteByKapiGrupNo(Kapi_Grup_No);
        }

    }
}
