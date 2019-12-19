using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDoorNamesService
    {
        List<DoorNames> GetAllDoorNames(Expression<Func<DoorNames, bool>> filter = null);
        DoorNames GetById(int id);
        DoorNames AddDoorNames(DoorNames doorNames);
        void DeleteDoorNames(DoorNames doorNames);
        DoorNames UpdateDoorNames(DoorNames doorNames);
        List<DoorNames> GetByPanelNo(int panelNo);
        DoorNames GetByKapiAdiAndPanelID(int? KapiID, int? PanelID);
    }
}
