using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class TimeZoneCalendarManager : ITimeZoneCalendarService
    {
        private ITimeZoneCalendarDal _timeZoneCalendarDal;
        public TimeZoneCalendarManager(ITimeZoneCalendarDal timeZoneCalendarDal)
        {
            _timeZoneCalendarDal = timeZoneCalendarDal;
        }
        public TimeZoneCalendar AddTimeZoneCalendar(TimeZoneCalendar timeZoneCalendar)
        {
            return _timeZoneCalendarDal.Add(timeZoneCalendar);
        }

        public void DeleteTimeZoneCalendar(TimeZoneCalendar timeZoneCalendar)
        {
            _timeZoneCalendarDal.Delete(timeZoneCalendar);
        }

        public List<TimeZoneCalendar> GetAllTimeZoneCalendar()
        {
            return _timeZoneCalendarDal.GetList();
        }

        public TimeZoneCalendar GetById(int id)
        {
            return _timeZoneCalendarDal.Get(x => x.Grup_Takvimi_No == id);
        }

        public TimeZoneCalendar UpdateTimeZoneCalendar(TimeZoneCalendar timeZoneCalendar)
        {
            return _timeZoneCalendarDal.Update(timeZoneCalendar);
        }
    }
}
