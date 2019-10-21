using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfTimeGroupsDal;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface ITimeGroupsDal : IEntityRepository<TimeGroups>
    {
        List<ComplexTimeGroups> GetComplexTimeGroups(Expression<Func<ComplexTimeGroups, bool>> filter = null);
    }
}
