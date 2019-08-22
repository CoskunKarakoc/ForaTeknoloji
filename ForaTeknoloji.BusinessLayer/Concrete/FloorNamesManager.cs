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

        public List<FloorNames> GetAllFloorNames()
        {
            return _floorNamesDal.GetList();
        }

        public FloorNames GetById(int id)
        {
            return _floorNamesDal.Get(x => x.Kat_No == id);
        }

        public FloorNames UpdateFloorName(FloorNames floorNames)
        {
            return _floorNamesDal.Update(floorNames);
        }
    }
}
