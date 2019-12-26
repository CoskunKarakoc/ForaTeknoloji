using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        public void DeletDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail)
        {
            _doorGroupsDetailDal.Delete(doorGroupsDetail);
        }

        public void DeleteAll()
        {
            _doorGroupsDetailDal.DeleteAll();
        }

        public List<DoorGroupsDetail> GetAllDoorGroupsDetail(Expression<Func<DoorGroupsDetail, bool>> filter = null)
        {
            return filter == null ? _doorGroupsDetailDal.GetList() : _doorGroupsDetailDal.GetList(filter);
        }


        public DoorGroupsDetail GetById(int id)
        {
            return _doorGroupsDetailDal.Get(x => x.Kayit_No == id);
        }

        public DoorGroupsDetail UpdateDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail)
        {
            return _doorGroupsDetailDal.Update(doorGroupsDetail);
        }


        public void DeleteByGrupNoANDPanelID(int? PanelID, int? GrupNo)
        {
            _doorGroupsDetailDal.DeleteByGrupNoANDPanelID(PanelID, GrupNo);
        }

    }
}
