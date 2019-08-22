using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IGroupsDetailService
    {
        List<GroupsDetail> GetAllGroupsDetail();
        GroupsDetail GetById(int id);
        GroupsDetail AddGroupsDetail(GroupsDetail groupsDetail);
        void DeleteGroupsDetail(GroupsDetail groupsDetail);
        GroupsDetail UpdateGroupsDetail(GroupsDetail groupsDetail);
    }
}
