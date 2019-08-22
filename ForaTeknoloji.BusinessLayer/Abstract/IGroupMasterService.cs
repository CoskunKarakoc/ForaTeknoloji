using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IGroupMasterService
    {
        List<GroupsMaster> GetAllGroupsMaster();
        GroupsMaster GetById(int id);
        GroupsMaster AddGroupsMaster(GroupsMaster groupsMaster);
        void DeleteGroupsMaster(GroupsMaster groupsMaster);
        GroupsMaster UpdateGroupsMaster(GroupsMaster groupsMaster);
    }
}
