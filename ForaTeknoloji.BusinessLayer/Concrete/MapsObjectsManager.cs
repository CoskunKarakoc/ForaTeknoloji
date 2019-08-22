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
    public class MapsObjectsManager : IMapsObjectsService
    {
        private IMapsObjectsDal _mapsObjectsDal;
        public MapsObjectsManager(IMapsObjectsDal mapsObjectsDal)
        {
            _mapsObjectsDal = mapsObjectsDal;
        }
        public MapObjects AddMapObject(MapObjects mapObjects)
        {
            return _mapsObjectsDal.Add(mapObjects);
        }

        public void DeleteMapObject(MapObjects mapObjects)
        {
            _mapsObjectsDal.Delete(mapObjects);
        }

        public List<MapObjects> GetAllMapObjects()
        {
            return _mapsObjectsDal.GetList();
        }

        public MapObjects GetById(int id)
        {
            return _mapsObjectsDal.Get(x => x.Nesne_No == id);
        }

        public MapObjects UpdateMapObject(MapObjects mapObjects)
        {
            return _mapsObjectsDal.Update(mapObjects);
        }
    }
}
