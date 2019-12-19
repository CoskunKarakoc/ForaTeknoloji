using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface ITimeZoneCalendarService
    {

        List<TimeZoneCalendar> GetAllTimeZoneCalendar();
        TimeZoneCalendar GetById(int id);
        TimeZoneCalendar AddTimeZoneCalendar(TimeZoneCalendar timeZoneCalendar);
        void DeleteTimeZoneCalendar(TimeZoneCalendar timeZoneCalendar);
        TimeZoneCalendar UpdateTimeZoneCalendar(TimeZoneCalendar timeZoneCalendar);
    }
}
