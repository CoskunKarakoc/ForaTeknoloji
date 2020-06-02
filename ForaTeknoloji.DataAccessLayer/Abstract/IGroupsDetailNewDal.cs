using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IGroupsDetailNewDal : IEntityRepository<GroupsDetailNew>
    {

        List<ComplexGroupsDetailNew> GetComplexGroups();
        void DeleteAll();
        void UpdateTSQL(string GrupAdi, int GrupNo);
        void DeleteWithGrupNoTSQL(int GrupNo);
        List<ComplexGroupsDetailNew> GetComplexGroupsWithQuery(Expression<Func<ComplexGroupsDetailNew, bool>> filter = null);
    }
}
