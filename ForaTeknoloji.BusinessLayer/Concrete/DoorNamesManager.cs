using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class DoorNamesManager : IDoorNamesService
    {
        private IDoorNamesDal _doorNamesDal;
        public DoorNamesManager(IDoorNamesDal doorNamesDal)
        {
            _doorNamesDal = doorNamesDal;
        }
        public DoorNames AddDoorNames(DoorNames doorNames)
        {
            return _doorNamesDal.Add(doorNames);
        }

        public void DeleteDoorNames(DoorNames doorNames)
        {
            _doorNamesDal.Delete(doorNames);
        }

        public List<DoorNames> GetAllDoorNames(Expression<Func<DoorNames, bool>> filter = null)
        {
            return filter == null ? _doorNamesDal.GetList() : _doorNamesDal.GetList(filter);
        }

        public DoorNames GetById(int id)
        {
            return _doorNamesDal.Get(x => x.Kayit_No == id);
        }

        public DoorNames UpdateDoorNames(DoorNames doorNames)
        {
            return _doorNamesDal.Update(doorNames);
        }

        public List<DoorNames> GetByPanelNo(int panelNo)
        {
            return _doorNamesDal.GetList(x=>x.Panel_No==panelNo);
        }

    }
}
