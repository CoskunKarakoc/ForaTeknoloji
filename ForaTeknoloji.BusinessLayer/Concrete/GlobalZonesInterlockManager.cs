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
    public class GlobalZonesInterlockManager : IGlobalZonesInterlockService
    {
        private IGlobalZonesInterlockDal _globalZonesInterlockDal;
        public GlobalZonesInterlockManager(IGlobalZonesInterlockDal globalZonesInterlockDal)
        {
            _globalZonesInterlockDal = globalZonesInterlockDal;
        }
        public GlobalZonesInterlock AddGlobalZonesInterlock(GlobalZonesInterlock globalZonesInterlock)
        {
            return _globalZonesInterlockDal.Add(globalZonesInterlock);
        }

        public void DeleteGlobalZonesInterlock(GlobalZonesInterlock globalZonesInterlock)
        {
            _globalZonesInterlockDal.Delete(globalZonesInterlock);
        }

        public List<GlobalZonesInterlock> GetAllGlobalZonesInterlock()
        {
            return _globalZonesInterlockDal.GetList();
        }

        public GlobalZonesInterlock GetById(int id)
        {
            return _globalZonesInterlockDal.Get(x => x.Pair_No == id);
        }

        public GlobalZonesInterlock UpdateGlobalZonesInterlock(GlobalZonesInterlock globalZonesInterlock)
        {
            return _globalZonesInterlockDal.Update(globalZonesInterlock);
        }
    }
}
