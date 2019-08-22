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
    public class MapsManager : IMapsService
    {
        private IMapsDal _mapsDal;
        public MapsManager(IMapsDal mapsDal)
        {
            _mapsDal = mapsDal;
        }
        public Maps AddMap(Maps maps)
        {
            return _mapsDal.Add(maps);
        }

        public void DeleteMap(Maps maps)
        {
            _mapsDal.Delete(maps);
        }

        public List<Maps> GetAllMaps()
        {
            return _mapsDal.GetList();
        }

        public Maps GetById(int id)
        {
            return _mapsDal.Get(x => x.Harita_No == id);
        }

        public Maps UpdateMap(Maps maps)
        {
            return _mapsDal.Update(maps);

        }
    }
}
