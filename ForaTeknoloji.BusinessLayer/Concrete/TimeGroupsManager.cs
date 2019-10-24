using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class TimeGroupsManager : ITimeGroupsService
    {
        private ITimeGroupsDal _timeGroupsDal;
        public TimeGroupsManager(ITimeGroupsDal timeGroupsDal)
        {
            _timeGroupsDal = timeGroupsDal;
        }

        public TimeGroups AddTimeGroups(TimeGroups timeGroups)
        {
            return _timeGroupsDal.Add(timeGroups);
        }

        public void DeleteTimeGroups(TimeGroups timeGroups)
        {
            _timeGroupsDal.Delete(timeGroups);
        }

        public List<TimeGroups> GetAllTimeGroups(Expression<Func<TimeGroups, bool>> filter = null)
        {
            return filter == null ? _timeGroupsDal.GetList() : _timeGroupsDal.GetList(filter);
        }

        public TimeGroups GetById(int ZamanGrupNo)
        {
            return _timeGroupsDal.Get(x => x.Zaman_Grup_No == ZamanGrupNo);
        }

        public List<EfTimeGroupsDal.ComplexTimeGroups> GetComplexTimeGroups(Expression<Func<EfTimeGroupsDal.ComplexTimeGroups, bool>> filter = null)
        {
            return filter == null ? _timeGroupsDal.GetComplexTimeGroups() : _timeGroupsDal.GetComplexTimeGroups(filter);
        }

        public TimeGroups UpdateTimeGroups(TimeGroups timeGroups)
        {
            return _timeGroupsDal.Update(timeGroups);
        }
    }
}
