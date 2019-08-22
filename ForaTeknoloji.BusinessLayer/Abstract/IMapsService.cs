using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IMapsService
    {

        List<Maps> GetAllMaps();
        Maps GetById(int id);
        Maps AddMap(Maps maps);
        void DeleteMap(Maps maps);
        Maps UpdateMap(Maps maps);
    }
}
