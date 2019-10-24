using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfTimeGroupsDal;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ITimeGroupsService
    {
        List<TimeGroups> GetAllTimeGroups(Expression<Func<TimeGroups, bool>> filter = null);
        TimeGroups GetById(int ZamanGrupNo);
        TimeGroups AddTimeGroups(TimeGroups timeGroups);
        void DeleteTimeGroups(TimeGroups timeGroups);
        TimeGroups UpdateTimeGroups(TimeGroups timeGroups);
        List<ComplexTimeGroups> GetComplexTimeGroups(Expression<Func<ComplexTimeGroups, bool>> filter = null);
    }
}
