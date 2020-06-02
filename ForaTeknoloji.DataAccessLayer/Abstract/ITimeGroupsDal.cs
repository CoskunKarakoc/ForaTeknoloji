using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfTimeGroupsDal;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface ITimeGroupsDal : IEntityRepository<TimeGroups>
    {
        List<ComplexTimeGroups> GetComplexTimeGroups(Expression<Func<ComplexTimeGroups, bool>> filter = null);
        void DeleteAll();
        int Count();
    }
}
