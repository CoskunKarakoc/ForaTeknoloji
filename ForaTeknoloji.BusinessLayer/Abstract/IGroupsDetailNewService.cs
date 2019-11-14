using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IGroupsDetailNewService
    {
        List<GroupsDetailNew> GetAllGroupsDetailNew(Expression<Func<GroupsDetailNew, bool>> filter = null);
        GroupsDetailNew GetById(int Grup_No);
        GroupsDetailNew AddGroupsDetailNew(GroupsDetailNew groupsDetailNew);
        void DeleteGroupsDetailNew(GroupsDetailNew groupsDetailNew);
        GroupsDetailNew UpdateGroupsDetailNew(GroupsDetailNew groupsDetailNew);
        List<ComplexGroupsDetailNew> GetComplexGroups();
    }
}
