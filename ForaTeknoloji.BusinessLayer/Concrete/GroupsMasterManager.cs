using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class GroupsMasterManager : IGroupMasterService
    {
        private IGroupMasterDal _groupMasterDal;
        public GroupsMasterManager(IGroupMasterDal groupMasterDal)
        {
            _groupMasterDal = groupMasterDal;
        }
        public GroupsMaster AddGroupsMaster(GroupsMaster groupsMaster)
        {
            return _groupMasterDal.Add(groupsMaster);
        }

        public void DeleteGroupsMaster(GroupsMaster groupsMaster)
        {
            _groupMasterDal.Delete(groupsMaster);
        }

        public List<GroupsMaster> GetAllGroupsMaster()
        {
            return _groupMasterDal.GetList();
        }

        public GroupsMaster GetById(int id)
        {
            return _groupMasterDal.Get(x => x.Grup_No == id);
        }

        public GroupsMaster UpdateGroupsMaster(GroupsMaster groupsMaster)
        {
            return _groupMasterDal.Update(groupsMaster);
        }


        public void DeleteAll()
        {
            _groupMasterDal.DeleteAll();
        }



    }
}
