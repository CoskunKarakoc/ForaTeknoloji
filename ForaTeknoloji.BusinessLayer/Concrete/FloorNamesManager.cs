using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class FloorNamesManager : IFloorNamesService
    {
        private IFloorNamesDal _floorNamesDal;
        public FloorNamesManager(IFloorNamesDal floorNamesDal)
        {
            _floorNamesDal = floorNamesDal;
        }

        public FloorNames AddFloorName(FloorNames floorNames)
        {
            return _floorNamesDal.Add(floorNames);
        }

        public void DeleteFloorName(FloorNames floorNames)
        {
            _floorNamesDal.Delete(floorNames);
        }

        public List<FloorNames> GetAllFloorNames(Expression<Func<FloorNames, bool>> filter = null)
        {
            return filter == null ? _floorNamesDal.GetList(filter) : _floorNamesDal.GetList(filter);
        }

        public FloorNames GetByFloorName(string Kat_Adi)
        {
            return _floorNamesDal.Get(x => x.Kat_Adi == Kat_Adi);
        }

        public FloorNames GetById(int Kat_No)
        {
            return _floorNamesDal.Get(x => x.Kat_No == Kat_No);
        }

        public FloorNames UpdateFloorName(FloorNames floorNames)
        {
            return _floorNamesDal.Update(floorNames);
        }
    }
}
