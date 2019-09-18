using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IGroupsDetailService
    {
        List<GroupsDetail> GetAllGroupsDetail(Expression<Func<GroupsDetail, bool>> filter = null);
        GroupsDetail GetById(int id);
        GroupsDetail AddGroupsDetail(GroupsDetail groupsDetail);
        void DeleteGroupsDetail(GroupsDetail groupsDetail);
        GroupsDetail UpdateGroupsDetail(GroupsDetail groupsDetail);
    }
}
