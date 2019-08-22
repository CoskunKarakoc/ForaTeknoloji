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
    public class DoorGroupsDetailManager : IDoorGroupsDetailService
    {
        private IDoorGroupsDetailDal _doorGroupsDetailDal;
        public DoorGroupsDetailManager(IDoorGroupsDetailDal doorGroupsDetailDal)
        {
            _doorGroupsDetailDal = doorGroupsDetailDal;
        }
        public DoorGroupsDetail AddDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail)
        {
            return _doorGroupsDetailDal.Add(doorGroupsDetail);
        }

        public void DeleteDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail)
        {
            _doorGroupsDetailDal.Delete(doorGroupsDetail);
        }

        public List<DoorGroupsDetail> GetAllDoorGroupsDetail()
        {
            return _doorGroupsDetailDal.GetList();
        }

        public DoorGroupsDetail GetById(int id)
        {
            return _doorGroupsDetailDal.Get(x => x.Kayit_No == id);
        }

        public DoorGroupsDetail UpdateDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail)
        {
            return _doorGroupsDetailDal.Update(doorGroupsDetail);
        }
    }
}
