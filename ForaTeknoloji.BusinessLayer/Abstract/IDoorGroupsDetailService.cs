using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IDoorGroupsDetailService
    {
        List<DoorGroupsDetail> GetAllDoorGroupsDetail(Expression<Func<DoorGroupsDetail, bool>> filter = null);
        DoorGroupsDetail GetById(int id);
        DoorGroupsDetail AddDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail);
        void DeletDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail);
        void DeleteAll();
        void DeleteByGrupNoANDPanelID(int? PanelID, int? GrupNo);
        DoorGroupsDetail UpdateDoorGroupsDetail(DoorGroupsDetail doorGroupsDetail);
        void DeleteByKapiGrupNo(int Kapi_Grup_No);
    }
}
