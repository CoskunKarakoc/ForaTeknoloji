using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

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
