using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DoorStatusManager : IDoorStatusService
    {
        private IDoorStatusDal _doorStatusDal;
        public DoorStatusManager(IDoorStatusDal doorStatusDal)
        {
            _doorStatusDal = doorStatusDal;
        }

        public DoorStatus AddDoorStatus(DoorStatus doorStatus)
        {
            return _doorStatusDal.Add(doorStatus);
        }

        public void DeleteDoorStatus(DoorStatus doorStatus)
        {
            _doorStatusDal.Delete(doorStatus);
        }

        public List<DoorStatus> GetAllDoorStatus(Expression<Func<DoorStatus, bool>> filter = null)
        {
            return filter == null ? _doorStatusDal.GetList() : _doorStatusDal.GetList(filter);
        }

        public DoorStatus GetById(int Kayit_No)
        {
            return _doorStatusDal.Get(x => x.Kayit_No == Kayit_No);
        }

        public DoorStatus UpdateDoorStatus(DoorStatus doorStatus)
        {
            return _doorStatusDal.Update(doorStatus);
        }


        public List<ComplexDoorStatus> ComplexDoorStatuses()
        {
            return _doorStatusDal.ComplexDoorStatus();
        }

    }
}
