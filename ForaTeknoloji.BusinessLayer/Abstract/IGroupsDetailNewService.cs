using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IGroupsDetailNewService
    {
        List<GroupsDetailNew> GetAllGroupsDetailNew(Expression<Func<GroupsDetailNew, bool>> filter = null);
        GroupsDetailNew GetById(int Grup_No);
        GroupsDetailNew GetBy_GrupNo_AND_PanelID(int Grup_No, int Panel_ID);
        GroupsDetailNew AddGroupsDetailNew(GroupsDetailNew groupsDetailNew);
        void DeleteGroupsDetailNew(GroupsDetailNew groupsDetailNew);
        GroupsDetailNew UpdateGroupsDetailNew(GroupsDetailNew groupsDetailNew);
        List<ComplexGroupsDetailNew> GetComplexGroups();
        void DeleteAll();
    }
}
