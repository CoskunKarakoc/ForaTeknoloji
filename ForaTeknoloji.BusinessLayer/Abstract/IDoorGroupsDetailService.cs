using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDoorGroupsDetailService
    {
        List<DoorGroupsDetail> GetAllDoorGroupsDetail();
        DoorGroupsDetail GetById(int id);
        DoorGroupsDetail AddDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail);
        void DeleteDoorGroupsDetail(DoorGroupsDetail devicdoorGroupsDetailes);
        DoorGroupsDetail UpdateDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail);
    }
}
