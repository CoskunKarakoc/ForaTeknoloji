using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IGlobalZoneService
    {
        List<GlobalZones> GetAllGlobalZones();
        GlobalZones GetById(int id);
        GlobalZones AddGlobalZones(GlobalZones globalZones);
        void DeleteGlobalZones(GlobalZones globalZones);
        GlobalZones UpdateGlobalZones(GlobalZones globalZones);
    }
}
