using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDoorGroupsMasterService
    {

        List<DoorGroupsMaster> GetAllDoorGroupsMaster();
        DoorGroupsMaster GetById(int id);
        DoorGroupsMaster AddDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster);
        void DeleteDoorGroupsMaster(DoorGroupsMaster  doorGroupsMaster);
        DoorGroupsMaster UpdateDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster);
    }
}
