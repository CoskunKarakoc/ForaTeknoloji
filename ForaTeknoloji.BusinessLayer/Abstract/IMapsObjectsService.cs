using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IMapsObjectsService
    {

        List<MapObjects> GetAllMapObjects();
        MapObjects GetById(int id);
        MapObjects AddMapObject(MapObjects mapObjects);
        void DeleteMapObject(MapObjects mapObjects);
        MapObjects UpdateMapObject(MapObjects mapObjects);
    }
}
