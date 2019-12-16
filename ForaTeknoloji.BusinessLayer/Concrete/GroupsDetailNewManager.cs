using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class GroupsDetailNewManager : IGroupsDetailNewService
    {
        private IGroupsDetailNewDal _groupsDetailNewDal;
        public GroupsDetailNewManager(IGroupsDetailNewDal groupsDetailNewDal)
        {
            _groupsDetailNewDal = groupsDetailNewDal;
        }

        public GroupsDetailNew AddGroupsDetailNew(GroupsDetailNew groupsDetailNew)
        {
            return _groupsDetailNewDal.Add(groupsDetailNew);
        }

        public void DeleteGroupsDetailNew(GroupsDetailNew groupsDetailNew)
        {
            _groupsDetailNewDal.Delete(groupsDetailNew);
        }

        public List<GroupsDetailNew> GetAllGroupsDetailNew(Expression<Func<GroupsDetailNew, bool>> filter = null)
        {
            return filter == null ? _groupsDetailNewDal.GetList() : _groupsDetailNewDal.GetList(filter);
        }

        public GroupsDetailNew GetById(int Grup_No)
        {
            return _groupsDetailNewDal.Get(x => x.Grup_No == Grup_No);
        }

        public GroupsDetailNew GetBy_GrupNo_AND_PanelID(int Grup_No, int Panel_ID)
        {
            return _groupsDetailNewDal.Get(x => x.Grup_No == Grup_No && x.Panel_No == Panel_ID);
        }

        public List<ComplexGroupsDetailNew> GetComplexGroups()
        {
            return _groupsDetailNewDal.GetComplexGroups();
        }

        public GroupsDetailNew UpdateGroupsDetailNew(GroupsDetailNew groupsDetailNew)
        {
            return _groupsDetailNewDal.Update(groupsDetailNew);
        }


        public void DeleteAll()
        {
            _groupsDetailNewDal.DeleteAll();
        }

    }
}
