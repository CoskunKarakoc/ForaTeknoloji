using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void DeleteDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster)
        {
            _doorGroupsMasterDal.Delete(doorGroupsMaster);
        }

        public List<DoorGroupsMaster> GetAllDoorGroupsMaster()
        {
            return _doorGroupsMasterDal.GetList();
        }

        public DoorGroupsMaster GetById(int id)
        {
            return _doorGroupsMasterDal.Get(x => x.Kapi_Grup_No == id);
        }

        public DoorGroupsMaster UpdateDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster)
        {
            return _doorGroupsMasterDal.Update(doorGroupsMaster);
        }
    }
}
