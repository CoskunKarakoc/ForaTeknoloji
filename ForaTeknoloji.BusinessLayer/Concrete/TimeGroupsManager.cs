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
    public class TimeGroupsManager : ITimeGroupsService
    {
        private ITimeGroupsDal _timeGroupsDal;
        public TimeGroupsManager(ITimeGroupsDal timeGroupsDal)
        {
            _timeGroupsDal = timeGroupsDal;
        }
        public TimeGroups AddTimeGroup(TimeGroups timeGroups)
        {
            return _timeGroupsDal.Add(timeGroups);
        }

        public void DeleteTimeGroup(TimeGroups timeGroups)
        {
            _timeGroupsDal.Delete(timeGroups);
        }

        public List<TimeGroups> GetAllTimeGroups()
        {
            return _timeGroupsDal.GetList();
        }

        public TimeGroups GetById(int id)
        {
            return _timeGroupsDal.Get(x => x.Zaman_Grup_No == id);
        }

        public TimeGroups UpdateTimeGroup(TimeGroups timeGroups)
        {
            return _timeGroupsDal.Update(timeGroups);
        }
    }
}
