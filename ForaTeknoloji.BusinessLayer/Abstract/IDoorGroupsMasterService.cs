using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDoorGroupsMasterService
    {
        List<DoorGroupsMaster> GetAllDoorGroupsMaster(Expression<Func<DoorGroupsMaster, bool>> filter = null);
        DoorGroupsMaster GetById(int id);
        DoorGroupsMaster AddDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster);
        void DeletDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster);
        void DeleteAll();
        DoorGroupsMaster UpdateDoorGroupsMaster(DoorGroupsMaster doorGroupsMaster);
    }
}
