using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IGroupsDetailNewDal : IEntityRepository<GroupsDetailNew>
    {

        List<ComplexGroupsDetailNew> GetComplexGroups();
        void DeleteAll();

    }
}
