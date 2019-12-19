using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class GlobalZoneManager : IGlobalZoneService
    {
        private IGlobalZoneDal _globalZoneDal;
        public GlobalZoneManager(IGlobalZoneDal globalZoneDal)
        {
            _globalZoneDal = globalZoneDal;
        }
        public GlobalZones AddGlobalZones(GlobalZones globalZones)
        {
            return _globalZoneDal.Add(globalZones);
        }

        public void DeleteGlobalZones(GlobalZones globalZones)
        {
            _globalZoneDal.Delete(globalZones);
        }

        public List<GlobalZones> GetAllGlobalZones(Expression<Func<GlobalZones, bool>> filter = null)
        {
            return filter == null ? _globalZoneDal.GetList() : _globalZoneDal.GetList(filter);
        }

        public GlobalZones GetById(int id)
        {
            return _globalZoneDal.Get(x => x.Global_Bolge_No == id);
        }

        public GlobalZones UpdateGlobalZones(GlobalZones globalZones)
        {
            return _globalZoneDal.Update(globalZones);
        }
    }
}
