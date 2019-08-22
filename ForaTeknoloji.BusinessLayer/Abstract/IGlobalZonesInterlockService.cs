using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IGlobalZonesInterlockService
    {
        List<GlobalZonesInterlock> GetAllGlobalZonesInterlock();
        GlobalZonesInterlock GetById(int id);
        GlobalZonesInterlock AddGlobalZonesInterlock(GlobalZonesInterlock globalZonesInterlock);
        void DeleteGlobalZonesInterlock(GlobalZonesInterlock globalZonesInterlock);
        GlobalZonesInterlock UpdateGlobalZonesInterlock(GlobalZonesInterlock globalZonesInterlock);
    }
}
