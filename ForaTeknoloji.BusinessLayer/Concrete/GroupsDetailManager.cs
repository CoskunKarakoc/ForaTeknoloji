using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class GroupsDetailManager : IGroupsDetailService
    {
        private IGroupsDetailDal _groupsDetailDal;
        public GroupsDetailManager(IGroupsDetailDal groupsDetailDal)
        {
            _groupsDetailDal = groupsDetailDal;
        }
        public GroupsDetail AddGroupsDetail(GroupsDetail groupsDetail)
        {
            return _groupsDetailDal.Add(groupsDetail);
        }

        public void DeleteGroupsDetail(GroupsDetail groupsDetail)
        {
            _groupsDetailDal.Delete(groupsDetail);
        }

        public List<GroupsDetail> GetAllGroupsDetail(Expression<Func<GroupsDetail, bool>> filter = null)
        {
            return filter == null ? _groupsDetailDal.GetList() : _groupsDetailDal.GetList(filter);
        }

        public GroupsDetail GetById(int id)
        {
            return _groupsDetailDal.Get(x => x.Kayit_No == id);
        }

        public GroupsDetail UpdateGroupsDetail(GroupsDetail groupsDetail)
        {
            return _groupsDetailDal.Update(groupsDetail);
        }
    }
}
